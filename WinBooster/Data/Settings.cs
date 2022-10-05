using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster
{
    internal class Settings : AppSettings<Settings>
    {
        public int FakeMenu = 0;
        public string Password = "";
        public bool DarkTheme = true;
    }
}
