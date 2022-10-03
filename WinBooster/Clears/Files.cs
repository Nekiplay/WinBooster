using System.Collections.Generic;

namespace WinBooster.Clears
{
    public class Files
    {
        public List<WorkingI> logs = new List<WorkingI>()
        {
            #region Windows
            new DirectoryFull("%cycdrive%\\Windows\\Logs"),
            new DirectoryFull("%cycdrive%\\Windows\\Temp"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Local\\Temp"),
            new DirectoryPatern("%cycdrive%\\Windows", "*.log"),
            new DirectoryPatern("%cycdrive%\\Windows\\debug", "*.log"),
            new DirectoryPatern("%cycdrive%\\Windows\\debug\\WIA", "*.log"),
            new DirectoryPatern("%cycdrive%\\Windows\\SoftwareDistribution", "*.log"),
            new DirectoryPatern("%cycdrive%\\Windows\\SoftwareDistribution\\DataStore\\Logs", "*.log"),
            new DirectoryPatern("%cycdrive%\\Windows\\Performance\\WinSAT", "*.log"),
            new DirectoryPatern("%cycdrive%\\Windows\\Panther", "*.log"),
            new DirectoryPatern("%cycdrive%\\Windows\\Panther\\UnattendGC", "*.log"),

            new DirectoryPatern("%cycdrive%\\Windows\\System32\\winevt\\Logs", "*.evtx"),

            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "*.url"),

            #endregion

            #region SandBoxie Plus
            new DirectoryPatern("%cycdrive%\\Program Files\\Sandboxie-Plus", "*.txt"),
            #endregion

            #region X7 Oscar Keyboard Editor
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\X7 Oscar Keyboard Editor", "*.log"),
            #endregion

            #region Discord
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\IndexedDB\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Local Storage\\leveldb", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\module_data\\discord_hook", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Session Storage", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\shared_proto_db", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\shared_proto_db\\metadata", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Discord", "*.log"),
            #endregion

