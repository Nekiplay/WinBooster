using System;
using System.IO;
using System.Management;
using System.Windows.Forms;
using WinBooster.Data;
using WinBooster.FakeForms;
using WinBooster.Native;

namespace WinBooster
{
    internal static class Program
    {
        public static string version = "1.0.4.4.5.4";

        public static Tuple<bool, string> NeedUpdate = new Tuple<bool, string>(false, "");
        public static bool UpdateChecked = false;

        public static string GetCPUID()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo.Properties["processorID"].Value != null)
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        public static UpdateChecker updateChecker = new UpdateChecker();

        public static MainMenu form;
        [STAThread]
        static void Main()
        {
            Console.WriteLine(GetCPUID());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster");
            }
            form = new MainMenu();
            SaveAndLoad.settings = Settings.Load(SaveAndLoad.settings_path);
            SaveAndLoad.statistic = Statistic.Load(SaveAndLoad.statistic_path);
            SaveAndLoad.premiumFeatures = PremiumFeatures.Load(SaveAndLoad.premiumFeatures_path);
            if (SaveAndLoad.settings.FakeMenu == 1)
            {
                Application.Run(new SMS_Bomber());
            }
            else
            {
                Application.Run(form);
            }
        }
    }
}
