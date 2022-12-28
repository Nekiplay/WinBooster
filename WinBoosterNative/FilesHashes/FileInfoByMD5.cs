using System.Collections.Generic;
using System.Text;
using WinBoosterNative.Enums;

namespace WinBooster.DataBase.FilesHashes
{
    public class FileInfoByMD5
    {
        public string name;
        public string version;

        public List<FileType> filetypes;
        public Platform platform;
        public string game;

        public bool bypass = false;


        public FileInfoByMD5(string name, string version, string game, bool workingDirectory, List<FileType> filetypes, Platform platform)
        {
            this.platform = platform;
            this.version = version;
            this.name = name;
            this.filetypes = filetypes;
            this.game = game;
            this.bypass = workingDirectory;
        }
    }
}
