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
using WinBooster.Data;

namespace WinBooster.FakeForms
{
    public partial class Keypad : Form
    {
        public Keypad()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (SaveAndLoad.settings.Password == guna2TextBox1.Text)
            {
                this.Hide();
                Program.form.Show();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "1";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "2";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "3";
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "4";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "5";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "6";
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "7";
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "8";
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "9";
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text += "0";
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (SaveAndLoad.settings.Password == guna2TextBox1.Text)
            {
                this.Hide();
                Program.form.Show();
            }
        }
    }
}
