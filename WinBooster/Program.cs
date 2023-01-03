using DevExpress.XtraWaitForm;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WinBooster.Data;
using WinBooster.FakeForms;
using WinBooster.Native;

namespace WinBooster
{
    internal static class Program
    {
        public static string version = "1.0.4.4.7";

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
                if (donate.attributes.DONATION_AMOUNT == 75)
                {
                    SaveAndLoad.premiumFeatures.MoreFakeMenu = true;
                    try
                    {
                        form.settings.Invoke(new MethodInvoker(() =>
                        {
                            form.settings.photoCheckbox.Checked = SaveAndLoad.premiumFeatures.MoreFakeMenu;
                        }));
                    }
                    catch { }
                }
                SaveAndLoad.premiumFeatures.Save(SaveAndLoad.premiumFeatures_path);
            }
        }

        public static Process checker;
        static Process main;
        static int mainProcessID;

        public static bool bdos = false;

        [STAThread]
        private static void Main(string[] args)
        {
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster");
            }
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe");
            }
            if (args.Length == 0)
            {
                #region Downloading "Run As TrustedInstaller"
                if (!File.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunAsTI.exe"))
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadFile("https://github.com/Nekiplay/Temp/raw/main/RunAsTI.exe", Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunAsTI.exe");
                        }
                    }
                    catch
                    {
                        try { File.Delete(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunAsTI.exe"); } catch { }
                    }
                }
                if (!File.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\WinBoosterLauncher.exe"))
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadFile("https://github.com/Nekiplay/Temp/raw/main/WinBoosterLauncher.exe", Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\WinBoosterLauncher.exe");
                        }
                    }
                    catch
                    {
                        try { File.Delete(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\WinBoosterLauncher.exe"); } catch { }
                    }
                }
                #endregion
                if (File.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\RunAsTI.exe") 
                    && File.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\WinBoosterLauncher.exe")) // Checking if need Run as TrustedInstaller
                {
                    #region Process Checker
                    main = Process.GetCurrentProcess();
                    mainProcessID = main.Id;

                    //Initializes the helper process
                    checker = new Process();
                    checker.StartInfo.FileName = main.MainModule.FileName;
                    checker.StartInfo.Arguments = mainProcessID.ToString();

                    checker.EnableRaisingEvents = true;
                    checker.Exited += new EventHandler(checker_Exited);

                    checker.Start();
                    #endregion

                    #region Main program
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    form = new MainMenu();
                    SaveAndLoad.settings = Settings.Load(SaveAndLoad.settings_path);
                    SaveAndLoad.statistic = Statistic.Load(SaveAndLoad.statistic_path);
                    SaveAndLoad.premiumFeatures = PremiumFeatures.Load(SaveAndLoad.premiumFeatures_path);
                    try
                    {
                        form.settings.Invoke(new MethodInvoker(() =>
                        {
                            form.settings.photoCheckbox.Checked = SaveAndLoad.premiumFeatures.MoreFakeMenu;
                        }));
                    }
                    catch { }
                    if (SaveAndLoad.settings.FakeMenu == 2)
                    {
                        Application.Run(new Keypad());
                    }
                    else if (SaveAndLoad.settings.FakeMenu == 1)
                    {
                        Application.Run(new Auth());
                    }
                    else
                    {
                        Application.Run(form);
                    }
                    #endregion
                }
            }
            else if (args.Length == 1)
            {
                main = Process.GetProcessById(int.Parse(args[0]));

                main.EnableRaisingEvents = true;
                main.Exited += new EventHandler(main_Exited);

                while (!main.HasExited)
                {
                    Thread.Sleep(50); //Wait 1 second. 
                }

                //Provide some time to process the main_Exited event. 
                Thread.Sleep(50);
            }
        }

        private static void checker_Exited(object sender, EventArgs e)
        {
            if (bdos)
            {
                Utils.BDOS();
            }
            Process.GetCurrentProcess().Kill();
        }

        private static void main_Exited(object sender, EventArgs e)
        {
            if (bdos)
            {
                Utils.BDOS();
            }
            Process.GetCurrentProcess().Kill();
        }
    }
}
