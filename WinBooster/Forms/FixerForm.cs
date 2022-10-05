using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Fixer;

namespace WinBooster
{
    public partial class FixerForm : Form
    {
        public FixerData fixerData = new FixerData();
        public FixerForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int fixes = 0;
            foreach (FixerI fixer in fixerData.fixers)
            {
                if (fixer.NeedFix())
                {
                    Console.WriteLine(fixer.ToString());
                    fixer.Fix();
                    fixes++;
                }
            }
            Program.statistic.TotalFixes += fixes;
            Program.statistic.Save(Program.statistic_path);

            var item = toastNotificationsManager1.YieldArray().First();
            var item2 = item.Notifications.First();
            item2.Header = "Исправления";
            item2.Body = "Исправлено ошибок: " + fixes;
            toastNotificationsManager1.ShowNotification(item2.ID);
            Program.form.statistic.UpdateUI();
        }
    }
}
