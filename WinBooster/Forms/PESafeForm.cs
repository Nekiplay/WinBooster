using DevExpress.Utils.Extensions;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinBooster.Data;
using WinBooster.DataBase;

namespace WinBooster.Forms
{
    public partial class PESafeForm : Form
    {
        public PESafeForm()
        {
            InitializeComponent();
        }
        public void UpdateUI()
        {
            int files = 0;
            int non_files = 0;
            foreach (var pe in Program.PEData.data.ToArray())
            {
                if (!File.Exists(pe.FileName + pe.Extension))
                {
                    files++;
                }
                else
                {
                    non_files++;
                }
            }
            var t = Program.PEData.data.ToArray().Count() - non_files;
            label1.Invoke(new MethodInvoker(() =>
            {
                label1.Text = "Encrypted files: " + t + "/" + Program.PEData.data.ToArray().Count();
            }));
        }
        private void PESafeForm_Load(object sender, EventArgs e)
        {
            foreach (var pe in Program.PEData.data)
            {
                Program.form.PeSafeForm.guna2ComboBox1.Items.Add(pe.Name);
            }
            UpdateUI();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PE_Safe.AddNewPE addNewPE = new PE_Safe.AddNewPE();
            addNewPE.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem != null)
            {
                guna2Button2.Invoke(new MethodInvoker(() =>
                {
                    guna2Button2.Enabled = false;
                }));
                string name = guna2ComboBox1.SelectedItem.ToString();
                foreach (var pe in Program.PEData.data.ToArray())
                {
                    if (pe.Name == name)
                    {
                        try
                        {
                            if (File.Exists(pe.FileName + pe.Extension))
                            {
                                File.Delete(pe.FileName + pe.Extension);
                            }
                            File.Delete(pe.FileName);
                            Program.PEData.data.Remove(pe);
                            guna2ComboBox1.Items.Remove(name);
                            Program.PEData.Save();
                        }
                        catch { }
                        break;
                    }
                }
                guna2Button2.Invoke(new MethodInvoker(() =>
                {
                    guna2Button2.Enabled = true;
                }));
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                guna2Button3.Invoke(new MethodInvoker(() =>
                {
                    guna2Button3.Enabled = false;
                }));
                if (guna2ComboBox1.SelectedItem != null)
                {
                    string name = guna2ComboBox1.SelectedItem.ToString();
                    foreach (var pe in Program.PEData.data.ToArray())
                    {
                        if (pe.Name == name)
                        {
                            if (!File.Exists(pe.FileName + pe.Extension))
                            {
                                WinBoosterNative.Security.AES.SharpAESCrypt.Decrypt(Program.GetCPUID(), pe.FileName, pe.FileName + pe.Extension);
                            }
                            Process process = new Process();
                            process.StartInfo.FileName = pe.FileName + pe.Extension;
                            process.StartInfo.WorkingDirectory = "C:\\ProgramData\\WinBooster\\PE Safe\\Files";
                            process.Start();
                            guna2Button3.Invoke(new MethodInvoker(() =>
                            {
                                guna2Button3.Enabled = true;
                            }));
                            UpdateUI();
                            break;
                        }
                    }
                }
            });
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            int files = 0;
            int non_files = 0;
            foreach (var pe in Program.PEData.data.ToArray())
            {
                if (File.Exists(pe.FileName + pe.Extension))
                {
                    try { File.Delete(pe.FileName + pe.Extension); } catch { }
                }
            }
            foreach (var pe in Program.PEData.data.ToArray())
            {
                if (!File.Exists(pe.FileName + pe.Extension))
                {
                    files++;
                }
                else
                {
                    non_files++;
                }
            }
            UpdateUI();
            var item = toastNotificationsManager1.YieldArray().First();
            var item2 = item.Notifications.First();
            item2.Header = "PE Safe";
            var t = Program.PEData.data.ToArray().Count() - non_files;
            item2.Body = "Encrypted: " + t + "/" + Program.PEData.data.ToArray().Count();
            toastNotificationsManager1.ShowNotification(item2.ID);
        }
    }
}
