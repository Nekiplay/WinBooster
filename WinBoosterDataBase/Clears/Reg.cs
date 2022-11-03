using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using WinBooster.Native;

namespace WinBooster.DataBase
{
    public class Reg : WorkingI
    {
        public string GetDirectory()
        {
            return "";
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
            long removed = 0;

            #region Enigma Virtual Box
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                var enigma_virtual_box = CurrentUserSoftware.OpenSubKey("Enigma Virtual Box", true);
                try
                {
                    var enigma_virtual_box2 = enigma_virtual_box.OpenSubKey("History");
                    var val = enigma_virtual_box2.GetValue("History0").ToString();
                    removed += val.Length;
                }
                catch { }
                CurrentUserSoftware.DeleteSubKeyTree("Enigma Virtual Box");
                CurrentUserSoftware.Close();
                enigma_virtual_box.Close();
            }
            catch { }
            #endregion

            #region LastActivity
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32", true);
                var c1 = CurrentUserSoftware.OpenSubKey("CIDSizeMRU", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int i))
                    {
                        var b = (byte[])c1.GetValue(value);
                        removed += b.Length;
                        c1.DeleteValue(value);
                    }
                }
                CurrentUserSoftware.Close();
                c1.Close();
            } 
            catch { }
            try
            {
                var c1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU\\exe", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int i))
                    {
                        var b = (byte[])c1.GetValue(value);
                        removed += b.Length;
                        c1.DeleteValue(value);
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var c1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU\\*", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int i))
                    {
                        var b = (byte[])c1.GetValue(value);
                        removed += b.Length;
                        c1.DeleteValue(value);
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var c1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU\\rar", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int i))
                    {
                        var b = (byte[])c1.GetValue(value);
                        removed += b.Length;
                        c1.DeleteValue(value);
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var c1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU\\zip", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int i))
                    {
                        var b = (byte[])c1.GetValue(value);
                        removed += b.Length;
                        c1.DeleteValue(value);
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32", true);
                var c1 = CurrentUserSoftware.OpenSubKey("LastVisitedPidlMRU", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int i))
                    {
                        var b = (byte[])c1.GetValue(value);
                        removed += b.Length;
                        c1.DeleteValue(value);
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32", true);
                var c1 = CurrentUserSoftware.OpenSubKey("LastVisitedPidlMRULegacy", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int i))
                    {
                        var b = (byte[])c1.GetValue(value);
                        removed += b.Length;
                        c1.DeleteValue(value);
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var c1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", true);
                var values = c1.GetValueNames();
                foreach (var value in values)
                {
                    if (File.Exists(value))
                    {
                        FileInfo f = new FileInfo(value);
                        if (!new SafeNames().names.Contains(f.Name))
                        {
                            var b = c1.GetValue(value).ToString().Length;
                            removed += b;
                            c1.DeleteValue(value);
                        }
                    }
                    else
                    {
                        if (!new SafeNames().names.Contains(value))
                        {
                            var b = c1.GetValue(value).ToString().Length;
                            removed += b;
                            c1.DeleteValue(value);
                        }
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var c1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RecentDocs", true);
                var values = c1.GetSubKeyNames();
                foreach (var value in values)
                {
                    var c2 = c1.OpenSubKey(value, true);
                    foreach (var value2 in c2.GetValueNames())
                    {
                        if (int.TryParse(value2, out int i))
                        {
                            var b = (byte[])c2.GetValue(value2);
                            removed += b.Length;
                            c2.DeleteValue(value2);
                        }
                    }
                }
                c1.Close();
            }
            catch { }
            try
            {
                var c1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RecentDocs", true);
                foreach (var value2 in c1.GetValueNames())
                {
                    if (int.TryParse(value2, out int i))
                    {
                        var b = (byte[])c1.GetValue(value2);
                        removed += b.Length;
                        c1.DeleteValue(value2);
                    }
                }
                c1.Close();
            }
            catch { }
            #endregion

            #region WinRAR
            try
            {
                var usersReg = Registry.Users;
                var users = usersReg.GetSubKeyNames();
                foreach (var user in users)
                {
                    try
                    {
                        var k = usersReg.OpenSubKey(user + "\\SOFTWARE\\WinRAR\\DialogEditHistory\\ArcName", true);
                        foreach (string value in k.GetValueNames())
                        {
                            k.DeleteValue(value);
                        }
                        k.Close();
                    }
                    catch
                    {

                    }
                }
                usersReg.Close();
            }
            catch { }
            try
            {
                var usersReg = Registry.CurrentUser;
                var k = usersReg.OpenSubKey("SOFTWARE\\WinRAR\\ArcHistory", true);
                foreach (var v in k.GetValueNames())
                {
                    removed += k.GetValue(v).ToString().Length;
                    k.DeleteValue(v);
                }
                usersReg.Close();
            }
            catch { }
            #endregion

            #region NeverLose
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                CurrentUserSoftware.DeleteSubKeyTree("neverlose");
                CurrentUserSoftware.Close();
            }
            catch { }
            #endregion

            #region Akrien
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\RADAR\\HeapLeakDetection\\DiagnosedApplications", true);
                CurrentUserSoftware.DeleteSubKeyTree("AkrienPremiumLoader.exe");
                CurrentUserSoftware.Close();
            }
            catch { }
            #endregion

            #region Notepad
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Notepad", true);
                CurrentUserSoftware.SetValue("searchString", "");
                CurrentUserSoftware.SetValue("replaceString", "");
                CurrentUserSoftware.Close();
            }
            catch { }
            #endregion

            #region RadminVPN
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Famatech\\Radmin VPN\\ui\\JoinWindow", true);
                CurrentUserSoftware.SetValue("Search", "");
                CurrentUserSoftware.Close();
            }
            catch { }
            #endregion

            return new Tuple<long, long>(0, removed);
        }
    }
}
