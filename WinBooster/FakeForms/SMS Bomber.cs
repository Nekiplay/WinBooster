using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBooster.FakeForms
{
    public partial class SMS_Bomber : Form
    {
        public SMS_Bomber()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == Program.settings.Password)
            {
                this.Hide();
                Program.form.Show();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {
            label2.Text = "SMS Bomber v" + Program.version;
        }
    }
}
