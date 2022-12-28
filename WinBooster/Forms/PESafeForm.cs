using DevExpress.Utils.Extensions;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
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
using WinBooster.Native;

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
                FileInfo ii = new FileInfo(pe.FileName);
                string filename = ii.Name.Replace(".bin", "");
                if (!Directory.Exists("C:\\ProgramData\\WinBooster\\PE Safe\\Runners\\" + filename))
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
            if (File.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Data.bin"))
            {
                string text = File.ReadAllText(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Data.bin");
                text = new WinBoosterNative.Security.Rijn.StringProtector(Program.GetCPUID()).Decrypt(text);
                Program.PEData = JsonConvert.DeserializeObject<PEData>(text);
            }
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
            await Task.Factory.StartNew(async () =>
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
                            FileInfo ii = new FileInfo(pe.FileName);
                            string filename = ii.Name.Replace(".bin", "");
                            string directory = "C:\\ProgramData\\WinBooster\\PE Safe\\Runners\\" + ii.Name.Replace(".bin", "");
                            Directory.CreateDirectory(directory);
                            if (!File.Exists(directory + "\\" + filename + pe.Extension))
                            {
                                WinBoosterNative.Security.AES.SharpAESCrypt.Decrypt(Program.GetCPUID(), pe.FileName, directory + "\\" + filename + pe.Extension);
                            }
                            await Task.Delay(500);
                            Process p = new Process();
                            p.StartInfo.FileName = directory + "\\" + filename + pe.Extension;
                            if (pe.WorkingDirectory)
                            {
                                p.StartInfo.WorkingDirectory = directory;
                            }
                            p.Start();
                            UpdateUI();
                            guna2Button3.Invoke(new MethodInvoker(() =>
                            {
                                guna2Button3.Enabled = true;
                            }));
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
                FileInfo ii = new FileInfo(pe.FileName);
                string filename = ii.Name.Replace(".bin", "");
                if (Directory.Exists("C:\\ProgramData\\WinBooster\\PE Safe\\Runners\\" + filename))
                {
                    try { Directory.Delete("C:\\ProgramData\\WinBooster\\PE Safe\\Runners\\" + filename, true); } catch { }
                }
            }
            foreach (var pe in Program.PEData.data.ToArray())
            {
                FileInfo ii = new FileInfo(pe.FileName);
                string filename = ii.Name.Replace(".bin", "");
                if (!Directory.Exists("C:\\ProgramData\\WinBooster\\PE Safe\\Runners\\" + filename))
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

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }
    }
}
