namespace WinBooster.DataBase.FilesHashes
{
    public class FileInfoByMD5
    {
        public string FileName;
        public string MD5;

        public Type type;
        public string Game;

        public bool WorkingDirectory = false;

        public enum Type
        {
            Cheat,
            Virus,
            Program,
            Macros,
        }

        public FileInfoByMD5(string fileName, string MD5, string game, bool workingDirectory, Type type)
        {
            FileName = fileName;
            this.MD5 = MD5;
            this.type = type;
            this.Game = game;
            this.WorkingDirectory = workingDirectory;
        }
    }
}
