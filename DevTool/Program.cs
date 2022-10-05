using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines(@"C:\Program Files (x86)\X7 Oscar Keyboard Editor\ScriptsMacros\Russian\StandardFile\Untitle Script23123.ASC");
            foreach (string line in data)
            {
                string line2 = line.Replace(@"	", @"\t");
                line2 = "\"" + line2 + @"\n" + "\" +";
                Console.WriteLine(line2);
            }
            Console.ReadLine();
        }
    }
}
