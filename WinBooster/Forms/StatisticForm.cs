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
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            Program.statistic = Statistic.Load(Program.statistic_path);
            if (InvokeRequired)
            {
                label1.Invoke(new MethodInvoker(() =>
                {
                    label1.Text = "Всего очисщено места: " + Utils.GetStringSize(Program.statistic.TotalSizeClear);
                }));
                label2.Invoke(new MethodInvoker(() =>
                {
                    label2.Text = "Сделано очисток: " + Program.statistic.TotalGodClears;
                }));
                label3.Invoke(new MethodInvoker(() =>
                {
                    label3.Text = "Исправлено ошибок: " + Program.statistic.TotalFixes;
                }));
            }
            else
            {
                label1.Text = "Всего очисщено места: " + Utils.GetStringSize(Program.statistic.TotalSizeClear);
                label2.Text = "Сделано очисток: " + Program.statistic.TotalGodClears;
                label3.Text = "Исправлено ошибок: " + Program.statistic.TotalFixes;
            }
        }
        private void StatisticForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
