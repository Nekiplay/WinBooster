using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Native;

namespace WinBoosterLauncher
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster"))
            {
                if (File.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunASTI.txt"))
                {
                    string text = File.ReadAllText(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunASTI.txt");
                    if (File.Exists(text))
                    {
                        FileInfo fileInfo = new FileInfo(text);
                        if (fileInfo.Extension == ".exe")
                        {
                            Process p = new Process();
                            p.StartInfo.FileName = "cmd.exe";
                            p.StartInfo.Arguments = "/c " + Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunAsTI.exe" + " /s \"" + text + "\"";
                            p.StartInfo.CreateNoWindow = true;
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            p.Start();
                        }
                        else
                        {
                            File.Delete(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunASTI.txt");
                        }
                    }
                    else
                    {
                        File.Delete(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunASTI.txt");
                    }
                }
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
