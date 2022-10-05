using System;
using System.Net;

namespace WinBooster
{
    public class UpdateChecker
    {
        public bool CheckUpdate()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string ver = wc.DownloadString("https://github.com/Nekiplay/Temp/raw/main/WinBoosterVersion.txt");
                    if (Program.version != ver)
                    {
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }
    }
}
