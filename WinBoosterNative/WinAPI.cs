using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinBoosterNative
{
    public class WinAPI
    {

        public class Process
        {
            [DllImport("user32.dll")]
            private static extern bool SetWindowText(IntPtr hWnd, string text);

            public static bool ChangeTitle(IntPtr hWnd, string text)
            {
                return SetWindowText(hWnd, text);
            }
            public static bool ChangeTitle(System.Diagnostics.Process process, string text)
            {
                return SetWindowText(process.MainWindowHandle, text);
            }
        }
    }
}
