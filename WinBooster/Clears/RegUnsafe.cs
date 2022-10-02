using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            catch { }
            #endregion

            return removed;
        }
    }
}
