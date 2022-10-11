namespace WinBoosterScripts.Classes
{
    public class Directory
    {
        public bool Exists(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        public bool Delete(string path)
        {
            try
            {
                System.IO.Directory.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string path, bool recursive)
        {
            try
            {
                System.IO.Directory.Delete(path, recursive);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
