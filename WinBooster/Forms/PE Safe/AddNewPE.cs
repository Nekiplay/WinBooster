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
using WinBooster.Data;
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

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                await Task.Factory.StartNew(() =>
                {
                    guna2Button1.Invoke(new MethodInvoker(() =>
                    {
                        guna2Button1.Enabled = false;
                    }));
                    string directory = Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Files";
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    string file = openFileDialog.FileName;
                    FileInfo fileInfo = new FileInfo(file);
                    PEFile pE = new PEFile();
                    string random = directory + "\\" + PEData.RandomString(16) + ".bin";
                    File.Copy(file, random);
                    string random2 = directory + "\\" + PEData.RandomString(16) + ".bin";
                    WinBoosterNative.Security.AES.SharpAESCrypt.Encrypt(Program.GetCPUID(), random, random2);
                    File.Delete(random);
                    pE.FileName = random2;
                    pE.Name = guna2TextBox2.Text;
                    pE.Extension = fileInfo.Extension;
                    Program.PEData.data.Add(pE);
                    Program.PEData.Save();
                    guna2Button1.Invoke(new MethodInvoker(() =>
                    {
                        guna2Button1.Enabled = true;
                    }));
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
                    this.Close();
                });
            }
        }
    }
}
