using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            Task.Factory.StartNew(() =>
            {
                var result = Program.updateChecker.CheckUpdate();
                label6.Invoke(new MethodInvoker(() =>
                {
                    if (result.Item1)
                    {
                        label6.Text = "Last version: " + result.Item2;
                    }
                    else
                    {
                        label6.Text = "Last version: " + Program.version;
                    }
                }));
            });
            if (SaveAndLoad.premiumFeatures.MoreFakeMenus)
            {
                //Program.form.settings.morefakemenusCheckbox.Checked = true;
            }
            guna2ComboBox1.SelectedIndex = SaveAndLoad.settings.FakeMenu;
            guna2TextBox1.Text = SaveAndLoad.settings.Password;
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

        private void cheatsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //if (SaveAndLoad.premiumFeatures.MoreFakeMenus == false && morefakemenusCheckbox.Checked)
            //{
            //    morefakemenusCheckbox.Invoke(new MethodInvoker(() =>
            //    {
            //        morefakemenusCheckbox.Checked = false;
            //        morefakemenusCheckbox.Enabled = false;
            //    }));
            //    string link = Program.donation.GetDonateLink("Neki_play1", Program.GetCPUID(), "More fake menu", 25);
            //    System.Diagnostics.Process.Start(link);
            //    morefakemenusCheckbox.Invoke(new MethodInvoker(() =>
            //    {
            //        morefakemenusCheckbox.Checked = false;
            //        morefakemenusCheckbox.Enabled = true;
            //    }));
            //}
            //else if (SaveAndLoad.premiumFeatures.MoreFakeMenus)
            //{
            //    morefakemenusCheckbox.Invoke(new MethodInvoker(() =>
            //    {
            //        morefakemenusCheckbox.Checked = true;
            //    }));
            //}
        }
    }
}
