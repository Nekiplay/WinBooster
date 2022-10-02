﻿using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Clears;

namespace WinBooster
{
    public partial class Cleaner : Form
    {
        public Cleaner()
        {
            InitializeComponent();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            long removed = 0;
            Files files = new Files();
            Task t1 = Task.Factory.StartNew(() =>
            {
                if (guna2CheckBox1.Checked)
                {
                    foreach (WorkingI log in files.logs)
                    {
                        removed += log.Work();
                    }
                    guna2CheckBox1.Invoke(new MethodInvoker(() =>
                    {
                        guna2CheckBox1.Checked = false;
                    }));
                }
            });
            Task t2 = Task.Factory.StartNew(() =>
            {
                if (guna2CheckBox3.Checked)
                {
                    foreach (WorkingI log in files.cache)
                    {
                        removed += log.Work();
                    }
                    guna2CheckBox3.Invoke(new MethodInvoker(() =>
                    {
                        guna2CheckBox3.Checked = false;
                    }));
                }
            });
            Task t3 = Task.Factory.StartNew(() =>
            {
                if (guna2CheckBox4.Checked)
                {
                    foreach (WorkingI log in files.cheats)
                    {
                        removed += log.Work();
                    }
                    guna2CheckBox4.Invoke(new MethodInvoker(() =>
                    {
                        guna2CheckBox4.Checked = false;
                    }));
                }
            });
            Task t4 = Task.Factory.StartNew(() =>
            {
                if (guna2CheckBox2.Checked)
                {
                    Console.WriteLine(guna2ComboBox1.SelectedIndex);
                    if (guna2ComboBox1.SelectedIndex == 0)
                    {
                        foreach (WorkingI log in files.lastactivity_unsafe)
                        {
                            removed += log.Work();
                        }
                    }
                    else if (guna2ComboBox1.SelectedIndex == 1)
                    {
                        foreach (WorkingI log in files.lastactivity_full)
                        {
                            removed += log.Work();
                        }
                    }
                    guna2CheckBox2.Invoke(new MethodInvoker(() =>
                    {
                        guna2CheckBox2.Checked = false;
                    }));
                }
            });
            Task t5 = Task.Factory.StartNew(() =>
            {
                if (guna2CheckBox5.Checked)
                {
                    Reg reg = new Reg();
                    removed += reg.Work();
                }
            });

            await t1;
            await t2;
            await t3;
            await t4;
            await t5;
            var item = toastNotificationsManager1.YieldArray().First();
            var item2 = item.Notifications.First();
            item2.Header = "Очистка";
            item2.Body = "Удалено: " + Utils.GetStringSize(removed);
            toastNotificationsManager1.ShowNotification(item2.ID);
        }
        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            guna2GroupBox2.Visible = guna2CheckBox2.Checked;
            if (guna2CheckBox2.Checked)
            {
                guna2CheckBox5.Checked = true;
            }
        }
    }
}
