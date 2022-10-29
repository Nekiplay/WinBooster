using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Data;
using WinBooster.Native;

namespace WinBooster
{
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            SaveAndLoad.statistic = Statistic.Load(SaveAndLoad.statistic_path);
            if (InvokeRequired)
            {
                label1.Invoke(new MethodInvoker(() =>
                {
                    label1.Text = "Total seats allocated: " + Utils.GetStringSize(SaveAndLoad.statistic.TotalSizeClear);
                }));
                label2.Invoke(new MethodInvoker(() =>
                {
                    label2.Text = "Cleaning done: " + SaveAndLoad.statistic.TotalGodClears;
                }));
                label3.Invoke(new MethodInvoker(() =>
                {
                    label3.Text = "Fixed bugs: " + SaveAndLoad.statistic.TotalFixes;
                }));
                label4.Invoke(new MethodInvoker(() =>
                {
                    label4.Text = "Maximum seats allocated: " + Utils.GetStringSize(SaveAndLoad.statistic.MaximumSizeClear);
                }));
            }
            else
            {
                label1.Text = "Total seats allocated: " + Utils.GetStringSize(SaveAndLoad.statistic.TotalSizeClear);
                label2.Text = "Cleaning done: " + SaveAndLoad.statistic.TotalGodClears;
                label3.Text = "Fixed bugs: " + SaveAndLoad.statistic.TotalFixes;
                label4.Text = "Maximum seats allocated: " + Utils.GetStringSize(SaveAndLoad.statistic.MaximumSizeClear);
            }
        }
        private void StatisticForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
