namespace WinBoosterScripts.Classes
{
    public class File
    {
        public bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public bool Delete(string path)
        {
            try
            {
                System.IO.File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
