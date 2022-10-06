using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string done = "List<string> lines = new List<string>()\n";
            done += "{\n";
            string[] lines = File.ReadAllLines(@"C:\Program Files (x86)\X7 Oscar Keyboard Editor\ScriptsMacros\Russian\StandardFile\Untitle Script.ASC");
            foreach (string line in lines)
            {
                done += "   \"" + line + "\",\n";
            }
            done += "\n};";
            Console.WriteLine(done);
            Console.ReadLine();
        }
    }
}
