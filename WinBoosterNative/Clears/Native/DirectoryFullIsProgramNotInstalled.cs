using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Management;
using WinBooster.Native;

namespace WinBoosterNative.Clears.Native
{
    public class DirectoryFullIsProgramNotInstalled : WorkingI
    {
        public string directory;
        private string name;
        public DirectoryFullIsProgramNotInstalled(string name, string dir)
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
            this.name = name;
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

        public Tuple<long, long> Work()
        {
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product"))
            {
                foreach (ManagementObject mo in mos.Get())
                {
                    if (mo["name"] != null && mo["name"].ToString() == name)
                    {
                        DirectoryInfo info = new DirectoryInfo(directory);
                        long pre = 0;
                        long size = 0;
                        if (info.Exists)
                        {
                            pre = Utils.DirSize(info);
                            size = Utils.DirFileCount(info);
                            try { Directory.Delete(directory, true); } catch { }
                            DirectoryInfo info2 = new DirectoryInfo(directory);
                            long done = Utils.DirSize(info2);
                            size -= Utils.DirFileCount(info2);
                            pre -= done;
                        }
                        return new Tuple<long, long>(size, pre);
                    }
                }
            }
            return new Tuple<long, long>(0, 0);
        }
    }
}
