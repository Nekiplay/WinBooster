using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public static string version = "1.0.4.4.5.9";

        public static PEData PEData = new PEData();

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


        public static WinBoosterQIWI.QIWI.Donation donation = new WinBoosterQIWI.QIWI.Donation("cc25973f-d2b7-45e2-b1e3-7370c08bc145", onDonation, true);

        public static void onDonation(WinBoosterQIWI.QIWI.Donation.Event donate)
        {
            if (donate.attributes.DONATION_SENDER == GetCPUID())
            {
                
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster");
            }
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe");
            }
            if (File.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Data.bin"))
            {
                string text = File.ReadAllText(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Data.bin");
                text = new WinBoosterNative.Security.Rijn.StringProtector(GetCPUID()).Decrypt(text);
                PEData = JsonConvert.DeserializeObject<PEData>(text);
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
