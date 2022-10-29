using WinBooster.Native;

namespace WinBooster.Data
{
    public class SaveAndLoad
    {
        public static Settings settings = new Settings();
        public static Statistic statistic = new Statistic();
        public static PremiumFeatures premiumFeatures = new PremiumFeatures();

        public static string folder = Utils.GetSysDrive() + "\\ProgramData\\WinBooster";    
        public static string settings_path = folder + "\\Settings.json";
        public static string statistic_path = folder + "\\Statistic.json";
        public static string premiumFeatures_path = folder + "\\PremiumFeatures.json";
    }
}
