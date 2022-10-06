using Microsoft.Win32;
using System.IO;

namespace WinBooster.Fixer.Fixes
{
    public class AutoRun : FixerI
    {
        public void Fix()
        {
            const string pathRegistryKeyStartup = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            using (RegistryKey registryKeyStartup = Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                string[] names = registryKeyStartup.GetValueNames();
                foreach (string name in names)
                {
                    string value = registryKeyStartup.GetValue(name).ToString();
                    string regString = value.Replace("\"", "");

                    regString = regString.ToLower();

                    int splitIndex = regString.IndexOf(".exe");

                    if (splitIndex != -1)
                    {
                        splitIndex += ".exe".Length;
                        string executable = regString.Substring(0, splitIndex);
                        if (!File.Exists(executable))
                        {
                            registryKeyStartup.DeleteValue(name);
                        }
                        string parameters = regString.Substring(splitIndex, regString.Length - splitIndex);

                    }
                }
            }
        }

        public bool NeedFix()
        {
            const string pathRegistryKeyStartup = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            
            using (RegistryKey registryKeyStartup = Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                string[] names = registryKeyStartup.GetValueNames();
                foreach (string name in names) 
                {
                    string value = registryKeyStartup.GetValue(name).ToString();
                    string regString = value.Replace("\"", "");

                    regString = regString.ToLower();

                    int splitIndex = regString.IndexOf(".exe");

                    if (splitIndex != -1)
                    {
                        splitIndex += ".exe".Length;

                        string executable = regString.Substring(0, splitIndex);
                        if (!File.Exists(executable))
                        {
                            return true;
                        }

                        string parameters = regString.Substring(splitIndex, regString.Length - splitIndex);

                    }
                }
            }
            return false;
        }
    }
}
