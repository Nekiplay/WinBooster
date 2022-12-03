using Gameloop.Vdf;
using Gameloop.Vdf.JsonConverter;
using Gameloop.Vdf.Linq;
using MediaDevices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using WinBoosterNative;

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
            try
            {
                string steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "Nothing");
                if (string.IsNullOrEmpty(steamdir) || steamdir == "Nothing")
                {
                    steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", "Nothing");
                    return new DirectoryInfo(steamdir);
                }
            }
            catch { }
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
        public static Bitmap ChangeImageColor(Bitmap scrBitmap, Color newColor)
        {
            //You can change your new color here. Red,Green,LawnGreen any..
            Color actualColor;
            //make an empty bitmap the same size as scrBitmap
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    //get the pixel from the scrBitmap image
                    actualColor = scrBitmap.GetPixel(i, j);
                    // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
                    if (actualColor.A > 150)
                        newBitmap.SetPixel(i, j, newColor);
                    else
                        newBitmap.SetPixel(i, j, actualColor);
                }
            }
            return newBitmap;
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
        public static CustomDirectoryInfo CustomDirInfo(DirectoryInfo d)
        {
            CustomDirectoryInfo customDirectoryInfo = new CustomDirectoryInfo();
            customDirectoryInfo.size = 0;
            customDirectoryInfo.files = 0;

            if (d.Exists)
            {
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    customDirectoryInfo.size += fi.Length;
                    customDirectoryInfo.files += 1;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    var a = CustomDirInfo(di);
                    customDirectoryInfo.size += a.size;
                    customDirectoryInfo.files += a.files;
                }
            }
            return customDirectoryInfo;
        }
        public static CustomDirectoryInfo CustomDirInfo(MediaDevice divece, MediaDirectoryInfo d)
        {
            CustomDirectoryInfo customDirectoryInfo = new CustomDirectoryInfo();
            customDirectoryInfo.size = 0;
            customDirectoryInfo.files = 0;

            var files = divece.GetFiles(d.FullName);
            foreach (string fi in files)
            {
                var i = divece.GetFileInfo(fi);
                customDirectoryInfo.size += (long)i.Length;
                customDirectoryInfo.files += 1;
            }
            var dirs = divece.GetDirectories(d.FullName);
            foreach (string dir in dirs)
            {
                var i = divece.GetDirectoryInfo(dir);
                var temp = CustomDirInfo(divece, i);
                customDirectoryInfo.size += temp.size;
                customDirectoryInfo.files += temp.files;
            }
            return customDirectoryInfo;
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

        public static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