            #region Photoshop
            new DirectoryPatern("%cycdrive%\\Program Files\\Adobe\\%unknowfolder%\\Legal\\en_GB", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Adobe\\%unknowfolder%\\Legal\\ru_RU", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Adobe\\%unknowfolder%\\OBLRes\\en_GB", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Adobe\\%unknowfolder%\\OBLRes\\ru_RU", "*.html"),
            #endregion

            #region Visual Studio
            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\EdgeAdapter\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\EdgeAdapter\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\EdgeAdapter\\%unknowfolder%", "*.md"),

            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\\\ChromeAdapter\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\\\ChromeAdapter\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\\\ChromeAdapter\\%unknowfolder%", "*.md"),
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
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Bluestacks", "*.log"),
            #endregion

            #region Nox
            new DirectoryPatern("C:\\Users\\%username%\\.BigNox", "*.log*"),
            new DirectoryPatern("C:\\Program Files\\Nox\\bin\\BignoxVMS\\nox\\Logs", "*.log"),
            new DirectoryPatern("D:\\Program Files\\Nox\\bin\\BignoxVMS\\nox\\Logs", "*.log"),
            new DirectoryFull("C:\\Users\\%username%\\vmlogs"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Local\\Nox", "*.log"),
            #endregion

            #region Java
            new DirectoryPatern("%cycdrive%\\ProgramData\\Oracle\\Java\\.oracle_jre_usage", "*.timestamp"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "COPYRIGHT"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "release"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "ASSEMBLY_EXCEPTION"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "THIRD_PARTY_README"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%\\sample", "README"),
            #endregion

            #region Minecraft
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\logs", "*.log*"),

            new DirectoryPatern("%cycdrive%\\AkrienAntiLeak\\clients\\AkrienPremium\\game\\logs", "*.log"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\curseforge\\minecraft\\Instances\\%unknowfolder%\\logs", "*.log*"),
            #endregion

            #region JetBrains
            new DirectoryPatern("%cycdrive%\\Program Files\\JetBrains\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\JetBrains\\%unknowfolder%\\license", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\JetBrains\\%unknowfolder%\\license", "*.html"),
            #endregion

            #region Git
            new DirectoryPatern("%cycdrive%\\Program Files\\Git", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Git\\etc", "*.txt"),
            new DirectoryFull("%cycdrive%\\Program Files\\Git\\mingw64\\doc"),
            new DirectoryFull("%cycdrive%\\Program Files\\Git\\mingw64\\share\\doc"),
            #endregion

            #region USOShared
            new DirectoryFull("%cycdrive%\\ProgramData\\USOShared\\Logs"),
            #endregion

            #region NVIDIA
            new DirectoryPatern("%cycdrive%\\Program Files\\NVIDIA Corporation", "license.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\NVIDIA Corporation\\NVSMI", "*.pdf"),
            new DirectoryPatern("%cycdrive%\\Program Files\\NVIDIA Corporation\\Ansel\\Tools", "*.txt"),

            new DirectoryPatern("%cycdrive%\\ProgramData\\NVIDIA", "*.log"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\NVIDIA Corporation\\nvstapisvr", "*.log"),
            #endregion

            #region Radmin VPN
            new DirectoryPatern("%cycdrive%\\ProgramData\\Famatech\\Radmin VPN", "*.log"),
            #endregion

            #region Driver Booster
            new DirectoryPatern("%cycdrive%\\ProgramData\\IObit\\Driver Booster\\Downloader", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\IObit\\Driver Booster\\Logs\\Install", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\IObit\\Driver Booster\\Logs\\Main", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\IObit\\Driver Booster\\Logs\\Scan", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\IObit\\Driver Booster\\Logs\\Scheduler", "*.log"),
            #endregion

            #region PCHealthCheck
            new DirectoryPatern("%cycdrive%\\Program Files\\PCHealthCheck", "*.txt"),
            #endregion

            #region Process Hacker 2
            new DirectoryPatern("%cycdrive%\\Program Files\\Process Hacker 2", "*.txt"),
            #endregion

            #region NeverLose
            new DirectoryPatern("%cycdrive%\\", "NeverBSOD.log"),
            #endregion

            #region ShareX
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\Documents\\ShareX\\Logs", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\ShareX\\Licenses", "*.txt"),
            #endregion

            #region EasyAntiCheat
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\EasyAntiCheat", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\EasyAntiCheat\\497", "*.log"),
            #endregion

            #region OBS Studio
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\obs-studio\\logs", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\obs-studio\\logs", "*.txt"),
            #endregion

            #region GitHub Desktop
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\GitHub Desktop\\logs", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GitHubDesktop", "*.log"),
            #endregion

            #region Overwolf
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Overwolf\\Log", "*.log"),
            /* Achievement Rewards */
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Achievement Rewards", "*.log"),
            /* CurseForge */
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\CurseForge", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\CurseForge\\CurseClient", "*.json"),
            /* Overwolf General GameEvents Provider */
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Overwolf General GameEvents Provider", "*.log"),
            /* Overwolf notifications */
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Overwolf notifications", "*.log"),
            /* Overwolf Remote Configurations */
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log\\Apps\\Overwolf Remote Configurations", "*.log"),
            #endregion

            #region LGHUB
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\LGHUB\\Session Storage", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\LGHUB\\Local Storage\\leveldb", "*.log"),
            #endregion

            #region Steam
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\Local Storage\\leveldb", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\Service Worker\\Database", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\Session Storage", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\shared_proto_db\\metadata", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Steam\\htmlcache\\VideoDecodeStats", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Common Files\\Steam", "*.txt"),
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

