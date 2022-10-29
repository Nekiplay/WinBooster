using MediaDevices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WinBooster.Native;
using WinBoosterCharpScripts;

namespace DeveloperTools
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public static CharpUpdater charpUpdater = new CharpUpdater();
        public static CharpManager charpManager = new CharpManager(charpUpdater);

        private Form currentChildForm;
        private string currentChildFormname;
        public void OpenChildForm(Form childForm, bool newform = false)
        {
            if (currentChildForm != childForm && currentChildFormname != childForm.Name)
            {
                //open only form
                if (currentChildForm != null)
                {
                    if (newform)
                    {
                        currentChildForm.Close();
                    }
                    panelDesktop.Controls.Clear();
                }
                currentChildForm = childForm;
                currentChildFormname = childForm.Name;
                //End
                childForm.BackColor = panelDesktop.BackColor;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Add(childForm);
                panelDesktop.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        List<Control> controlList = new List<Control>();
        public void OpenMenu(Form form)
        {
            if (controlList.Count == 0)
            {
                foreach (Control c in panelDesktop.Controls)
                {
                    controlList.Add(c);
                }
            }
            backPuctureBix.Visible = true;
            OpenChildForm(form, false);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (controlList.Count != 0)
            {
                panelDesktop.Controls.Clear();
                currentChildFormname = "";
                currentChildForm = null;
                panelDesktop.Controls.AddRange(controlList.ToArray());
                backPuctureBix.Visible = false;
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            string directory = "Pictures\\VK";
            var devices = MediaDevice.GetDevices();
            foreach (var div in devices)
            {
                using (var device = div)
                {
                    device.Connect();
                    var dirs = device.GetRootDirectory();
                    if (device.DirectoryExists(dirs.FullName))
                    {
                        var photoDir = device.GetDirectories(dirs.FullName);

                        foreach (var dir3 in photoDir)
                        {
                            if (device.DirectoryExists(dir3 + "\\" + directory))
                            {
                                var info = device.GetDirectoryInfo(dir3 + "\\" + directory);
                                Console.WriteLine(info.FullName);
                            }
                        }
                    }
                }
            }

            #region Загрузка скриптов
            if (!Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\Scripts"))
            {
                Directory.CreateDirectory(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\Scripts");
            }
            string[] files = Directory.GetFiles(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\Scripts");
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension == ".cs")
                {
                    charpManager.ScriptLoad(new WinBoosterCharpScripts.File(file));
                }
            }
            #endregion
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
