using WinBooster.Native;
using WinBoosterDataBase;

namespace WinBoosterScripts.Classes
{
    public class Cleaner
    {
        public LogsManager Logs = new LogsManager();
        public CacheManager Cache = new CacheManager();
        public ImagesManager Images = new ImagesManager();
        public MediaManager Media = new MediaManager();
        public CheatsManager Cheats = new CheatsManager();
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
        public class ImagesManager
        {
            public void Add(string directory)
            {
                Files.images.Add(new DirectoryFull(directory));
            }
            public void Add(string directory, string patern)
            {
                Files.images.Add(new DirectoryPatern(directory, patern));
            }
            public int Count
            {
                get
                {
                    return Files.images.Count;
                }
            }
        }
        public class MediaManager
        {
            public void Add(string directory)
            {
                Files.media.Add(new DirectoryFull(directory));
            }
            public void Add(string directory, string patern)
            {
                Files.media.Add(new DirectoryPatern(directory, patern));
            }
            public int Count
            {
                get
                {
                    return Files.media.Count;
                }
            }
        }
        public class CheatsManager
        {
            public void Add(string directory)
            {
                Files.cheats.Add(new DirectoryFull(directory));
            }
            public void Add(string directory, string patern)
            {
                Files.cheats.Add(new DirectoryPatern(directory, patern));
            }
            public int Count
            {
                get
                {
                    return Files.cheats.Count;
                }
            }
        }
    }
}
