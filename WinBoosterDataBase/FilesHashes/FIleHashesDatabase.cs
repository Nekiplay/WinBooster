using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBoosterNative.Enums;

namespace WinBooster.DataBase.FilesHashes
{
    public class FIleHashesDatabase
    {
        public static Dictionary<string, FileInfoByMD5> database = new Dictionary<string, FileInfoByMD5>()
        {
            { "55ba1c985f2b0393c86d043960d8c5a0", new FileInfoByMD5("Vape [Original] HWID", "-", "Minecraft", true, new List<FileType>() { FileType.Cheat }, Platform.any) },
            { "7738f50139afccfd88a89d8aed3c076e", new FileInfoByMD5("Vape [Original] Launcher", "4.10", "Minecraft", false, new List<FileType>() { FileType.Cheat }, Platform.any) },
            { "dbc263826aeb0c1cd504b04ff73f9d01", new FileInfoByMD5("Vape [Crack] v4.04", "4.04", "Minecraft", true, new List<FileType>() { FileType.Cheat }, Platform.any) },
            { "7f559c6fec19ac71ae9bea5dfd4041bd", new FileInfoByMD5("Vape [Crack] Server", "-", "Minecraft", true, new List<FileType>() { FileType.Cheat }, Platform.any) },
            { "830511d481d3b0d9e73f8475159ebee3", new FileInfoByMD5("Akrien Premium Loader", "-", "Minecraft", true, new List<FileType>() { FileType.Cheat }, Platform.any) },
            { "cd3e594eca14a2ec9d342568ae8b7cd5", new FileInfoByMD5("MAS", "2", "Minecraft", true, new List<FileType>() { FileType.Cheat }, Platform.any) },

            #region Process Hacker 2
            /* x64 */ { "92994e64b3b771a7f109956802cbc1e7", new FileInfoByMD5("Process Hacker", "3.0.7640.3113", "-", false, new List<FileType>() { FileType.Program }, Platform.x64) },
            /* x32 */ { "e264227d423a41766dfed102fd0b4067", new FileInfoByMD5("Process Hacker", "3.0.7640.3113", "-", false, new List<FileType>() { FileType.Program }, Platform.x32) },

            /* x64 */ { "f8f8cdec7d3d24e183025495408e21bf", new FileInfoByMD5("Process Hacker", "3.0.2836", "-", false, new List<FileType>() { FileType.Program }, Platform.x64) },
            /* x32 */ { "c24744635648e39a226de0592eb1c094", new FileInfoByMD5("Process Hacker", "3.0.2836", "-", false, new List<FileType>() { FileType.Program }, Platform.x32) },

            /* x64 */ { "d6033c295585fd59f0bee988ceceb7b8", new FileInfoByMD5("Process Hacker", "3.0.2480", "-", false, new List<FileType>() { FileType.Program }, Platform.x64) },
            /* x32 */ { "7e03e9cb5737feb739540d0544fa093d", new FileInfoByMD5("Process Hacker", "3.0.2480", "-", false, new List<FileType>() { FileType.Program }, Platform.x32) },

            /* x64 */ { "b365af317ae730a67c936f21432b9c71", new FileInfoByMD5("Process Hacker", "2.39", "-", false, new List<FileType>() { FileType.Program }, Platform.x64) },
            /* x32 */ { "68f9b52895f4d34e74112f3129b3b00d", new FileInfoByMD5("Process Hacker", "2.39", "-", false, new List<FileType>() { FileType.Program }, Platform.x32) },

            /* x64 */ { "55060c2d7140a9ba5806ab24e7c16a76", new FileInfoByMD5("Process Hacker", "2.38", "-", false, new List<FileType>() { FileType.Program }, Platform.x64) },
            /* x32 */ { "ea7f4f4ffeb102edf3e3facd48a72d0b", new FileInfoByMD5("Process Hacker", "2.38", "-", false, new List<FileType>() { FileType.Program }, Platform.x32) },
            #endregion

            #region LastActivityView
            { "1aa9ef9b5f6223e4e8a0a92a86d72d59", new FileInfoByMD5("LastActivityView", "1.36", "-", false, new List<FileType>() { FileType.Program, FileType.ScreenShare }, Platform.any) },
            #endregion
        };

        public static FileInfoByMD5 GetInfo(string md5)
        {
            if (database.ContainsKey(md5))
            {
                FileInfoByMD5 info = database[md5];
                if (info != null)
                {
                    return info;
                }
            }
            return null;
        }
    }
}
