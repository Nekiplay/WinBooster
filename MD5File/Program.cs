using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WinBooster.DataBase.FilesHashes;
using WinBooster.Native;

namespace MD5File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.Write("File path: ");
            string path = Console.ReadLine();
            path = path.Replace("\"", "");
            string md5 = Utils.CalculateMD5(path);
            var info = FIleHashesDatabase.GetInfo(md5);
            Console.WriteLine("MD5: " + md5);
            if (info != null)
            {
                Console.Clear();
                Console.WriteLine("MD5: " + md5);
                Console.WriteLine("Detected: " + info.name);
                Console.WriteLine("Version: " + info.version);
                Console.WriteLine("Platform: " + info.platform);
            }
            Console.ReadKey();
            Console.Clear();
            goto start;
        }
    }
}
