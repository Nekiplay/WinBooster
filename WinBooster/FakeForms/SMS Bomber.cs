using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == Program.settings.Password)
            {
                this.Hide();
                Program.form.Show();
            }
        }
    }
}
