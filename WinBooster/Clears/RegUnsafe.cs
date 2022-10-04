using Microsoft.Win32;

namespace WinBooster.Clears
{
    public class RegUnsafe : WorkingI
    {
        public long Work()
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
            #endregion

            return removed;
        }
    }
}
