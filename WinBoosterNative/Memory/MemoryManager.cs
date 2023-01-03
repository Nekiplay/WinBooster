using Process.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBoosterNative.Memory
{
    public class MemoryManager
    {
        public user32 user32;
        private System.Diagnostics.Process process;
        public ProcessSharp ProcessSharp { get; set; }
        public MemoryManager(System.Diagnostics.Process process)
        {
            ProcessSharp = new ProcessSharp(process, Process.NET.Memory.MemoryType.Remote);
            Console.WriteLine(ProcessSharp.WindowFactory.MainWindow.Title);
            user32 = new user32(ProcessSharp);
            this.process = process;
        }
    }
}
