using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinBooster.Native
{
    public class DirectoryUnsafeFileNames : WorkingI
    {
        public string dir;
        public List<string> safenames;
        public DirectoryUnsafeFileNames(string dir, List<string> safenames)
        {
            if (dir.Contains("%username%"))
                dir = dir.Replace("%username%", Environment.UserName);
            if (dir.Contains("%cycdrive%"))
                dir = dir.Replace("%cycdrive%", Utils.GetSysDrive());
            this.dir = dir;
            this.safenames = safenames;
        }

        public long Work()
        {
            long deleted = 0;
            if (Directory.Exists(dir))
            {
                var files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Extension == ".pf")
                    {
                        if (!safenames.Contains(fi.Name.Split('-').FirstOrDefault()))
                        {
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
            }
            return deleted;
        }
    }
}
