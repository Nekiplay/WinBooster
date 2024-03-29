﻿using DevExpress.Utils.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBooster.Native;
using WinBooster.DataBase;
using WinBooster.Data;

namespace WinBooster
{
    public partial class FixerForm : Form
    {
        public FixerForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int fixes = 0;
            var scripts = MainMenu.charpManager.plugins;
            foreach (var script in scripts)
            {
                script.OnErrorFixerStart();
            }
            foreach (FixerI fixer in FixerData.fixers)
            {
                if (fixer.NeedFix())
                {
                    fixer.Fix();
                    fixes++;
                }
            }
            foreach (var script in scripts)
            {
                script.OnErrorFixerDone();
            }
            SaveAndLoad.statistic.TotalFixes += fixes;
            SaveAndLoad.statistic.Save(SaveAndLoad.statistic_path);

            var item = toastNotificationsManager1.YieldArray().First();
            var item2 = item.Notifications.First();
            item2.Header = "Error correction";
            item2.Body = "Fixed errors: " + fixes;
            toastNotificationsManager1.ShowNotification(item2.ID);
            Program.form.statistic.UpdateUI();
        }
    }
}
