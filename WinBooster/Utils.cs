using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster
{
    internal class Utils
    {
        public static DirectoryInfo FindSteamDirectory()
        {
            if (Directory.Exists("C:\\Program Files (x86)\\Steam"))
            {
                return new DirectoryInfo("C:\\Program Files (x86)\\Steam");
            }
            return null;
        }
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            if (d.Exists)
            {
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
            }
            return size;
        }
    }
}
