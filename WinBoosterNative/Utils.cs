using Gameloop.Vdf;
using Gameloop.Vdf.JsonConverter;
using Gameloop.Vdf.Linq;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace WinBooster.Native
{
    public class Utils
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
            string steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "Nothing");
            if (string.IsNullOrEmpty(steamdir) || steamdir == "Nothing")
            {
                steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", "Nothing");
                return new DirectoryInfo(steamdir);
            }
            else if (Directory.Exists("C:\\Program Files (x86)\\Steam"))
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
        /* Steam ID текущего пользователя */
        public static string CurrentUserSteamID
        {
            get
            {
                var authserver = (long.Parse(CurrentUserSteamID64) - 76561197960265728) & 1;
                var authid = (long.Parse(CurrentUserSteamID64) - 76561197960265728 - authserver) / 2;
                return $"STEAM_0:{authserver}:{authid}";
            }
        }
        /* Steam ID32 текущего пользователя */
        public static string CurrentUserSteamID32
        {
            get
            {
                return (long.Parse(CurrentUserSteamID64.Substring(3)) - 61197960265728).ToString();
            }
        }
        /* Steam ID64 текущего пользователя */
        public static string CurrentUserSteamID64
        {
            get
            {
                try
                {
                    VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(FindSteamDirectory().FullName + "\\config\\loginusers.vdf"));
                    JProperty importantJsonObject = volvo.ToJson();
                    var accounts = importantJsonObject.Value;
                    foreach (var v1 in accounts)
                    {
                        var recent = v1.Children();
                        foreach (var v2 in recent)
                        {
                            if (v2.Children().ElementAt(3).First.ToString() == "1")
                            {
                                return v1.Path.ToString().Substring(6);
                            }
                        }
                    }
                }
                catch { }
                return "";
            }
        }
        /* Steam логин текущего пользователя */
        public static string CurrentUserAccountLogin
        {
            get
            {
                try
                {
                    VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(FindSteamDirectory().FullName + "\\config\\loginusers.vdf"));
                    JProperty importantJsonObject = volvo.ToJson();
                    var accounts = importantJsonObject.Value;
                    foreach (var v1 in accounts)
                    {
                        var recent = v1.Children();
                        foreach (var v2 in recent)
                        {
                            if (v2.Children().ElementAt(3).First.ToString() == "1")
                            {
                                return v2.Children().ElementAt(0).First.ToString();
                            }
                        }
                    }
                }
                catch { }
                return "";
            }
        }
        /* Steam ник текущего пользователя */
        public static string CurrentUserNickname
        {
            get
            {
                try
                {
                    VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(FindSteamDirectory().FullName + "\\config\\loginusers.vdf"));
                    JProperty importantJsonObject = volvo.ToJson();
                    var accounts = importantJsonObject.Value;
                    foreach (var v1 in accounts)
                    {
                        var recent = v1.Children();
                        foreach (var v2 in recent)
                        {
                            if (v2.Children().ElementAt(3).First.ToString() == "1")
                            {
                                return v2.Children().ElementAt(1).First.ToString();
                            }
                        }
                    }
                }
                catch { }
                return "";
            }
        }
    }
}
