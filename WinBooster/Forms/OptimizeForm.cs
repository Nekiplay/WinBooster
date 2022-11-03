using DevExpress.Utils.About;
using DevExpress.Utils.Extensions;
using Guna.UI2.WinForms;
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
using WinBooster.DataBase.Internet;
using WinBooster.Optimize;
using WinBoosterNative.Internet;

namespace WinBooster
{
    public partial class OptimizeForm : Form
    {
        public OptimizeForm()
        {
            InitializeComponent();
        }
        private DNSInfo bestdns = null;

        public void StartSettingChecker()
        {
            guna2CheckBox4.Enabled = false;
            guna2CheckBox1.Enabled = false;
            guna2CheckBox2.Enabled = false;
            guna2CheckBox3.Enabled = false;
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
                    guna2CheckBox4.Enabled = true;
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
                guna2CheckBox1.Invoke(new MethodInvoker(() =>
                {
                    guna2CheckBox1.Enabled = true;
                }));
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
                    guna2CheckBox2.Enabled = true;
                }));
            });
            #endregion
            #region Проверка отличного DNS
            Task.Factory.StartNew(async () =>
            {
                bestdns = await DNSList.GetDNS();
                try
                {
                    var anctiveNetworks = DNSInfo.GetActiveEthernetOrWifiNetworkInterface().GetIPProperties().DnsAddresses.ToArray();

                    string current1 = anctiveNetworks[0].ToString();
                    string current2 = anctiveNetworks[1].ToString();

                    string best1 = bestdns.dns.Split('*')[0];
                    string best2 = bestdns.dns.Split('*')[1];
                    if ((current1 == best1 || current2 == best2) || (current2 == best1 || current1 == best2))
                    {
                        guna2CheckBox3.Invoke(new MethodInvoker(() =>
                        {
                            guna2CheckBox3.Checked = true;
                        }));
                    }
                    guna2CheckBox3.Invoke(new MethodInvoker(() =>
                    {
                        guna2CheckBox3.Enabled = true;
                    }));
                }
                catch { }
            });
            #endregion
        }

        private void Optinize_Load(object sender, EventArgs e)
        {
            StartSettingChecker();
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
            if (guna2CheckBox1.Enabled)
            {
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
            }
            #endregion

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            #region Изменение гибернаций
            if (guna2CheckBox2.Enabled)
            {
                Task.Factory.StartNew(() =>
                {
                    GybernateClass gybernate = new GybernateClass();
                    gybernate.Enable(!guna2CheckBox2.Checked);
                });
            }
            #endregion
        }

        private async void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox3.Checked && guna2CheckBox3.Enabled && bestdns != null)
            {
                guna2CheckBox3.Enabled = false;
                bestdns.Set();
                var item = toastNotificationsManager1.YieldArray().First();
                var item2 = item.Notifications.First();
                item2.Header = "New DNS Settings";
                item2.Body = "Main: " + bestdns.dns.Split('*')[0] + "\nReserve: " + bestdns.dns.Split('*')[1] + "\nLatency: " + bestdns.latency + "ms";
                toastNotificationsManager1.ShowNotification(item2.ID);
                guna2CheckBox3.Enabled = true;
            }
            else
            {
                DNSInfo.UnsetDNS();
            }
        }
    }
}
