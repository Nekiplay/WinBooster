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
        public static string GetSysDrive()
        {
            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string path = Path.GetPathRoot(system);
            int x1 = path.Length - 1;
            path = path.Remove(x1);
            return path;
        }
        public static DirectoryInfo FindSteamDirectory()
        {
            if (Directory.Exists("C:\\Program Files (x86)\\Steam"))
            {
                return new DirectoryInfo("C:\\Program Files (x86)\\Steam");
            }
            else if (Directory.Exists("D:\\Program Files (x86)\\Steam"))
            {
                return new DirectoryInfo("D:\\Program Files (x86)\\Steam");
            }
            else if (Directory.Exists("E:\\Program Files (x86)\\Steam"))
            {
                return new DirectoryInfo("E:\\Program Files (x86)\\Steam");
            }
            return null;
        }

        public static string GetStringSize(long lenght)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = lenght;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            string result = String.Format("{0:0.##} {1}", len, sizes[order]);
            return result;
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
