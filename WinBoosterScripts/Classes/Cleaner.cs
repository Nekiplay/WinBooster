using WinBooster.Native;
using WinBoosterDataBase;

namespace WinBoosterScripts.Classes
{
    public class Cleaner
    {
        public LogsManager Logs = new LogsManager();
        public CacheManager Cache = new CacheManager();
        public class LogsManager
        {
            public void Add(string directory)
            {
                Files.logs.Add(new DirectoryFull(directory));
            }
            public void Add(string directory, string patern)
            {
                Files.logs.Add(new DirectoryPatern(directory, patern));
            }

            public int Count
            {
                get
                {
                    return Files.logs.Count;
                }
            }
        }
        public class CacheManager
        {
            public void Add(string directory)
            {
                Files.cache.Add(new DirectoryFull(directory));
            }
            public void Add(string directory, string patern)
            {
                Files.cache.Add(new DirectoryPatern(directory, patern));
            }
            public int Count
            {
                get
                {
                    return Files.cache.Count;
                }
            }
        }
    }
}
