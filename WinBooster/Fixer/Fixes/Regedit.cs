using Microsoft.Win32;

namespace WinBooster.Fixer.Fixes
{
    public class Regedit : FixerI
    {
        public void Fix()
        {
            RegistryKey regkey;
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.DeleteValue("DisableRegistryTools");
                regkey.Close();
            }
            catch { }
        }

        public bool NeedFix()
        {
            RegistryKey regkey;
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                var value = regkey.GetValue("DisableRegistryTools");
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
