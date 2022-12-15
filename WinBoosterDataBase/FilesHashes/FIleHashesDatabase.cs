using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster.DataBase.FilesHashes
{
    public class FIleHashesDatabase
    {
        public static List<FileInfoByMD5> database = new List<FileInfoByMD5>()
        {
            new FileInfoByMD5("Vape [Original] HWID", "55ba1c985f2b0393c86d043960d8c5a0", "Minecraft", true, FileInfoByMD5.Type.Cheat),
            new FileInfoByMD5("Vape [Original] Launcher", "7738f50139afccfd88a89d8aed3c076e", "Minecraft", false, FileInfoByMD5.Type.Cheat),
            new FileInfoByMD5("Vape [Crack] v4.04", "dbc263826aeb0c1cd504b04ff73f9d01", "Minecraft", true, FileInfoByMD5.Type.Cheat),
            new FileInfoByMD5("Vape [Crack] Server", "7f559c6fec19ac71ae9bea5dfd4041bd", "Minecraft", true, FileInfoByMD5.Type.Cheat),

            new FileInfoByMD5("Akrien Premium Loader", "830511d481d3b0d9e73f8475159ebee3", "Minecraft", true, FileInfoByMD5.Type.Cheat),

            new FileInfoByMD5("MAS v2", "cd3e594eca14a2ec9d342568ae8b7cd5", "Minecraft", true, FileInfoByMD5.Type.Macros),
        };
    }
}
