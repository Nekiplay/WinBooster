using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBooster
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = Program.settings.FakeMenu;
            guna2TextBox1.Text = Program.settings.Password;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            Program.settings.Password = guna2TextBox1.Text;
            Program.settings.Save(Program.settings_path);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.settings.FakeMenu = guna2ComboBox1.SelectedIndex;
            Program.settings.Save(Program.settings_path);
        }
    }
}
