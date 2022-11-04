using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinBoosterNative.Internet;

namespace WinBooster.DataBase.Internet
{
    public class DNSList
    {
        public static List<DNSInfo> list = new List<DNSInfo>
        {
            /* Русские DNS */
            /* PVimpelCom */
            new DNSInfo("212.46.234.217", "RU", "PVimpelCom"),
            new DNSInfo("195.239.36.27", "RU", "PVimpelCom"),
            new DNSInfo("195.14.50.21", "RU", "PVimpelCom"),
            new DNSInfo("89.179.83.118", "RU", "PVimpelCom"),
            new DNSInfo("83.69.120.1", "RU", "PVimpelCom"),
            new DNSInfo("81.211.96.62", "RU", "PVimpelCom"),
            new DNSInfo("80.243.64.67", "RU", "PVimpelCom"),
            /* Yandex */
            new DNSInfo("77.88.8.88", "RU", "YANDEX LLC"),
            new DNSInfo("77.88.8.81", "RU", "YANDEX LLC"),
            new DNSInfo("77.88.8.3", "RU", "YANDEX LLC"),
            new DNSInfo("77.88.8.2", "RU", "YANDEX LLC"),
            new DNSInfo("77.88.8.1", "RU", "YANDEX LLC"),
            /* MTS */
            new DNSInfo("95.104.194.3", "RU", "MTS PJSC"),
            new DNSInfo("80.71.178.68", "RU", "MTS PJSC"),
            new DNSInfo("62.168.251.166", "RU", "MTS PJSC"),
            /* Rostelecom */
            new DNSInfo("213.24.238.26", "RU", "Rostelecom"),
            new DNSInfo("213.24.237.210", "RU", "Rostelecom"),
            new DNSInfo("212.58.212.83", "RU", "Rostelecom"),
            new DNSInfo("195.46.112.170", "RU", "Rostelecom"),
            new DNSInfo("109.172.10.70", "RU", "Rostelecom"),
            new DNSInfo("91.122.77.189", "RU", "Rostelecom"),
            new DNSInfo("85.175.46.122", "RU", "Rostelecom"),
            new DNSInfo("84.54.226.50", "RU", "Rostelecom"),
            new DNSInfo("82.208.99.185", "RU", "Rostelecom"),
            /* Other */
            new DNSInfo("84.237.112.130", "RU", "Federal Research Center for Information and Computational Technologies"),
            new DNSInfo("62.113.51.133", "RU", "SFT Company"),
            new DNSInfo("212.75.208.170", "RU", "E-Light-Telecom Ltd"),
            new DNSInfo("178.210.42.50", "RU", "KVANT-TELEKOM Closed Joint Stock Company"),
            new DNSInfo("195.98.79.117", "RU", "Ic-voronezh82.208.99.185"),
            new DNSInfo("31.204.180.44", "RU", "Unknow"),
            new DNSInfo("195.191.183.60", "RU", "MediaNet Ltd"),
            new DNSInfo("84.244.59.15", "RU", "Unknow"),
            new DNSInfo("62.122.101.59", "RU", "Unknow"),
            new DNSInfo("195.112.96.34", "RU", "MAXnet Systems Ltd"),
            new DNSInfo("217.150.35.129", "RU", "Joint Stock Company TransTeleCom"),
            new DNSInfo("195.69.65.98", "RU", "BILLING SOLUTION Ltd"),
            new DNSInfo("37.29.119.100", "RU", "PJSC MegaFon"),
            new DNSInfo("195.208.5.1", "RU", "Unknow"),
            new DNSInfo("46.16.229.223", "RU", "JSC Elektrosvyaz"),
            new DNSInfo("77.95.89.99", "RU", "Speckless Enterprise Ltd"),
            new DNSInfo("94.100.86.238", "RU", "Unknow"),
            new DNSInfo("91.205.3.65", "RU", "Joint Stock Company TransTeleCom"),
            new DNSInfo("213.234.9.198", "RU", "JSC RDE Unico"),
            new DNSInfo("91.217.62.219", "RU", "LLC Megacom-IT"),
            new DNSInfo("95.129.58.55", "RU", "Azimut-R Ltd"),
            new DNSInfo("195.208.4.1", "RU", "Joint-stock company Internet Exchange MSK-IX"),
            new DNSInfo("62.76.76.62", "RU", "Joint-stock company Internet Exchange MSK-IX"),
            new DNSInfo("92.223.109.31", "RU", "G-Core Labs S.A"),
            new DNSInfo("92.223.65.32", "RU", "G-Core Labs S.A"),
            new DNSInfo("81.3.169.172", "RU", "PJSC MegaFon"),
            new DNSInfo("176.103.130.137", "RU", "Serveroid, LLC"),
            new DNSInfo("185.51.61.101", "RU", "ZAO ElectronTelecom"),
            new DNSInfo("213.183.100.154", "RU", "JSC ER-Telecom Holding"),
            new DNSInfo("176.103.130.136", "RU", "Serveroid, LLC"),
            new DNSInfo("37.195.200.66", "RU", "Novotelecom Ltd"),
            new DNSInfo("176.103.130.131", "RU", "Serveroid, LLC"),
            new DNSInfo("77.88.8.7", "RU", " LLC"),
            new DNSInfo("193.58.251.251", "RU", "SkyDNS Ltd"),
            new DNSInfo("176.103.130.130", "RU", "Serveroid, LLC"),
            new DNSInfo("37.193.226.251", "RU", "Novotelecom Ltd"),
            new DNSInfo("81.1.217.134", "RU", "JSC Zap-Sib TransTeleCom, Novosibirsk"),
            new DNSInfo("37.235.70.59", "RU", "OOO MediaSeti"),
            new DNSInfo("46.231.210.26", "RU", "OBIT Ltd"),
            new DNSInfo("89.235.136.61", "RU", "MSN Telecom LLC"),
            new DNSInfo("89.113.0.68", "RU", "Public Joint Stock Company Vimpel-Communications"),
            new DNSInfo("83.149.227.152", "RU", "Federal State Institution Federal Scientific Research Institute for System Analysis of the Ru"),
            new DNSInfo("84.52.103.114", "RU", "JSC ER-Telecom Holding"),
            new DNSInfo("217.112.27.34", "RU", "PJSC Moscow city telephone network"),
            new DNSInfo("83.246.140.204", "RU", "Joint Stock Company TransTeleCom"),
            new DNSInfo("213.5.120.2", "RU", "Andrey Chuenkov PE"),
            new DNSInfo("212.100.143.211", "RU", "OJSC Comcor"),
            new DNSInfo("109.202.11.6", "RU", "JSC Avantel"),
            new DNSInfo("46.20.67.50", "RU", "Joint Stock Company TransTeleCom"),
            new DNSInfo("194.247.190.70", "RU", "Proxima Ltd"),
            new DNSInfo("91.200.227.141", "RU", "Korporatsia Svyazy Ltd"),
            new DNSInfo("91.203.177.216", "RU", "MAN net Ltd"),
            new DNSInfo("195.162.8.154", "RU", "Telecom Plus Ltd"),
            new DNSInfo("91.122.77.189", "RU", "St Petersburg"),
            new DNSInfo("91.203.177.216", "RU", "Smolensk"),
            new DNSInfo("195.162.8.154", "RU", "Telecom Plus Ltd"),
            new DNSInfo("46.20.67.50", "RU", "Proxima Ltd"),
            new DNSInfo("194.247.190.70", "RU", "AdGuard"),
            new DNSInfo("91.200.227.141", "RU", "Korporatsia Svyazy Ltd"),
            /* AU DNS */
            new DNSInfo("1.1.1.1", "AU", "CloudFlare"),
            new DNSInfo("1.0.0.1", "AU", "CloudFlare"),
            /* US DNS */
            new DNSInfo("8.8.8.8", "US", "Google Public DNS"),
            new DNSInfo("8.8.4.4", "US", "Google Public DNS"),
            new DNSInfo("156.154.71.1", "US", "Neustar 1"),
            new DNSInfo("156.154.70.1", "US", "Neustar 1"),
            new DNSInfo("208.67.220.222", "US", "OpenDNS - 2"),
            new DNSInfo("208.67.222.220", "US", "OpenDNS - 2"),
            new DNSInfo("64.6.65.6", "US", "VerSign Public DNS"),
            new DNSInfo("64.6.64.6", "US", "VerSign Public DNS"),
            new DNSInfo("156.154.71.22", "US", "Comodo"),
            new DNSInfo("156.154.70.22", "US", "Comodo"),
            new DNSInfo("156.154.70.5", "US", "Neustar 2"),
            new DNSInfo("156.154.71.5", "US", "Neustar 2"),
            new DNSInfo("74.82.42.42", "US", "Hurricane Electric"),
            new DNSInfo("7199.85.126.10", "US", "Norton ConnectionSafe Basic"),
            new DNSInfo("199.85.127.10", "US", "Norton ConnectionSafe Basic"),
            new DNSInfo("204.74.101.1", "US", "Ultra DNS"),
            new DNSInfo("204.69.234.1", "US", "Ultra DNS"),
            new DNSInfo("198.153.194.1", "US", "Norton DNS"),
            new DNSInfo("198.153.192.1", "US", "Norton DNS"),
            new DNSInfo("149.112.112.112", "US", "Quad9 Security"),
            new DNSInfo("4.2.2.4", "US", "Level 3 - C"),
            new DNSInfo("4.2.2.3", "US", "Level 3 - C"),
            new DNSInfo("84.200.70.40", "US", "DNS Watch"),
            new DNSInfo("84.200.69.80", "US", "DNS Watch"),
            new DNSInfo("209.244.0.4", "US", "Level 3 - A"),
            new DNSInfo("209.244.0.3", "US", "Level 3 - A"),
            new DNSInfo("9.9.9.9", "US", "Quad9 Security"),
        };
        /* Получаем наилучший DNS */
        public static async Task<Tuple<DNSInfo, DNSInfo>> GetDNS()
        {
            DNSInfo on1 = await GetBestDNSAsync();
            DNSInfo on2 = await GetBestDNSAsync(on1.dns);
            return new Tuple<DNSInfo, DNSInfo>(on1, on2);
        }
        private static async Task<DNSInfo> GetBestDNSAsync()
        {
            return await GetBestDNSAsync("");
        }
        private static async Task<DNSInfo> GetBestDNSAsync(string ignore)
        {
            List<Task> asyncs = new List<Task>();
            DNSInfo best = list.FirstOrDefault();
            long templat = -1;
            foreach (DNSInfo dns in list)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    if (dns.dns != ignore)
                    {
                        long lat = dns.GetLatency(dns.dns);
                        dns.latency = lat;
                        if (lat == -1 || templat == -1)
                        {
                            templat = lat;
                            best = dns;
                        }
                        else
                        {
                            if (templat > lat)
                            {
                                templat = lat;
                                best = dns;
                            }
                        }
                    }
                });
                asyncs.Add(temp);
                await Task.Delay(75);
            }
            foreach (Task t in asyncs)
            {
                await t;
            }
            return best;
        }
    }
}
