using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster.Data
{
    public class ColorSettings : AppSettings<ColorSettings>
    {
        public Color background;
        public Color text;
        public Color icons;
        public Color plateicons;
    }
}
