using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WinBooster
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public StatisticForm statistic = new StatisticForm();
        public Cleaner cleaner = new Cleaner();
        public OptimizeForm optimize = new OptimizeForm();
        public SettingsForm settings = new SettingsForm();
        public GameOptimizeForm gameOptimize = new GameOptimizeForm();
        public FixerForm fixer = new FixerForm();

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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(cleaner, false);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
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
            pictureBox4.Visible = true;
            pictureBox6.Location = new Point(407, 5);
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
                pictureBox4.Visible = false;
                pictureBox6.Location = new Point(445, 5);
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Program.settings.DarkTheme = !Program.settings.DarkTheme;
            Program.settings.Save();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label2.Text = "Win Booster v" + Program.version;
            if (Program.NeedUpdate)
            {
                label2.Text += " (New update available)";
            }
        }

        #region Открытие очистки

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenMenu(cleaner);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OpenMenu(cleaner);
        }
        private void guna2Panel2_Click(object sender, EventArgs e)
        {
            OpenMenu(cleaner);
        }
        #endregion

        #region Открытие оптимизаций
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenMenu(optimize);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OpenMenu(optimize);
        }
        private void guna2Panel5_Click(object sender, EventArgs e)
        {
            OpenMenu(optimize);
        }
        #endregion

        #region Открытие настроек
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenMenu(settings);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OpenMenu(settings);
        }
        private void guna2Panel4_Click(object sender, EventArgs e)
        {
            OpenMenu(settings);
        }
        #endregion

        #region Открытие игровой оптимизаций
        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            OpenMenu(gameOptimize);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenMenu(gameOptimize);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            OpenMenu(gameOptimize);
        }
        #endregion

        #region Открытие статистики

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenMenu(statistic);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OpenMenu(statistic);
        }

        private void guna2Panel6_Click(object sender, EventArgs e)
        {
            OpenMenu(statistic);
        }
        #endregion

        #region Открытие исравления ошибок

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            OpenMenu(fixer);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            OpenMenu(fixer);
        }

        private void guna2Panel7_Click(object sender, EventArgs e)
        {
            OpenMenu(fixer);
        }
        #endregion

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
