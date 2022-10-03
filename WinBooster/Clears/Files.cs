using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinBooster.Clears
{
    public class Files
    {
        public List<WorkingI> logs = new List<WorkingI>()
        {
            #region Windows
            new DirectoryFull("C:\\Windows\\Logs"),
            new DirectoryFull("C:\\Windows\\Temp"),
            new DirectoryFull("C:\\Users\\%username%\\AppData\\Local\\Temp"),
            new DirectoryPatern("C:\\Windows", "*.log"),
            new DirectoryPatern("C:\\Windows\\debug", "*.log"),
            new DirectoryPatern("C:\\Windows\\debug\\WIA", "*.log"),
            #endregion

            #region Photoshop
            new DirectoryPatern("C:\\Program Files\\Adobe\\%unknowfolder%\\Legal\\en_GB", "*.html"),
            new DirectoryPatern("C:\\Program Files\\Adobe\\%unknowfolder%\\Legal\\ru_RU", "*.html"),
            new DirectoryPatern("C:\\Program Files\\Adobe\\%unknowfolder%\\OBLRes\\en_GB", "*.html"),
            new DirectoryPatern("C:\\Program Files\\Adobe\\%unknowfolder%\\OBLRes\\ru_RU", "*.html"),
            #endregion

            #region Gameloop
            new DirectoryPatern("D:\\Program Files\\TxGameAssistant\\AppMarket", "*.log"),
            new DirectoryPatern("C:\\Program Files\\TxGameAssistant\\AppMarket", "*.log"),
            new DirectoryPatern("D:\\Program Files\\TxGameAssistant\\AppMarket\\DL", "*.log"),
            new DirectoryPatern("C:\\Program Files\\TxGameAssistant\\AppMarket\\DL", "*.log"),
            new DirectoryPatern("D:\\Program Files\\TxGameAssistant\\ui", "*.log"),
            new DirectoryPatern("C:\\Program Files\\TxGameAssistant\\ui", "*.log"),
            #endregion

            #region BlueStacks 5
            new DirectoryPatern("C:\\Program Files\\BlueStacks_nxt", "*.html"),
            new DirectoryPatern("C:\\Program Files\\BlueStacks_nxt", "*.rtf"),
            new DirectoryPatern("D:\\Program Files\\BlueStacks_nxt", "*.html"),
            new DirectoryPatern("D:\\Program Files\\BlueStacks_nxt", "*.rtf"),
            new DirectoryFull("C:\\ProgramData\\BlueStacks_nxt\\Logs"),
            new DirectoryFull("D:\\ProgramData\\BlueStacks_nxt\\Logs"),
            #endregion

            #region Nox
            new DirectoryPatern("C:\\Program Files\\Nox\\bin\\BignoxVMS\\nox\\Logs", "*.log"),
            new DirectoryPatern("D:\\Program Files\\Nox\\bin\\BignoxVMS\\nox\\Logs", "*.log"),
            new DirectoryFull("C:\\Users\\%username%\\vmlogs"),
            #endregion

            #region Java
            new DirectoryPatern("C:\\Program Files\\Java\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\Java\\%unknowfolder%", "*.html"),
            new DirectoryPatern("C:\\Program Files\\Java\\%unknowfolder%", "COPYRIGHT"),
            new DirectoryPatern("C:\\Program Files\\Java\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("C:\\Program Files\\Java\\%unknowfolder%", "release"),
            #endregion

            #region Minecraft
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\PolyMC", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\logs", "*.log*"),

            new DirectoryPatern("C:\\AkrienAntiLeak\\clients\\AkrienPremium\\game\\logs", "*.log"),
            #endregion

            #region JetBrains
            new DirectoryPatern("C:\\Program Files\\JetBrains\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\JetBrains\\%unknowfolder%\\license", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\JetBrains\\%unknowfolder%\\license", "*.html"),
            #endregion

            #region Git
            new DirectoryPatern("C:\\Program Files\\Git", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\Git\\etc", "*.txt"),
            new DirectoryFull("C:\\Program Files\\Git\\mingw64\\doc"),
            new DirectoryFull("C:\\Program Files\\Git\\mingw64\\share\\doc"),
            #endregion

            #region USOShared
            new DirectoryFull("C:\\ProgramData\\USOShared\\Logs"),
            #endregion

            #region NVIDIA
            new DirectoryPatern("C:\\Program Files\\NVIDIA Corporation", "license.txt"),
            new DirectoryPatern("C:\\Program Files\\NVIDIA Corporation\\NVSMI", "*.pdf"),
            new DirectoryPatern("C:\\Program Files\\NVIDIA Corporation\\Ansel\\Tools", "*.txt"),

            new DirectoryPatern("C:\\ProgramData\\NVIDIA", "*.log"),
            new DirectoryPatern("C:\\ProgramData\\NVIDIA Corporation\\nvstapisvr", "*.log"),
            #endregion

            #region Radmin VPN
            new DirectoryPatern("C:\\ProgramData\\Famatech\\Radmin VPN", "*.log"),
            #endregion

            #region Driver Booster
            new DirectoryPatern("C:\\ProgramData\\IObit\\Driver Booster\\Downloader", "*.log"),
            #endregion

            #region PCHealthCheck
            new DirectoryPatern("C:\\Program Files\\PCHealthCheck", "*.txt"),
            #endregion

            #region Process Hacker 2
            new DirectoryPatern("C:\\Program Files\\Process Hacker 2", "*.txt"),
            #endregion

            #region NeverLose
            new DirectoryPatern("C:\\", "NeverBSOD.log"),
            #endregion

            #region ShareX
            new DirectoryPatern("C:\\Users\\%username%\\Documents\\ShareX\\Logs", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\ShareX\\Licenses", "*.txt"),
            #endregion

            #region EasyAntiCheat
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\EasyAntiCheat", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\EasyAntiCheat\\497", "*.log"),
            #endregion

            #region OBS Studio
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\obs-studio\\logs", "*.log"),
            #endregion

            #region GitHub Desktop
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\GitHub Desktop\\logs", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\GitHubDesktop", "*.log"),
            #endregion

            #region Overwolf
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.html"),
            new DirectoryPatern("C:\\ProgramData\\Overwolf\\Log", "*.log"),
            /* Achievement Rewards */
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Achievement Rewards", "*.log"),
            /* CurseForge */
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\CurseForge", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\CurseForge\\CurseClient", "*.json"),
            /* Overwolf General GameEvents Provider */
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Overwolf General GameEvents Provider", "*.log"),
            /* Overwolf notifications */
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Overwolf notifications", "*.log"),
            /* Overwolf Remote Configurations */
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Overwolf Remote Configurations", "*.log"),
            #endregion

            #region LGHUB
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\LGHUB\\Session Storage", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\LGHUB\\Local Storage\\leveldb", "*.log"),
            #endregion

            #region Discord
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Discord", "*.log"),
            #endregion

            #region Steam
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\Local Storage\\leveldb", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\Service Worker\\Database", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\Session Storage", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\shared_proto_db\\metadata", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\VideoDecodeStats", "*.log"),
            new DirectoryPatern("C:\\Program Files (x86)\\Common Files\\Steam", "*.txt"),
            new DirectoryPatern("%steam%\\logs", "*.txt"),
            new DirectoryPatern("%steam%", "*.log"),
            new DirectoryPatern("%steam%", "*.html"),

            /* Ironsight_wpg */
            new DirectoryPatern("%steam%\\steamapps\\common\\Ironsight_wpg", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Ironsight_wpg", "*.txt"),

            /* Terraria */
            new DirectoryPatern("%steam%\\steamapps\\common\\Terraria", "changelog.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Terraria", "changelog.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Terraria", "steam_appid.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Terraria", "steam_appid.txt"),

            /* Counter-Strike Global Offensive */
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.log"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.log"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.doc"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.doc"),

            /* Garrys mod */
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod", "*.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod", "*.log"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod", "*.log"),
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod\\bin", "*.log"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod\\bin", "*.log"),

            /* Team Fortress 2 */
            new DirectoryPatern("%steam%\\steamapps\\common\\Team Fortress 2", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Team Fortress 2", "*.txt"),
            #endregion

            #region DevExpress
            new DirectoryPatern("C:\\Program Files (x86)\\DevExpress 21.2\\Components", "*.log"),
            new DirectoryPatern("C:\\Program Files (x86)\\DevExpress 21.2\\Components\\Support", "*.log"),
            #endregion

            #region DotNET
            new DirectoryPatern("C:\\Program Files (x86)\\dotnet\\shared", "*.rtf"),
            #endregion

            #region Unity
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\UnityHub\\logs", "*.json"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Unity", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Unity\\Editor", "*.log"),
            new DirectoryPatern("C:\\Program Files\\Unity Hub", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\Unity Hub\\resources", "*.txt"),
            #endregion

            #region WindowsDefender
            new DirectoryPatern("C:\\Program Files\\Windows Defender", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\Windows Defender Advanced Threat Protection\\Classification", "*.txt"),
            #endregion

            #region WinRAR
            new DirectoryPatern("C:\\Program Files\\WinRAR", "*.txt"),
            new DirectoryPatern("C:\\Program Files\\WinRAR", "*.htm"),
            #endregion

            #region Xamarin
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Xamarin\\Logs\\18.0", "*.log"),
            new DirectoryPatern("C:\\Users\\%%username%%\\AppData\\Local\\Xamarin\\Logs\\17.0", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Xamarin\\Logs\\16.0", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Xamarin\\Logs\\15.0", "*.log"),
            #endregion

            #region Android
            new DirectoryPatern("C:\\Program Files (x86)\\Android\\android-sdk\\build-tools\\32.0.0", "*.txt"),
            new DirectoryPatern("C:\\Program Files (x86)\\Android\\android-sdk\\cmdline-tools\\7.0", "*.txt"),
            new DirectoryPatern("C:\\Program Files (x86)\\Android\\android-sdk\\platforms\\android-31\\skins", "*.txt"),
            new DirectoryPatern("C:\\Program Files (x86)\\Android\\android-sdk\\platforms\\android-31\\templates", "*.txt"),
            new DirectoryPatern("C:\\Program Files (x86)\\Android\\android-sdk\\platform-tools", "*.txt"),
            #endregion

            #region Enigma Virtual Box
            new DirectoryPatern("C:\\Program Files (x86)\\Enigma Virtual Box", "*.txt"),
            new DirectoryPatern("C:\\Program Files (x86)\\Enigma Virtual Box", "*.url"),
            new DirectoryPatern("C:\\Program Files (x86)\\Enigma Virtual Box", "*.chm"),
            #endregion

            #region Everything
            new DirectoryPatern("C:\\Program Files (x86)\\Everything", "*.txt"),
            #endregion

            #region Picasa3
            new DirectoryPatern("C:\\Program Files (x86)\\Google\\Picasa3\\licenses", "*.txt"),
            #endregion

            #region Microsoft Web Deploy V3
            new DirectoryPatern("C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3", "*.txt"),
            #endregion

            #region IIS Express
            new DirectoryPatern("C:\\Program Files (x86)\\IIS Express", "*.txt"),
            new DirectoryPatern("C:\\Program Files (x86)\\IIS Express", "*.url"),
            #endregion

            #region BitTorrentHelper
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\BitTorrentHelper", "*.log"),
            #endregion

            #region Notepad++
            new DirectoryPatern("C:\\Program Files\\Notepad++", "*.log"),
            new DirectoryPatern("C:\\Program Files\\Notepad++", "readme.txt"),
            new DirectoryPatern("C:\\Program Files\\Notepad++", "LICENSE"),
            #endregion

            #region iTop Screen Recorder
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\iTop Screen Recorder\\Logs", "*.log")
            #endregion
        };

        public List<WorkingI> images = new List<WorkingI>()
        {
            #region iTop Screen Recorder
            new DirectoryFull("C:\\Users\\%username%\\AppData\\LocalLow\\iTop Screen Recorder\\Outputs"),
            #endregion

            #region ShareX
            new DirectoryFull("C:\\Users\\%username%\\Documents\\ShareX\\Screenshots"),
            #endregion
        };

        public List<WorkingI> media = new List<WorkingI>()
        {
            #region Bandicam
            new DirectoryFull("C:\\Users\\%username%\\Documents\\Bandicam"),
            #endregion

            #region Minecraft
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\screenshots", "*.png*"),
            #endregion
        };

        public List<WorkingI> cache = new List<WorkingI>()
        {
            new DirectoryFull("C:\\Users\\%username%\\AppData\\LocalLow\\Microsoft\\CryptnetUrlCache\\Content"),
            new DirectoryFull("C:\\Users\\%username%\\AppData\\LocalLow\\Microsoft\\CryptnetUrlCache\\MetaData"),

            #region Driver Booster
            new DirectoryPatern("C:\\ProgramData\\IObit\\Driver Booster\\Download", "*.dbo*"),
            new DirectoryPatern("C:\\ProgramData\\IObit\\Driver Booster\\Download", "*.dbx*"),
            #endregion

            #region LGHUB
            new DirectoryPatern("C:\\ProgramData\\LGHUB\\cache", "*"),
            #endregion

            #region Steam
            new DirectoryFull("%steam%\\userdata"),
            new DirectoryPatern("%steam%\\appcache\\stats", "*.bin"),
            new DirectoryPatern("%steam%\\appcache\\librarycache", "*.jpg"),
            new DirectoryPatern("%steam%\\appcache\\librarycache", "*.png"),
            new DirectoryPatern("%steam%\\dumps", "*.dmp"),
            new DirectoryFull("%steam%\\appcache\\httpcache"),

            /* Ironsight_wpg */
            new DirectoryPatern("%steam%\\steamapps\\common\\Ironsight_wpg\\replay", "*.rep"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Ironsight_wpg\\replay", "*.rep"),

            /* Terraria */
            new DirectoryPatern("%steam%\\steamapps\\common\\Terraria", "changelog.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Terraria", "changelog.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Terraria", "dotNetFx40_Full_setup.exe"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Terraria", "dotNetFx40_Full_setup.exe"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Terraria", "dotNetFx40_Full_x86_x64.exe"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Terraria", "dotNetFx40_Full_x86_x64.exe"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Terraria", "xnafx40_redist.msi"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Terraria", "xnafx40_redist.msi"),

            /* Counter-Strike Global Offensive */
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.mdmp"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.mdmp"),

            /* Garrys mod */
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod", "*.mdmp"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod", "*.mdmp"),
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\lua", "*.lua"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\lua", "*.lua"),
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\workshop", "*.gma"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\workshop", "*.gma"),
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\workshop\\resource\\fonts", "*.ttf"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\workshop\\resource\\fonts", "*.ttf"),
            new DirectoryPatern("%steam%\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\workshop\\resource\\fonts\\sincopa", "*.ttf"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\GarrysMod\\garrysmod\\cache\\workshop\\resource\\fonts\\sincopa", "*.ttf"),
            #endregion
        };

        public List<WorkingI> cheats = new List<WorkingI>()
        {
            #region NeverLose
            new DirectoryPatern("C:\\", "NeverBSOD.log"),
            new DirectoryFull("%steam%\\steamapps\\common\\Counter-Strike Global Offensive\\nl"),
            new DirectoryFull("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive\\nl"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            #endregion

            #region ExecHack
            new DirectoryFull("C:\\exechack"),
            #endregion

            #region Akrien
            new DirectoryFull("C:\\AkrienAntiLeak"),
            #endregion
        };

        public List<WorkingI> lastactivity_unsafe = new List<WorkingI>()
        {
            new DirectoryUnsafeFileNames("C:\\Windows\\Prefetch", new SafeNames().names)
        };

        public List<WorkingI> lastactivity_full = new List<WorkingI>()
        {

            new DirectoryPatern("C:\\Windows\\Prefetch", "*.pf")
        };
    }
}
