using DevExpress.Utils.Extensions;
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
            
        }
        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!guna2CheckBox5.Checked && !guna2CheckBox2.Checked)
                guna2GroupBox2.Visible = guna2CheckBox2.Checked;
            if (guna2CheckBox2.Checked)
            {
                guna2CheckBox5.Checked = true;
            }
        }

        private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox4.Checked)
            {
                guna2CheckBox5.Checked = true;
                guna2GroupBox2.Visible = true;
                guna2CheckBox2.Checked = true;
            }
        }

        private void guna2CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox5.Checked)
                guna2CheckBox2.Checked = true;
            if (guna2CheckBox5.Checked)
            {
                guna2GroupBox2.Visible = true;
            }
            if (!guna2CheckBox5.Checked && !guna2CheckBox2.Checked)
                guna2GroupBox2.Visible = guna2CheckBox2.Checked;
        }

        private void Cleaner_Load(object sender, EventArgs e)
        {
            
        }

        private async void guna2Button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                guna2CheckBox1.Checked = true;
                guna2CheckBox2.Checked = true;
                guna2CheckBox3.Checked = true;
                guna2CheckBox4.Checked = true;
                guna2CheckBox5.Checked = true;
            }
            else if (e.Button == MouseButtons.Left)
            {
                guna2Button1.Invoke(new MethodInvoker(() =>
                {
                    guna2Button1.Enabled = false;
                    guna2CheckBox1.Enabled = false;
                    guna2CheckBox2.Enabled = false;
                    guna2CheckBox3.Enabled = false;
                    guna2CheckBox4.Enabled = false;
                    guna2CheckBox5.Enabled = false;
                }));
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
                        if (guna2ComboBox1.SelectedIndex == 1)
                        {
                            RegUnsafe regUnsafe = new RegUnsafe();
                            removed += regUnsafe.Work();
                        }
                        guna2CheckBox5.Invoke(new MethodInvoker(() =>
                        {
                            guna2CheckBox5.Checked = false;
                        }));
                    }
                });

                await t1;
                await t2;
                await t3;
                await t4;
                await t5;
                guna2Button1.Invoke(new MethodInvoker(() =>
                {
                    guna2Button1.Enabled = true;
                    guna2CheckBox1.Enabled = true;
                    guna2CheckBox2.Enabled = true;
                    guna2CheckBox3.Enabled = true;
                    guna2CheckBox4.Enabled = true;
                    guna2CheckBox5.Enabled = true;
                }));
                var item = toastNotificationsManager1.YieldArray().First();
                var item2 = item.Notifications.First();
                item2.Header = "Очистка";
                item2.Body = "Удалено: " + Utils.GetStringSize(removed);
                toastNotificationsManager1.ShowNotification(item2.ID);
            }
        }
    }
}
