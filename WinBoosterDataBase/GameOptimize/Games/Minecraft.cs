using System;
using System.IO;
using System.Linq;
using WinBooster.Native;

namespace WinBoosterDataBase
{
    public class Minecraft : GameOptimizeI
    {
        public bool GameInstalled()
        {
            bool found = false;
            #region Default
            string default_path = Utils.GetSysDrive() + "\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft";
            if (Directory.Exists(default_path))
            {
                if (File.Exists(default_path + "\\options.txt"))
                {
                    found = true;
                }
            }
            #endregion
            #region PolyMC
            string polymc_path = Utils.GetSysDrive() + "\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\PolyMC\\instances";
            string[] instances = Directory.GetDirectories(polymc_path);
            foreach (string instance in instances)
            {
                string mc = instance + "\\.minecraft";
                if (Directory.Exists(mc))
                {
                    found = true;
                }
            }
            #endregion
            return found;
        }

        public string GameName()
        {
            return "Minecraft";
        }

        public void Optimize()
        {
            #region Default
            string default_path = Utils.GetSysDrive() + "\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft";
            if (Directory.Exists(default_path))
            {
                if (File.Exists(default_path + "\\options.txt"))
                {
                    SetOptimalSettings(default_path + "\\options.txt");
                }
                if (File.Exists(default_path + "\\optionsof.txt"))
                {
                    SetOptimalSettingsOf(default_path + "\\optionsof.txt");
                }
            }
            #endregion
            #region PolyMC
            string polymc_path = Utils.GetSysDrive() + "\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\PolyMC\\instances";
            if (Directory.Exists(polymc_path))
            {
                string[] instances = Directory.GetDirectories(polymc_path);
                foreach (string instance in instances)
                {
                    string mc = instance + "\\.minecraft";
                    if (File.Exists(mc + "\\options.txt"))
                    {
                        SetOptimalSettings(mc + "\\options.txt");
                    }
                    if (File.Exists(mc + "\\optionsof.txt"))
                    {
                        SetOptimalSettingsOf(mc + "\\optionsof.txt");
                    }
                }
            }
            #endregion
        }

        public void SetOptimizeData(params int[] data)
        {
            throw new NotImplementedException();
        }
        private void SetOptimalSettings(string path)
        {
            SetGameSettingValue(path, "fboEnable", "true");
            SetGameSettingValue(path, "fancyGraphics", "false");
            SetGameSettingValue(path, "renderClouds", "false");
            SetGameSettingValue(path, "showInventoryAchievementHint", "false");
            SetGameSettingValue(path, "pauseOnLostFocus", "false");
            SetGameSettingValue(path, "realmsNotifications", "false");
            SetGameSettingValue(path, "entityShadows", "false");
            SetGameSettingValue(path, "gamma", "1000.0");
        }
        private void SetOptimalSettingsOf(string path)
        {
            SetGameSettingValue(path, "ofRain", "3");
        }
        private void SetGameSettingValue(string path, string key, string value)
        {
            string[] lines = File.ReadAllLines(path);
            int index = 0;
            foreach (string line in lines.ToArray())
            {
                string[] key_and_value = line.Split(':');
                if (key_and_value.Length > 0 && key_and_value[0] == key)
                {
                    lines[index] = key_and_value[0] + ":" + value;
                }
                index++;
            }
            File.WriteAllLines(path, lines);
        }
    }
}
