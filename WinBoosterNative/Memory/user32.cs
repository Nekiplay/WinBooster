using Process.NET;
using Process.NET.Modules;
using Process.NET.Native.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WinBoosterNative.Memory
{
    public class user32
    {
        private delegate void CreateWindowA(string class_name, string window_name, long style, int x, int y, int width, int height, int WndParent);
        private delegate int MessageBoxA(IntPtr hWnd, string text, string caption, uint type);
        private delegate void CloseWindowA(IntPtr hWnd);

        private ProcessSharp process;
        public user32(ProcessSharp process)
        {
            this.process = process;
        }
        public void CreateWindow(string class_name, string window_name, long style, int x, int y, int width, int height, int WndParent)
        {
            var processFunction = process.ModuleFactory["user32"]["CreateWindowA"];
            var @delegate = processFunction.GetDelegate<CreateWindowA>();
            @delegate.Invoke(class_name, window_name, style, x, y, width, height, WndParent);
        }
        public int MessageBox(string message, string title, uint type)
        {
            var processFunction = process.ModuleFactory["user32"]["MessageBoxExA"];
            var @delegate = processFunction.GetDelegate<MessageBoxA>();
            return @delegate.Invoke(process.WindowFactory.MainWindow.Handle, message, title, type);
        }
        public void ChangeMainWindowSize(int height, int width)
        {
            process.WindowFactory.MainWindow.Height = height;
            process.WindowFactory.MainWindow.Width = width;
        }
        public void HideMainWindow()
        {
            process.WindowFactory.MainWindow.State = Process.NET.Native.Types.WindowStates.Hide;
        }
    }
}
