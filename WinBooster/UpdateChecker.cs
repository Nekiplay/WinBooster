using System;
using System.Net;

namespace WinBooster
{
    public class UpdateChecker
    {
        public Tuple<bool, string> CheckUpdate()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string ver = wc.DownloadString("https://github.com/Nekiplay/Temp/raw/main/WinBoosterVersion.txt");
                    if (Program.version != ver)
                    {
                        return new Tuple<bool, string>(true, ver);
                    }
                }
            }
            catch { }
            return new Tuple<bool, string>(false, "");
        }
    }
}
