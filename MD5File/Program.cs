using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBooster.DataBase.FilesHashes;
using WinBooster.Native;

namespace MD5File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string md5 = Utils.CalculateMD5(@"C:\Users\NekiPlay\Desktop\MAS v2.exe");
            Console.WriteLine("MD5: " + md5);
            foreach (var info in FIleHashesDatabase.database)
            {
                if (info.MD5 == md5)
                {
                    Console.WriteLine("Detected: " + info.FileName);
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
