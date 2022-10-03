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

namespace WinBooster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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

        Cleaner cleaner = new Cleaner();
        OptimizeForm optimize = new OptimizeForm();

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(cleaner, false);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(cleaner, false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(optimize, false);
        }
    }
}
