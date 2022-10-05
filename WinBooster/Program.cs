using System;
using System.IO;
using System.Windows.Forms;
using WinBooster.FakeForms;

namespace WinBooster
{
    internal static class Program
    {
        public static string version = "1.0.4.0";
        public static Settings settings = new Settings();
        public static Statistic statistic = new Statistic();
        public static string settings_path = Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\Settings.json";
        public static string statistic_path = Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\Statistic.json";
        public static MainMenu form;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster");
            }
            form = new MainMenu();
            settings = Settings.Load(settings_path);
            statistic = Statistic.Load(statistic_path);
            Console.WriteLine(statistic.TotalSizeClear);
            if (settings.FakeMenu == 1)
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
