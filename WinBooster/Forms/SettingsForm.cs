using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Data;

namespace WinBooster
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Task version_checker = new Task(() =>
            {
                bool done = false;
                int i = 0;
                Task animation = new Task(() =>
                {
                    while (!done)
                    {
                        linkLabel4.Invoke(new MethodInvoker(() =>
                        {
                            if (i == 0)
                            {
                                linkLabel4.Text = "Checking.";
                                i = 1;
                            }
                            else if (i == 1)
                            {
                                linkLabel4.Text = "Checking..";
                                i = 2;
                            }
                            else if (i == 2)
                            {
                                linkLabel4.Text = "Checking...";
                                i = 0;
                            }
                        }));
                        Thread.Sleep(150);
                    }
                });
                animation.Start();
                Thread.Sleep(2150);
                var result = Program.updateChecker.CheckUpdate();
                done = true;
                linkLabel4.Invoke(new MethodInvoker(() =>
                {
                    if (result.Item1)
                    {
                        linkLabel4.Text =  result.Item2;
                    }
                    else
                    {
                        linkLabel4.Text = Program.version;
                    }
                }));
            });
            Task setting_loader = new Task(() =>
            {
                guna2TextBox2.Invoke(new MethodInvoker(() =>
                {
                    guna2TextBox2.Text = Program.GetCPUID();
                }));
                guna2ComboBox1.Invoke(new MethodInvoker(() =>
                {
                    guna2ComboBox1.SelectedIndex = SaveAndLoad.settings.FakeMenu;
                }));
                guna2TextBox1.Invoke(new MethodInvoker(() =>
                {
                    guna2TextBox1.Text = SaveAndLoad.settings.Password;
                }));
            });
            version_checker.Start();
            setting_loader.Start();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            SaveAndLoad.settings.Password = guna2TextBox1.Text;
            SaveAndLoad.settings.Save(SaveAndLoad.settings_path);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveAndLoad.settings.FakeMenu = guna2ComboBox1.SelectedIndex;
            SaveAndLoad.settings.Save(SaveAndLoad.settings_path);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://brokencore.club/resources/4279");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Nekiplay/WinBooster");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://skillshop.gitbook.io/winbooster");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/neki_play");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/nekiplay");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://brokencore.club/resources/4279");
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {

        }

        private void registryCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void photoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveAndLoad.premiumFeatures.MoreFakeMenu)
            {
                if (photoCheckbox.Checked)
                {
                    photoCheckbox.Checked = false;
                    photoCheckbox.Enabled = false;
                    string link = Program.donation.GetDonateLink("Neki_play1", Program.GetCPUID(), "WinBooster - More fake menus", 75);
                    Process.Start(link);
                    Task.Factory.StartNew(() =>
                    {
                        Task.Delay(2500);
                        photoCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            photoCheckbox.Enabled = true;
                        }));
                    });
                }
            }
            else
            {
                photoCheckbox.Checked = true;
            }
        }
    }
}
