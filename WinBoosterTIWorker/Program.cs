using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using WinBooster.Native;

namespace WinBoosterTIWorker
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);

            SafeNames safe = new SafeNames();
            long removed = 0;
            RegistryKey shellbag = Registry.LocalMachine.OpenSubKey("SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings", true);
            foreach (string name in shellbag.GetSubKeyNames())
            {
                var nameshell = shellbag.OpenSubKey(name, true);
                foreach (string name2 in nameshell.GetValueNames())
                {
                    if (name2.StartsWith("\\Device")) 
                    {
                        if (!safe.IsSafeName(name2))
                        {
                            nameshell.DeleteValue(name2);
                        }
                    }
                }
            }
        }
    }
}
