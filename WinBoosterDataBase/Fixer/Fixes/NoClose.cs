using Microsoft.Win32;
using WinBooster.Native;

namespace WinBoosterDataBase
{
    public class NoClose : FixerI
    {
        public void Fix()
        {
            RegistryKey regkey;
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            try
            {
                regkey = Registry.CurrentUser.OpenSubKey(subKey, true);
                regkey.DeleteValue("NoClose");
                regkey.Close();
            }
            catch { }
        }

        public bool NeedFix()
        {
            RegistryKey regkey;
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            try
            {
                regkey = Registry.CurrentUser.OpenSubKey(subKey, true);
                var value = regkey.GetValue("NoClose");
                if (value.GetType() == typeof(int))
                {
                    int valueInt = (int)value;
                    if (valueInt > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
                regkey.Close();
            }
            catch { }
            return false;
        }
    }
}
