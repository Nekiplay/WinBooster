using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WinBoosterNative.Internet
{
    public class DNSInfo
    {
        public string dns;
        public string countiry;
        public string company_or_name;
        public long latency;

        public DNSInfo(string dns, string countury, string company_or_name)
        {
            this.dns = dns;
            this.countiry = countury;
            this.company_or_name = company_or_name;
        }
        /* Получаем Ping от DNS */
        public long GetLatency(string dnss)
        {
            int timeout = 25;
            long firsttime = 99999999999;
            try
            {
                Ping p1 = new Ping();
                PingReply r1 = p1.Send(dnss, timeout);
                if (r1.Status == IPStatus.Success)
                {
                    firsttime = r1.RoundtripTime;
                }
            }
            catch { }
            return firsttime;
        }
        /* Устанавливаем DNS на текущий */
        public void Set()
        {
            SetDNS(this.dns);
        }
        /* Получаем текущую сеть */
        public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
        {
            var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            return Nic;
        }
        /* Ставим DNS на автоматическое от Windows */
        public static void UnsetDNS()
        {
            var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
            if (CurrentInterface == null)
            {
                return;
            }

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();
            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
                    {
                        ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        if (objdns != null)
                        {
                            objdns["DNSServerSearchOrder"] = null;
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                    }
                }
            }
        }
        /* Устанавливаем DNS */
        private void SetDNS(string DnsString)
        {
            string[] Dns = DnsString.Split('*');
            var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
            if (CurrentInterface == null)
            {
                return;
            }

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();
            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
                    {
                        ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        objdns["DNSServerSearchOrder"] = Dns;
                        objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                    }
                }
            }
        }
    }
}
