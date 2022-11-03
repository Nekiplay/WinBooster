using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinBooster.Native
{
    public class DirectoryUnsafeFileNames : WorkingI
    {
        public string directory;
        public List<string> safenames;
        public DirectoryUnsafeFileNames(string dir, List<string> safenames)
        {
            if (dir.Contains("%username%"))
                dir = dir.Replace("%username%", Environment.UserName);
            if (dir.Contains("%cycdrive%"))
                dir = dir.Replace("%cycdrive%", Utils.GetSysDrive());
            this.directory = dir;
            this.safenames = safenames;
        }

        public Tuple<long, long> Work()
        {
            long deleted = 0;
            long filesd = 0;
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
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
                                filesd++;
                            }
                            catch
                            {
                                deleted -= fi.Length;
                            }
                        }
                    }
                }
            }
            return new Tuple<long, long>(filesd, deleted);
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
            return safenames;
        }
    }
}
