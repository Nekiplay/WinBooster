using DevExpress.Utils.About;
using DevExpress.Utils.Extensions;
using Guna.UI2.WinForms;
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
using WinBooster.Data;
using WinBooster.DataBase.FilesHashes;
using WinBooster.Native;
using WinBoosterNative.Security;

namespace WinBooster.Forms.PE_Safe
{
    public partial class AddNewPE : Form
    {
        public AddNewPE()
        {
            InitializeComponent();
        }

        private void exitPuctureBix_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        FileInfo file = null;
        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                await Task.Factory.StartNew(() =>
                {
                    string directory = Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Files";
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    string fileName = openFileDialog.FileName;
                    FileInfo fileInfo = new FileInfo(fileName);
                    this.file = fileInfo;
                    guna2Button2.Invoke(new MethodInvoker(() =>
                    {
                        guna2Button1.Enabled = false;
                        guna2Button2.Enabled = false;
                        guna2Button2.Visible = true;
                        guna2TextBox2.Enabled = true;
                        guna2TextBox2.Visible = true;
                        cacheCheckbox.Visible = true;
                        this.Size = new Size(186, 127);
                        guna2GroupBox1.Size = this.Size;

                        guna2Button1.Size = new Size(101, 23);
                        guna2Button1.Location = new Point(11, 94);
                    }));
                    bool find = false;
                    string md5 = Utils.CalculateMD5(fileName);
                    foreach (var info in FIleHashesDatabase.database)
                    {
                        if (info.MD5 == md5)
                        {
                            guna2Button2.Invoke(new MethodInvoker(() =>
                            {
                                guna2TextBox2.Text = info.FileName;
                            }));
                            cacheCheckbox.Invoke(new MethodInvoker(() =>
                            {
                                cacheCheckbox.Checked = info.WorkingDirectory;
                            }));
                            find = true;
                        }
                    }
                    if (!find)
                    {
                        guna2Button2.Invoke(new MethodInvoker(() =>
                        {
                            guna2TextBox2.Text = Path.GetFileNameWithoutExtension(fileInfo.Name);
                        }));
                    }
                    guna2Button2.Invoke(new MethodInvoker(() =>
                    {
                        guna2Button1.Enabled = true;
                        guna2Button2.Enabled = true;
                    }));
                });
            }
        }

        private void AddNewPE_Load(object sender, EventArgs e)
        {

        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                if (file != null)
                {
                    guna2Button2.Invoke(new MethodInvoker(() =>
                    {
                        guna2TextBox2.Enabled = false;
                        guna2Button1.Enabled = false;
                        guna2Button2.Enabled = false;
                        cacheCheckbox.Enabled = false;
                    }));
                    string directory = Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Files";
                    PEFile pE = new PEFile();
                    string random = directory + "\\" + PEData.RandomString(16) + ".bin";
                    File.Copy(file.FullName, random);
                    string random2 = directory + "\\" + PEData.RandomString(16) + ".bin";
                    WinBoosterNative.Security.AES.SharpAESCrypt.Encrypt(Program.GetCPUID(), random, random2);
                    File.Delete(random);
                    pE.FileName = random2;
                    pE.Name = guna2TextBox2.Text;
                    pE.Extension = file.Extension;
                    pE.WorkingDirectory = cacheCheckbox.Checked;
                    Program.PEData.data.Add(pE);
                    Program.PEData.Save();
                    Program.form.PeSafeForm.guna2ComboBox1.Invoke(new MethodInvoker(() =>
                    {
                        Program.form.PeSafeForm.guna2ComboBox1.Items.Add(pE.Name);
                    }));
                    var item = toastNotificationsManager1.YieldArray().First();
                    var item2 = item.Notifications.First();
                    item2.Header = "PE Safe";
                    item2.Body = "Added new PE: " + guna2TextBox2.Text;
                    toastNotificationsManager1.ShowNotification(item2.ID);
                    Program.form.PeSafeForm.UpdateUI();
                    guna2Button2.Invoke(new MethodInvoker(() =>
                    {
                        guna2Button1.Enabled = true;
                        guna2Button2.Enabled = true;
                        guna2TextBox2.Enabled = true;
                        cacheCheckbox.Enabled = true;
                    }));
                    this.Close();
                }
            });
        }
    }
}
