using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBoosterNative.Events
{
    public class ProcessRunning
    {
        public Process process;
        public FileInfo file;

        public ProcessRunning(Process process, FileInfo file)
        {
            this.process = process;
            this.file = file;
        }
    }
}
