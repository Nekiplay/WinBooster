namespace WinBoosterScripts.Classes
{
    public class Random
    {
        public int Next(int min, int max)
        {
            return new System.Random().Next(min, max);
        }
    }
}
