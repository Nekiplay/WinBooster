using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

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

            directory = dir;
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
        private Tuple<long, long> WorkInSoloDir(string dirpath)
        {
            DirectoryInfo info = new DirectoryInfo(dirpath);
            long size = 0;
            long files = 0;
            if (info.Exists)
            {
                var info1 = Utils.CustomDirInfo(info);
                files = info1.files;
                size = info1.size;
                try { Directory.Delete(dirpath, true); } catch { }
                DirectoryInfo info2 = new DirectoryInfo(dirpath);
                info1 = Utils.CustomDirInfo(info);
                files -= info1.files;
                size -= info1.size;
            }
            return new Tuple<long, long>(files, size);
        }
        public Tuple<long, long> Work()
        {
            long files = 0;
            long deleted = 0;
            if (directory.Contains("%unknowfolder%"))
            {
                try
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
                                var a = WorkInSoloDir(first + directoryInfo.Name + last);
                                files += a.Item1;
                                deleted += a.Item2;
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
                                    var a = WorkInSoloDir(first + directoryInfo.Name);
                                    files += a.Item1;
                                    deleted += a.Item2;
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    var a = WorkInSoloDir(directory);
                    files = a.Item1;
                    deleted += a.Item2;
                }
                catch { }
            }
            return new Tuple<long, long>(0, 0);
        }
    }
}
