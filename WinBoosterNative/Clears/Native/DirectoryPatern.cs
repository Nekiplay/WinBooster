using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WinBooster.Native
{
    public class DirectoryPatern : WorkingI
    {
        public string directory;
        public string patern;
        public DirectoryPatern(string dir, string patern)
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
            this.directory = dir;
            this.patern = patern;
        }
        private long WorkInSoloDir(string dirpath)
        {
            long deleted = 0;
            if (Directory.Exists(dirpath))
            {
                var files = Directory.GetFiles(dirpath, patern);
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
            return deleted;
        }
        public long Work()
        {
            long deleted = 0;
            if (directory.Contains("%unknowfolder%"))
            {
                var reg = Regex.Match(directory, "(.*)%unknowfolder%(.*)");
                if (reg.Success)
                {
                    string first = reg.Groups[1].Value;
                    if (Directory.Exists(first))
                    {
                        string last = reg.Groups[2].Value;
                        var dirs = Directory.GetDirectories(first);
                        foreach (var dir2 in dirs)
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(dir2);
                            deleted += WorkInSoloDir(first + directoryInfo.Name + last);
                        }
                    }
                }
                else
                {
                    var reg2 = Regex.Match(directory, "(.*)%unknowfolder%");
                    if (reg2.Success)
                    {
                        string first = reg2.Groups[1].Value;
                        if (Directory.Exists(first))
                        {
                            var dirs = Directory.GetDirectories(first);
                            foreach (var dir2 in dirs)
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(dir2);
                                deleted += WorkInSoloDir(first + directoryInfo.Name);
                            }
                        }
                    }
                }
            }
            else
            {
                deleted += WorkInSoloDir(directory);
            }
            return deleted;
        }

        public string GetDirectory()
        {
            return directory;
        }

        public string GetPattern()
        {
            return patern;
        }
        public List<string> GetSafeNames()
        {
            return new List<string>();
        }
    }
}
