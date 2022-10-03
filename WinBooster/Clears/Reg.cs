using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster.Clears
{
    public class Reg : WorkingI
    {
        public long Work()
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
            }
            catch { }
            #endregion

            #region LastActivity
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32", true);
                try
                {
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
                } catch { }
                try
                {
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
                }
                catch { }
                try
                {
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
                }
                catch { }
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
                    }
                    catch
                    {

                    }
                }
            }
            catch { }
            #endregion

            #region NeverLose
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                CurrentUserSoftware.DeleteSubKeyTree("neverlose");
            }
            catch { }
            #endregion

            #region Akrien
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\RADAR\\HeapLeakDetection\\DiagnosedApplications", true);
                CurrentUserSoftware.DeleteSubKeyTree("AkrienPremiumLoader.exe");
            }
            catch { }
            #endregion

            return removed;
        }
    }
}
