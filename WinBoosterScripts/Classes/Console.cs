using System.Runtime.InteropServices;

namespace WinBoosterScripts.Classes
{
    public class Console
    {
        public bool Enable()
        {
            return AllocConsole();
        }
        public bool Close()
        {
            return FreeConsole();
        }

        public void WriteLine(object obj)
        {
            System.Console.WriteLine(obj);
        }
        public void Write(object obj)
        {
            System.Console.Write(obj);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();
    }
}
