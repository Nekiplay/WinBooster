using System;
using System.Collections.Generic;
using System.IO;

namespace WinBooster.Native
{
    public class DirectoryFull : WorkingI
    {
        public string directory;
        public DirectoryFull(string dir)
        {
            if (dir.Contains("%username%"))
                dir = dir.Replace("%username%", Environment.UserName);
            if (dir.Contains("%cycdrive%"))
                dir = dir.Replace("%cycdrive%", Utils.GetSysDrive());
            if (dir.Contains("%steam%"))
            {
                var steam = Utils.FindSteamDirectory();
                if (steam != null)
                {
                    dir = dir.Replace("%steam%", steam.FullName);
                }
            }

            if (Directory.Exists(dir))
            {
                directory = dir;
            }
        }

        public string GetDirectory()
        {
            return directory;
        }

        public string GetPattern()
        {
            return "";
        }
        public List<string> GetSafeNames()
        {
            return new List<string>();
        }

        public long Work()
        {
            if (Directory.Exists(directory))
            {
                DirectoryInfo info = new DirectoryInfo(directory);
                long pre = 0;
                if (info.Exists)
                {
                    pre = Utils.DirSize(info);
                    try { Directory.Delete(directory, true); } catch { }
                    DirectoryInfo info2 = new DirectoryInfo(directory);
                    long done = Utils.DirSize(info2);
                    pre -= done;
                }
                return pre;
            }
            return 0;
        }
    }
}
