using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster.Clears.OtherClients
{
    public class PolyMC : WorkInterface
    {
        public string dir;
        public string patern;
        public PolyMC(string dir, string patern)
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
            this.patern = patern;
        }

        public long Work()
        {
            long deleted = 0;
            if (Directory.Exists(dir))
            {
                var dirst = Directory.GetDirectories(dir);
                foreach (string dir2 in dirst)
                {
                    var files = Directory.GetFiles(dir2, patern);
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        try
                        {
                            deleted += fi.Length;
                            fi.Delete();
                        }
                        catch
                        {
                            deleted -= fi.Length;
                        }
                    }
                }
            }
            return deleted;
        }
    }
}
