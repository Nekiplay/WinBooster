using DevExpress.Utils.About;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Optimize;

namespace WinBooster
{
    public partial class OptimizeForm : Form
    {
        public OptimizeForm()
        {
            InitializeComponent();
        }

        private void Optinize_Load(object sender, EventArgs e)
        {
            #region Проверка алгоритма Nagle
            Task.Factory.StartNew(() =>
            {
                bool enabled = false;
                RegistryKey reg = Registry.LocalMachine;
                RegistryKey Interfaces = reg.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces");
                string[] names = Interfaces.GetSubKeyNames();
                foreach (string name in names)
                {
                    RegistryKey kk = Interfaces.OpenSubKey(name);
                    if (kk.GetValue("TcpAckFrequency") != null && kk.GetValue("TcpNoDelay") != null
                    && kk.GetValue("TcpAckFrequency").ToString() == "1"
                    && kk.GetValue("TcpNoDelay").ToString() == "1"
                    )
                    {
                        enabled = true;
                    }
                    RegistryKey Software = reg.OpenSubKey(@"Software\Microsoft\MSMQ\Parameters", false);
                    if (Software == null)
                    {
                        reg.CreateSubKey(@"Software\Microsoft\MSMQ\Parameters");
                    }
                    if (Software.GetValue("TcpNoDelay") == null
                    || Software.GetValue("TcpNoDelay").ToString() != "1"
                    )
                    {
                        enabled = false;
                    }
                }
                guna2CheckBox4.Invoke(new MethodInvoker(() =>
                {
                    guna2CheckBox4.Checked = enabled;
                }));
            });
            #endregion
            #region Проверка электросхемы максимальной производительности
            /* Проверка максимальной производительности */
            EnergyClass energy = new EnergyClass();
            Task.Factory.StartNew(() =>
            {
                List<Tuple<string, string, bool>> schems = energy.ListSchemes();
                foreach (var s in schems)
                {
                    if (s.Item2 == "Максимальная производительность" && !s.Item3)
                    {
                        energy.Delete(s.Item1);
                    }
                }

                schems = energy.ListSchemes();
                foreach (var s in schems)
                {
                    if (s.Item2 == "Максимальная производительность" && s.Item3)
                    {
                        guna2CheckBox1.Invoke(new MethodInvoker(() =>
                        {
                            guna2CheckBox1.Checked = true;
                        }));
                    }
                }
            });
            #endregion
            #region Проверка гибернаций
            GybernateClass gybernate = new GybernateClass();
            Task.Factory.StartNew(() =>
            {
                bool on = gybernate.Activated();
                guna2CheckBox2.Invoke(new MethodInvoker(() =>
                {
                    guna2CheckBox2.Checked = !on;
                }));
            });
            #endregion
        }

        private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            #region Изменение алгоритма Nagle
            Task.Factory.StartNew(() =>
            {
                RegistryKey reg = Registry.LocalMachine;
                if (guna2CheckBox4.Checked)
                {
                    /* Включение в интерфейсах */
                    RegistryKey Interfaces = reg.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", true);
                    string[] names = Interfaces.GetSubKeyNames();
                    foreach (string name in names)
                    {
                        RegistryKey keys = Interfaces.OpenSubKey(name, true);
                        keys.SetValue("TcpNoDelay", 1);
                        keys.SetValue("TcpAckFrequency", 1);
                    }
                    /* Включение по документаций Microsoft */
                    RegistryKey Software = reg.OpenSubKey(@"Software\Microsoft\MSMQ\Parameters", true);
                    Software.SetValue("TcpNoDelay", 1);
                    Software.SetValue("TcpAckFrequency", 1);

                    new ProcessUtils().StartCmd("netsh interface ip delete arpcache"
                        + " & netsh winsock reset catalog"
                        + " & netsh int ip reset c:resetlog.txt"
                        + " & netsh int ip reset C:\tcplog.txt"
                        + " & netsh winsock reset catalog"
                        + " & netsh int tcp set global rsc=enabled"
                        + " & netsh int tcp set heuristics disabled"
                        + " & netsh int tcp set global dca=enabled"
                        + " & netsh int tcp set global netdma=enabled"
                        );
                }
                else
                {
                    /* Удаление в интерфейсах */
                    RegistryKey Interfaces = reg.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", true);
                    string[] names = Interfaces.GetSubKeyNames();
                    foreach (string name in names)
                    {
                        RegistryKey keys = Interfaces.OpenSubKey(name, true);
                        try { keys.DeleteValue("TcpNoDelay"); } catch { }
                        try { keys.DeleteValue("TcpAckFrequency"); } catch { }
                    }
                    /* Удаление по документаций Microsoft */
                    RegistryKey Software = reg.OpenSubKey(@"Software\Microsoft\MSMQ\Parameters", true);
                    Software.DeleteValue("TcpNoDelay");
                    Software.DeleteValue("TcpAckFrequency");
                }
            });
            #endregion
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            #region Изменение электросхемы питания
            Task.Factory.StartNew(() =>
            {
                EnergyClass energy = new EnergyClass();
                energy.Enable(guna2CheckBox1.Checked);
                if (!guna2CheckBox1.Checked)
                {
                    guna2CheckBox1.Invoke(new MethodInvoker(() =>
                    {
                        guna2CheckBox1.Checked = false;
                    }));
                }
            });
            #endregion

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            #region Изменение гибернаций
            Task.Factory.StartNew(() =>
            {
                GybernateClass gybernate = new GybernateClass();
                gybernate.Enable(!guna2CheckBox2.Checked);
            });
            #endregion
        }
    }
}
