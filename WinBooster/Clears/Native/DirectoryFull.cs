using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster.Clears
{
    public class DirectoryFull : WorkingI
    {
        public string dir;
        public DirectoryFull(string dir)
        {
            if (dir.Contains("%username%"))
                dir = dir.Replace("%username%", Environment.UserName);
            if (dir.Contains("%steam%"))
            {
                var steam = Utils.FindSteamDirectory();
                if (steam != null)
                {
                    dir = dir.Replace("%steam%", steam.FullName);
                }
            }
            this.dir = dir;
        }

        public long Work()
        {
            if (Directory.Exists(dir))
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                long pre = Utils.DirSize(info);
                try { Directory.Delete(dir, true); } catch { }
                DirectoryInfo info2 = new DirectoryInfo(dir);
                pre -= Utils.DirSize(info2);
                return pre;
            }
            return 0;
        }
    }
}
