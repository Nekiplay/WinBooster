﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinBoosterNative.Security.AES.Threading
{
    internal class OverlappedStreamStriper : Stream
    {
        private class Strings
        {
            public const string CtorStreamArgumentExceptionMsg = "Streams may not be null and must be able to write for splitting or to read for joining.";
        }

        /// <summary> Argument class for OverlappedBlockChanging event. </summary>
        public class OverlappedBlockChangingEventArgs : EventArgs
        {
            /// <summary> The stream containing the block just completed. </summary>
            public readonly Stream PreviousStream;
            /// <summary> The stream containing the block just starting. </summary>
            public readonly Stream NextStream;
            /// <summary>  The overlapping bytes from the stream with the previous block. </summary>
            public readonly byte[] OverlapFromPrevious;
            /// <summary> 
            /// The overlapping bytes in the stream with the next block. In Split mode, modifications 
            /// by the handler will actually be written to the stream.
            /// </summary>
            public readonly byte[] OverlapOnNext;
            /// <summary> Sets up an instance of OverlappedBlockChangingEventArgs </summary>
            public OverlappedBlockChangingEventArgs(Stream prevStream, Stream nextStream, byte[] prevOvl, byte[] nextOvl)
            {
                this.PreviousStream = prevStream; this.NextStream = nextStream;
                this.OverlapFromPrevious = prevOvl; this.OverlapOnNext = nextOvl;
            }
        }
        /// <summary> Delegate for OverlappedBlockChanging event. </summary>
        public delegate void OverlappedBlockChangingEventHandler(object sender, OverlappedBlockChangingEventArgs e);

        /// <summary>
        /// This event let's you track whenever and an overlap is inserted (Split) or discarded (Join)
        /// on a block change (chunk complete). In Split mode, it let's a handler modify the bytes used as
        /// overlap. In Join mode, it can be used to verify correct operation (compare overlaps).
        /// Note: For writes, the event is (obviously) triggered before the overlap is written.
        ///       For reads, the overlap is read from NextStream to be returned, but no data ahead is read.
        /// </summary>
        public event OverlappedBlockChangingEventHandler OverlappedBlockChanging;

        private readonly Mode m_mode;
        private readonly int m_chunksize;
        private readonly Stream[] m_stripeStreams;
        private readonly byte[] m_overlap;

        private int m_currentStream;
        private long m_bytesProcessed;

        private int overlapSize { get { return m_overlap.Length; } }
        private int streamCount { get { return m_stripeStreams.Length; } }

        /// <summary> The mode of operation for OverlappedStreamStriper </summary>
        public enum Mode
        {
            /// <summary> Use OverlappedStreamStriper in Split-Mode (write-only stream). </summary>
            Split = 0,
            /// <summary> Use OverlappedStreamStriper in Join-Mode (read-only stream). </summary>
            Join = 1,
        }

        /// <summary> Sets up a striper with the specified parameters. </summary>
        /// <param name="mode"> Specify whether this instance will be used for splitting or joining streams. </param>
        /// <param name="stripeStreams"> List of streams to chunks are striped to / from. </param>
        /// <param name="chunksize"> The size of each block after which to move to next stream (without overlap). </param>
        /// <param name="overlapSize"> The number of bytes the chunks are overlapped with. </param>
        public OverlappedStreamStriper(Mode mode, ICollection<Stream> stripeStreams, int chunksize, int overlapSize)
        {
            if (stripeStreams == null || stripeStreams.Count == 0) throw new ArgumentNullException("stripeStreams");

            if (mode != Mode.Split && mode != Mode.Join)
                throw new ArgumentException("mode");

            m_mode = mode;

            m_stripeStreams = new Stream[stripeStreams.Count];
            int i = 0;
            foreach (Stream s in stripeStreams)
            {
                if (s == null || (mode == Mode.Join && !s.CanRead) || (mode == Mode.Split && !s.CanWrite))
                    throw new ArgumentException(Strings.CtorStreamArgumentExceptionMsg);
                m_stripeStreams[i++] = s;
            }

            if (overlapSize < 0 || overlapSize > chunksize)
                throw new ArgumentException("overlapSize");

            this.m_chunksize = chunksize;
            this.m_overlap = new byte[overlapSize];
            this.m_bytesProcessed = 0;
            this.m_currentStream = 0;
        }

        /// <summary> Internally handles OverlappedBlockChanging and raises event.  </summary>
        protected void OnOverlappedBlockChanging(byte[] nextChunkOverlap)
        {
            if (OverlappedBlockChanging != null)
            {
                OverlappedBlockChangingEventArgs e = new OverlappedBlockChangingEventArgs(
                    m_stripeStreams[m_currentStream], m_stripeStreams[((m_currentStream + streamCount) - 1) % streamCount],
                    (byte[])m_overlap.Clone(), nextChunkOverlap
                    );
                OverlappedBlockChanging(this, e);
            }
        }

        /// <summary> Returns whether the stream index was actually changed or stays the same. </summary>
        private bool setNextStream()
        {
            if (m_bytesProcessed == 0) return false; // no stream change on start
            int next = m_currentStream;
            while ((next = (next + 1) % streamCount) != m_currentStream)
            { m_currentStream = next; return true; }
            return false;
        }

        /// <summary> Returns whether this instance is suitable for reading (Join mode). </summary>
        public override bool CanRead { get { return m_mode == Mode.Join; } }
        /// <summary> Returns whether this instance is suitable for writing (Split mode). </summary>
        public override bool CanWrite { get { return m_mode == Mode.Split; } }
        /// <summary> Always false, OverlappedStreamStriper cannot seek. </summary>
        public override bool CanSeek { get { return false; } }
        /// <summary> Flushes all stripe streams. </summary>
        public override void Flush() { for (int i = 0; i < streamCount; i++) m_stripeStreams[(m_currentStream + i + 1) % streamCount].Flush(); }
        /// <summary> Always throws NotSupportedException. </summary>
        public override long Length { get { throw new NotSupportedException(); } }
        /// <summary> Always throws NotSupportedException. </summary>
        public override long Position
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
        /// <summary> Always throws NotSupportedException. </summary>
        public override long Seek(long offset, SeekOrigin origin) { throw new NotSupportedException(); }
        /// <summary> Always throws NotSupportedException. </summary>
        public override void SetLength(long value) { throw new NotSupportedException(); }

        /// <summary> Read from stripes. </summary>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (m_mode != Mode.Join) throw new InvalidOperationException();
            int br = 0;
            int c = -1;
            while (count > 0 && c != 0)
            {
                int chunkoffset = (int)(m_bytesProcessed % m_chunksize);
                int leftInChunk = m_chunksize - chunkoffset;

                if (chunkoffset == 0 && setNextStream()) // skip data
                {
                    byte[] tmp = new byte[overlapSize];
                    int skipped = 0;
                    do { skipped += (c = m_stripeStreams[m_currentStream].Read(tmp, skipped, overlapSize - skipped)); }
                    while (c != 0 && skipped < overlapSize);
                    if (skipped < overlapSize) break; // stream ended.
                    OnOverlappedBlockChanging(tmp);
                }
                c = m_stripeStreams[m_currentStream].Read(buffer, offset, Math.Min(leftInChunk, count));
                count -= c;
                offset += c;
                br += c;

                // store overlap from read-operation for Changed event
                if (c > (leftInChunk - overlapSize)) // Read touched overlapping area
                {
                    int ovlStart = Math.Max(0, overlapSize - leftInChunk);
                    int ovlEnd = overlapSize - leftInChunk + c;
                    int ovlCnt = ovlEnd - ovlStart;
                    Array.Copy(buffer, offset - ovlCnt, m_overlap, ovlStart, ovlCnt);
                }

                m_bytesProcessed += c;
            }
            return br;
        }


        /// <summary> Write to stripes. </summary>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (m_mode != Mode.Split) throw new InvalidOperationException();

            while (count > 0)
            {
                int chunkoffset = (int)(m_bytesProcessed % m_chunksize);
                int leftInChunk = m_chunksize - chunkoffset;

                if (chunkoffset == 0 && setNextStream())
                {
                    OnOverlappedBlockChanging(m_overlap);
                    m_stripeStreams[m_currentStream].Write(m_overlap, 0, m_overlap.Length);
                }

                int c = Math.Min(leftInChunk, count);
                m_stripeStreams[m_currentStream].Write(buffer, offset, c);
                count -= c;
                offset += c;

                // store overlap for next Write-operation
                if (c > (leftInChunk - overlapSize)) // Write touched overlapping area
                {
                    int ovlStart = Math.Max(0, overlapSize - leftInChunk);
                    int ovlEnd = overlapSize - leftInChunk + c;
                    int ovlCnt = ovlEnd - ovlStart;
                    Array.Copy(buffer, offset - ovlCnt, m_overlap, ovlStart, ovlCnt);
                }

                m_bytesProcessed += c;
            }
        }

        /// <summary> Disposes striper and closes all stripe streams through thread pool. </summary>
        protected override void Dispose(bool disposing)
        {
            int streamsToClose = streamCount;

            // Close all stripe streams. 
            // As this class is used in async operations that are synchronized
            // via DirectStreamLink (writer's close waits for reader to close first)
            // we fire the Close()-Operations via ThreadPool.
            foreach (var s in m_stripeStreams)
            {
                ThreadPool.QueueUserWorkItem(tmp =>
                {
                    try { ((Stream)tmp).Close(); }
                    catch { }
                    finally { Interlocked.Decrement(ref streamsToClose); }
                }, s);
            }

            // Finally wait until all are closed (for syncing)
            // Note: as we cannot set a local var volatile, we use Interlocked
            //       to make sure the compiler does not optimize this to an endless loop
            while (Interlocked.CompareExchange(ref streamsToClose, -1, 0) > 0)
                Thread.Sleep(0);

            base.Dispose(disposing);
        }
    }
}
