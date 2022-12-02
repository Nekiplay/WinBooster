using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBooster.Native;

namespace WinBooster.Data
{
    public class PEData
    {
        public List<PEFile> data = new List<PEFile>();

        public void Save()
        {
            string output = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (Directory.Exists(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe"))
            {
                File.Create(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Data.bin").Close();
                output = new WinBoosterNative.Security.Rijn.StringProtector(Program.GetCPUID()).Encrypt(output);
                File.WriteAllText(Utils.GetSysDrive() + "\\ProgramData\\WinBooster\\PE Safe\\Data.bin", output);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class PEFile
    {
        public string Name;
        public string FileName;
        public string Extension;
    }
}
