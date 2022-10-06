using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.FakeForms;

namespace WinBooster
{
    internal static class Program
    {
        public static string version = "1.0.4.2";

        public static Settings settings = new Settings();
        public static Statistic statistic = new Statistic();

        public static string settings_path = Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\Settings.json";
        public static string statistic_path = Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\Statistic.json";

        public static Tuple<bool, string> NeedUpdate = new Tuple<bool, string>(false, "");
        public static bool UpdateChecked = false;

        public static UpdateChecker updateChecker = new UpdateChecker();

        public static MainMenu form;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Task.Factory.StartNew(() =>
            {
                NeedUpdate = updateChecker.CheckUpdate();
                UpdateChecked = true;
            });
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster");
            }
            form = new MainMenu();
            settings = Settings.Load(settings_path);
            statistic = Statistic.Load(statistic_path);
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
