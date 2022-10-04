using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.FakeForms;

namespace WinBooster
{
    internal static class Program
    {
        public static Settings settings = new Settings();
        public static string settings_path = Utils.GetSysDrive() + "\\ProgramData\\WinBooster.json";
        public static Form1 form;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form1();
            settings = Settings.Load(settings_path);
            Console.WriteLine(settings.FakeMenu);
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
