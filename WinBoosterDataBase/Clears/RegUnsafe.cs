using Microsoft.Win32;
using System;
using System.Collections.Generic;
using WinBooster.Native;

namespace WinBooster.DataBase
{
    public class RegUnsafe : WorkingI
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

            #region LastActivity
            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell", true);
                try
                {
                    CurrentUserSoftware.DeleteSubKeyTree("BagMRU");
                }
                catch { }
                try
                {
                    CurrentUserSoftware.DeleteSubKeyTree("Bags");
                }
                catch { }
                CurrentUserSoftware.Close();
            }
            catch { }

            try
            {
                var CurrentUserSoftware = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage", true);
                try
                {
                    CurrentUserSoftware.DeleteSubKeyTree("AppSwitchedl");
                }
                catch { }
                CurrentUserSoftware.Close();
            }
            catch { }
            try
            {
                var CurrentUserSoftware = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\RADAR\\HeapLeakDetection\\DiagnosedApplications", true);
                string[] names = CurrentUserSoftware.GetSubKeyNames();
                foreach (var name in names)
                {
                    CurrentUserSoftware.DeleteSubKeyTree(name);
                }
                CurrentUserSoftware.Close();
            }
            catch { }
            #endregion

            return new Tuple<long, long>(0, removed);
        }
    }
}