            /* World of Tanks */
            new DirectoryPatern("%steam%\\steamapps\\common\\World of Tanks\\ru", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\World of Tanks\\ru", "*.txt"),

            /* Among Us */
            new DirectoryPatern("%steam%\\steamapps\\common\\Among Us\\Among Us_Data\\Plugins", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Among Us\\Among Us_Data\\Plugins", "*.txt"),
            #endregion

            #region DevExpress
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\DevExpress 21.2\\Components", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\DevExpress 21.2\\Components\\Support", "*.log"),
            #endregion

            #region DotNET
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\dotnet\\shared", "*.rtf"),
            #endregion

            #region Unity
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\UnityHub\\logs", "*.json"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Unity", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Unity\\Editor", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Unity Hub", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Unity Hub\\resources", "*.txt"),
            #endregion

            #region WindowsDefender
            new DirectoryPatern("%cycdrive%\\Program Files\\Windows Defender", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Windows Defender Advanced Threat Protection\\Classification", "*.txt"),
            #endregion

            #region 7-Zip
            new DirectoryPatern("%cycdrive%\\Program Files\\7-Zip", "*.txt"),
            #endregion

            #region WinRAR
            new DirectoryPatern("%cycdrive%\\Program Files\\WinRAR", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\WinRAR", "*.htm"),
            #endregion

            #region Xamarin
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Xamarin\\Logs\\18.0", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%%username%%\\AppData\\Local\\Xamarin\\Logs\\17.0", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Xamarin\\Logs\\16.0", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Xamarin\\Logs\\15.0", "*.log"),
            #endregion

            #region Android
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Android\\android-sdk\\build-tools\\32.0.0", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Android\\android-sdk\\cmdline-tools\\7.0", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Android\\android-sdk\\platforms\\android-31\\skins", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Android\\android-sdk\\platforms\\android-31\\templates", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Android\\android-sdk\\platform-tools", "*.txt"),

            new DirectoryPatern("%cycdrive%\\Microsoft\\AndroidNDK\\%unknowfolder%", "*.md"),
            #endregion

            #region Enigma Virtual Box
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Enigma Virtual Box", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Enigma Virtual Box", "*.url"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Enigma Virtual Box", "*.chm"),
            #endregion

            #region Everything
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Everything", "*.txt"),
            #endregion

            #region Picasa3
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Google\\Picasa3\\licenses", "*.txt"),
            #endregion

            #region Microsoft Web Deploy V3
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3", "*.txt"),
            #endregion

            #region IIS Express
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\IIS Express", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\IIS Express", "*.url"),
            #endregion

            #region BitTorrentHelper
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\BitTorrentHelper", "*.log"),
            #endregion

            #region Notepad++
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Notepad++", "*.log"),
            #endregion

            #region iTop Screen Recorder
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\iTop Screen Recorder\\Logs", "*.log")
            #endregion
        };

        public List<WorkingI> images = new List<WorkingI>()
        {
            #region iTop Screen Recorder
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\iTop Screen Recorder\\Outputs"),
            #endregion

            #region ShareX
            new DirectoryFull("%cycdrive%\\Users\\%username%\\Documents\\ShareX\\Screenshots"),
            #endregion

            #region Minecraft
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\screenshots", "*.png*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\curseforge\\minecraft\\Instances\\%unknowfolder%\\screenshots", "*.png*"),
            new DirectoryPatern("%cycdrive%\\AkrienAntiLeak\\clients\\AkrienPremium\\game\\screenshots", "*.png"),
            #endregion
        };

        public List<WorkingI> media = new List<WorkingI>()
        {
            #region Bandicam
            new DirectoryFull("\"%cycdrive%\\Users\\%username%\\Documents\\Bandicam"),
            #endregion
        };

        public List<WorkingI> cache = new List<WorkingI>()
        {
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Microsoft\\CryptnetUrlCache\\Content"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Microsoft\\CryptnetUrlCache\\MetaData"),

            #region Driver Booster
            new DirectoryPatern("%cycdrive%\\ProgramData\\IObit\\Driver Booster\\Download", "*.dbo*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\IObit\\Driver Booster\\Download", "*.dbx*"),
            #endregion

            #region LGHUB
            new DirectoryPatern("%cycdrive%\\ProgramData\\LGHUB\\cache", "*"),
            #endregion

            #region Discord
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Cache", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\js", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\js\\index-dir", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\wasm", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\wasm\\index-dir", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Service Worker\\CacheStorage\\%unknowfolder%", "*.txt"),
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
            new DirectoryPatern("%cycdrive%\\", "NeverBSOD.log"),
            new DirectoryFull("%steam%\\steamapps\\common\\Counter-Strike Global Offensive\\nl"),
            new DirectoryFull("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive\\nl"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            #endregion

            #region rebornhack
            new DirectoryFull("%cycdrive%\\rebornhack"),
            #endregion

            #region NixWare
            new DirectoryFull("%cycdrive%\\nixware"),
            #endregion

            #region AOSHack
            new DirectoryFull("%cycdrive%\\aoshax"),
            #endregion

            #region ExecHack
            new DirectoryFull("%cycdrive%\\exechack"),
            #endregion

            #region Akrien
            new DirectoryFull("%cycdrive%\\AkrienAntiLeak"),
            #endregion
        };

        public List<WorkingI> lastactivity_unsafe = new List<WorkingI>()
        {
            new DirectoryUnsafeFileNames("%cycdrive%\\Windows\\Prefetch", new SafeNames().names)
        };

        public List<WorkingI> lastactivity_full = new List<WorkingI>()
        {

            new DirectoryPatern("%cycdrive%\\Windows\\Prefetch", "*.pf")
        };
    }
}
