﻿using System.Collections.Generic;
using WinBooster.Native;
using WinBoosterNative.Clears.Native;

namespace WinBooster.DataBase
{
    public class Files
    {
        public static List<WorkingI> logs = new List<WorkingI>()
        {
            #region Ghast.io
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Programs\\Ghast", "*.log"),
            #endregion

            #region Uninstall Tool
            new DirectoryPatern("%cycdrive%\\Program Files\\Uninstall Tool", "*.url"),
            #endregion

            #region Exodus Crypto Wallet
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\exodus", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\exodus\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\exodus\\%unknowfolder%", "LICENSE"),
            #endregion

            #region FLauncher
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\flauncher", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\flauncher\\%unknowfolder%", "LICENSE.electron.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\flauncher\\%unknowfolder%", "LICENSES.chromium.html"),
            #endregion

            #region McSkill
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\McSkill\\updates\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\McSkill\\updates\\%unknowfolder%\\logs", "*"),
            #endregion

            #region Cifrazia
            new DirectoryFull("%cycdrive%\\Cifrazia\\games\\Minecraft\\1.12.2\\modpacks\\%unknowfolder%\\logs"),
            new DirectoryPatern("%cycdrive%\\Cifrazia\\games\\Minecraft\\1.12.2\\modpacks\\%unknowfolder%", "*.log"),
            new DirectoryFull("%cycdrive%\\Cifrazia\\games\\Minecraft\\1.7.10\\modpacks\\%unknowfolder%\\logs"),
            new DirectoryPatern("%cycdrive%\\Cifrazia\\games\\Minecraft\\1.7.10\\modpacks\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Cifrazia\\logs", "*.log"),
            #endregion

            #region VMware ThinApp
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\VMware\\VMware ThinApp", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\VMware\\VMware ThinApp", "*.rtf"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\VMware\\VMware ThinApp\\Policy", "*.txt"),
            #endregion

            #region CS 1.6 HPP
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\AltFixHpp", "*.log"),
            #endregion

            #region Komodo
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Komodo\\VRSC", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Komodo\\VRSC\\notarisations", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Komodo\\VRSC\\notarisations", "LOG"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Komodo\\VRSC\\notarisations", "LOG.old"),
            #endregion

            #region Green Hell
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Creepy Jar\\Green Hell", "*.log"),
            new DirectoryPatern("%cycdrive%\\Green Hell", "*.url"),
            #endregion

            #region GTFO
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\10 Chambers Collective\\GTFO", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\10 Chambers Collective\\GTFO", "*.txt"),
            new DirectoryPatern("%cycdrive%\\GTFO", "*.url"),
            #endregion

            #region WoW (Sirus)
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Sirus Launcher", "*.log"),
            #endregion

            #region RustMe
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\RustMe\\updates\\rustmevanilla\\logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\RustMe\\updates\\rustmevanilla", "*.log"),
            #endregion

            #region Lunar Client
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.lunarclient\\logs\\launcher", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.lunarclient\\offline\\multiver\\logs", "*"),
            #endregion

            #region LoliLand
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\loliland\\updates\\clients\\%unknowfolder%\\logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\loliland\\updates\\clients\\%unknowfolder%\\DivineRPG", "*.log"),
            #endregion

            #region FourWars
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\fourwars\\guard", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\fourwars\\updates\\%unknowfolder%\\logs", "*"),
            #endregion

            #region Kaboom 2.0
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Kaboom\\runtime-windows-x64", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Kaboom\\logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Kaboom\\modpacks\\1.7.10\\modpacks\\%unknowfolder%\\logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Kaboom\\modpacks\\1.12.2\\modpacks\\%unknowfolder%\\logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Kaboom\\modpacks\\1.7.10\\modpacks\\%unknowfolder%\\DivineRPG", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Kaboom\\modpacks\\1.12.2\\modpacks\\%unknowfolder%\\DivineRPG", "*.log"),
            #endregion

            #region Excalibur Craft
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.exlauncher", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.exlauncher\\clients\\%unknowfolder%\\logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.exlauncher\\clients\\%unknowfolder%\\DivineRPG", "*.log"),
            #endregion

            #region VimeWorld
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.vimeworld\\.logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.vimeworld\\%unknowfolder%\\logs", "*"),
            #endregion

            #region Electron programms (Lunar Client, WOW(Sirus))
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Programs\\%unknowfolder%", "LICENSE.electron.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Programs\\%unknowfolder%", "LICENSES.chromium.html"),
            #endregion

            #region Badlion Client
            new DirectoryPatern("%cycdrive%\\Program Files\\Badlion Client", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Badlion Client", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Badlion Client\\licenses", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Badlion Client\\logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Badlion Client\\logs\\launcher", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Badlion Client\\logs\\optifine-debug", "*"),

            new DirectoryPatern("%cycdrive%\\ProgramData\\BadlionClient\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\BadlionClient\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\BadlionClient\\%unknowfolder%", "release"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\BadlionClient\\%unknowfolder%", "COPYRIGHT"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\BadlionClient\\%unknowfolder%", "LICENSE"),
            #endregion

            #region RUXIM
            new DirectoryPatern("%cycdrive%\\Program Files\\RUXIM\\Logs", "*.etl"),
            #endregion

            #region BoxedAppPacker
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\BoxedAppPacker", "changelog.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\BoxedAppPacker", "*.url"),
            #endregion

            #region Roblox
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Roblox\\logs", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Roblox\\Versions\\%unknowfolder%", "COPYRIGHT.txt"),
            #endregion

            #region DroidCam
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\DroidCam", "*.txt"),
            #endregion

            #region Crypter
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Crypter", "*.log"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Crypter\\logs"),
            #endregion

            #region Vulcan
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\VulkanRT\\%unknowfolder%", "LICENSE.txt"),
            #endregion

            #region JetBrains
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Local\\JetBrains\\%unknowfolder%\\log"),
            #endregion

            #region GameNet
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Vebanaul\\GameNet\\logs", "*"),
            #endregion

            #region Microsoft Lobe
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Lobe\\logs"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Lobe", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Lobe", "LICENSE"),
            #endregion

            #region Android
            new DirectoryFullAndroid("MIUI"),
            #endregion

            #region LogMeIn Hamachi
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\LogMeIn Hamachi", "*.rtf"),
            #endregion

            #region Python
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Programs\\Python\\%unknowfolder%", "*.txt"),
            #endregion

            #region AVG
            new DirectoryPatern("%cycdrive%\\Program Files\\AVG\\Antivirus\\Licenses", "*.txt"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\AVG\\Antivirus\\Cache", "*.txt"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\AVG\\Antivirus\\log", "*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\AVG\\Antivirus\\report", "*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\AVG\\Antivirus\\taskperflogs", "*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\AVG\\Persistent Data\\Antivirus\\Logs", "*"),
            #endregion

            #region Team Speek 3
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\TeamSpeak 3 Client", "*.txt"),
            #endregion

            #region Mozila
            new DirectoryPatern("%cycdrive%\\Program Files\\Mozilla Firefox\\uninstall", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Mozilla Firefox", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Mozilla Maintenance Service\\logs", "*.log"),
            #endregion

            #region Avast
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Avast Software", "*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Avast Software\\Avast\\log", "*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Avast Software\\Persistent Data\\Avast\\Logs", "*"),
            #endregion

            #region Epic Games
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Epic Games\\Epic Online Services", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Epic Games\\Epic Online Services\\sites\\ui-helper", "ThirdPartyNotice.html"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Epic Games\\Epic Online Services\\UserHelper\\Logs", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\EpicGamesLauncher\\Saved\\Logs", "*"),
            #endregion

            #region Genshin Impact
            new DirectoryPatern("%cycdrive%\\Program Files\\Genshin Impact\\logs", "*.log"),
            new DirectoryPatern("D:\\Program Files\\Genshin Impact\\logs", "*.log"),
            #endregion

            #region Borderless Gaming
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Borderless Gaming", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Borderless Gaming", "*.pdb"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Borderless Gaming", "*.xml"),
            #endregion

            #region Bochs
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "CHANGES.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "COPYING.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "LICENSE.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "README.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "SeaBIOS-README.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "SeaVGABIOS-README.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "TODO.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "VGABIOS-elpin-LICENSE.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Bochs-2.7", "VGABIOS-lgpl-README.txt"),
            #endregion

            #region Windows
            new DirectoryFull("%cycdrive%\\Windows\\System32\\config"),
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
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\Documents\\WebView\\Cache", "*log*"),
            new DirectoryPatern("%cycdrive%\\Windows\\System32\\winevt\\Logs", "*.evtx"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\CrashDumps", "*.dmp"),
            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "*.url"),
            #endregion

            #region Forts
            new DirectoryPatern("%cycdrive%\\Forts", "*.url"),
            #endregion

            #region VintageStory
            new DirectoryPatern("%cycdrive%\\VintageStory", "*.url"),
            new DirectoryPatern("D:\\VintageStory", "*.url"),
            new DirectoryPatern("%cycdrive%\\VintageStory", "*.xml"),
            new DirectoryPatern("D:\\VintageStory", "*.xml"),
            new DirectoryPatern("%cycdrive%\\VintageStory", "*.txt"),
            new DirectoryPatern("D:\\VintageStory", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\VintagestoryData\\Logs", "*.txt"),
            #endregion

            #region Counter-Strike 1.6
            new DirectoryPatern("%cycdrive%\\Counter-Strike 1.6", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Counter-Strike 1.6", "*.log"),
            new DirectoryPatern("%cycdrive%\\Counter-Strike 1.6", "*.url"),

            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "Exception*.json"),
            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%", "debug.log"),
            #endregion

            #region Stalker Anomaly
            new DirectoryPatern("%cycdrive%\\Stalker\\Anomaly 1.5.1\\appdata\\logs", "*.log"),
            #endregion

            #region VK Play Game Center
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter", "*.html"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\File System\\Origins", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\IndexedDB\\%unknowfolder%", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\Local Storage\\leveldb", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\Session Storage", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\shared_proto_db", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\VideoDecodeStats", "*log*"),

            /*Cross Fire */
            new DirectoryPatern("D:\\GameCenter\\Cross Fire\\x64", "*.log"),
            new DirectoryPatern("C:\\GameCenter\\Cross Fire\\x64", "*.log"),
            new DirectoryPatern("C:\\GameCenter\\Cross Fire\\Log", "*"),
            new DirectoryPatern("D:\\GameCenter\\Cross Fire\\Log", "*"),

            /* StalCraft */
            new DirectoryPatern("C:\\GameCenter\\Stalcraft\\-gup-", "*.log"),
            new DirectoryPatern("D:\\GameCenter\\Stalcraft\\-gup-", "*.log"),
            new DirectoryPatern("C:\\GameCenter\\Stalcraft\\logs", "*.log"),
            new DirectoryPatern("D:\\GameCenter\\Stalcraft\\logs", "*.log"),
            #endregion

            #region Origin
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Origin", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Origin", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Origin\\SelfUpdate\\Staged", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Origin\\SelfUpdate\\Staged\\support\\Privacy and Cookie Policy", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Origin\\SelfUpdate\\Staged\\support\\User Agreement", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Origin\\SelfUpdate", "*.html"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Origin\\Logs", "*.data"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Origin\\Logs", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Origin\\ThinSetup", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Origin\\ThinSetup\\%unknowfolder%", "*.txt"),
            #endregion

            #region Opera GX
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Programs\\Opera GX\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Programs\\Opera GX", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\CertificateRevocation\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Crash Reports\\reports", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Extension Rules", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Extension Scripts", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Extension State", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\GCM Store", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\IndexedDB\\%unknowfolder%", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Local Extension Setting\\%unknowfolder%", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Local Storage\\leveldb", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Session Storage", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\shared_proto_db", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Site Characteristics Database", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Storage\\ext\\sync-login\\def\\Local Storage\\leveldb", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Storage\\ext\\sync-login\\def\\Session Storage", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Sync Data\\LevelDB", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Sync Extension Settings\\%unknowfolder%", "*log*"),
            #endregion

            #region Google Chrome
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\CertificateRevocation\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Crash Reports\\reports", "*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Extension Rules", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Extension Scripts", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Extension State", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\GCM Store", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\IndexedDB\\%unknowfolder%", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Local Extension Setting\\%unknowfolder%", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Local Storage\\leveldb", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Session Storage", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\shared_proto_db", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Site Characteristics Database", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Storage\\ext\\sync-login\\def\\Local Storage\\leveldb", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Storage\\ext\\sync-login\\def\\Session Storage", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Sync Data\\LevelDB", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\Sync Extension Settings\\%unknowfolder%", "*log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Google\\Chrome\\%unknowfolder%\\WidevineCdm", "LICENSE"),
            #endregion

            #region Yandex Browser
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\Application\\%unknowfolder%", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\coupon_db", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Extension Scripts", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Extension State", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Local Storage\\leveldb", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Platform Notifications", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Session Storage", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\shared_proto_db", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Site Characteristics Database", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Sync Data\\LevelDB", "*log*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Yandex\\YandexBrowser", "*log*"),
            #endregion

            #region Brave Browser
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\CertificateRevocation\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\AutofillStrikeDatabase", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\BudgetDatabase", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\commerce_subscription_db", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\coupon_db", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Download Service\\EntryDB", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Extension Scripts", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Extension State", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Feature Engagement Tracker\\AvailabilityDB", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Feature Engagement Tracker\\EventDB", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\GCM Store\\Encryption", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Local Storage\\leveldbn", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Segmentation Platform\\SegmentInfoDB", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Segmentation Platform\\SignalDB", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Segmentation Platform\\SignalStorageConfigDB", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Session Storage", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\shared_proto_db", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Site Characteristics Database", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Sync Data\\LevelDB", "*log*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default", "LOG"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default", "README"),
            #endregion

            #region ozProtect
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\ozProtect\\jre", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\ozProtect\\jre", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\ozProtect\\jre", "release"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\ozProtect\\jre", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\ozProtect\\jre", "COPYRIGHT"),
            #endregion

            #region Razer
            new DirectoryPatern("%cycdrive%\\ProgramData\\Razer\\Services\\Logs", "*.log"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Razer\\RazerCortexManifestRepair\\Logs", "*.log"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Razer\\BigDataSDK\\Logs", "*.log"),
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

            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\ChromeAdapter\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\ChromeAdapter\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Microsoft\\VisualStudio\\ChromeAdapter\\%unknowfolder%", "*.md"),
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
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.BigNox", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Nox\\BigNoxInstallPack", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Nox\\vmInstall", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Nox", "Nox.log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Nox", "Log_multi.log*"),
            new DirectoryPatern("C:\\Users\\%username%\\.BigNox", "*.log*"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Nox\\bin\\BignoxVMS\\nox\\Logs", "*.log"),
            new DirectoryPatern("D:\\Program Files\\Nox\\bin\\BignoxVMS\\nox\\Logs", "*.log"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\vmlogs"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Nox", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Bignox\\BigNoxVM\\vcredist", "*.txt"),
            #endregion

            #region Java
            new DirectoryPatern("%cycdrive%\\ProgramData\\Oracle\\Java\\.oracle_jre_usage", "*.timestamp"),

            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "COPYRIGHT"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Java\\%unknowfolder%", "release"),

            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Java\\%unknowfolder%", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Java\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Java\\%unknowfolder%", "COPYRIGHT"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Java\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Java\\%unknowfolder%", "release"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "ASSEMBLY_EXCEPTION"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "THIRD_PARTY_README"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "ADDITIONAL_LICENSE_INFO"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%", "release"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%\\legal"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.jdks\\%unknowfolder%\\sample", "README"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.loliland\\java", "COPYRIGHT"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.loliland\\java", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.loliland\\java", "README.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.loliland\\java", "release"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.loliland\\java", "THIRDPARTYLICENSEREADME.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.loliland\\java", "THIRDPARTYLICENSEREADME-JAVAFX.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.loliland\\java", "Welcome.html"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\exjava\\jvm", "COPYRIGHT"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\exjava\\jvm", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\exjava\\jvm", "release"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\java\\%unknowfolder%", "ASSEMBLY_EXCEPTION"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\java\\%unknowfolder%", "CLASSPATH_EXCEPTION_NOTE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\java\\%unknowfolder%", "DISCLAIMER"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\java\\%unknowfolder%", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\java\\%unknowfolder%", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\java\\%unknowfolder%", "*.html"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\java\\%unknowfolder%", "release"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\runtime\\jre-legacy\\windows\\jre-legacy", "COPYRIGHT"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\runtime\\jre-legacy\\windows\\jre-legacy", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\runtime\\jre-legacy\\windows\\jre-legacy", "release"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\runtime\\jre-legacy\\windows\\jre-legacy", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\runtime\\jre-legacy\\windows\\jre-legacy", "*.html"),
            #endregion

            #region Minecraft
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\logs", "*.log*"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\crash-reports"),

            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\crash-reports"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs", "*log*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\blclient\\chat", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\blclient\\crashes", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\blclient\\crash-reports", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\blclient\\js", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\blclient\\mcinject", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\blclient\\minecraft", "*"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\klauncher", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\logs\\tlauncher", "*"),


            new DirectoryPatern("%cycdrive%\\AkrienAntiLeak\\clients\\AkrienPremium\\game\\logs", "*.log"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\curseforge\\minecraft\\Instances\\%unknowfolder%\\logs", "*.log*"),

            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.cristalix\\updates\\Minigames\\logs", "*"),
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
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Radmin VPN", "eula.txt"),
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
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\EasyAntiCheat\\%unknowfolder%", "*.log"),
            #endregion

            #region OBS Studio
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\obs-studio\\logs", "*.log"),
            new DirectoryPatern("C:\\Users\\%username%\\AppData\\Roaming\\obs-studio\\logs", "*.txt"),
            #endregion

            #region GitHub Desktop
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\SquirrelTemp", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\GitHub Desktop\\logs", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GitHubDesktop", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GitHubDesktop\\%unknowfolder%", "*.log"),
            #endregion

            #region Overwolf
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\Log", "*.html"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\temp", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\temp", "*.json"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Overwolf\\BrowserCache", "*.log"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\Overwolf\\Log", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Overwolf\\%unknowfolder%", "*.log"),
            new DirectoryFull("%cycdrive%\\Program Files (x86)\\Overwolf\\%unknowfolder%\\Licenses"),
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
            new DirectoryPatern("%steam%", "*.crash"),
            new DirectoryPatern("%steam%", "*.html"),
            new DirectoryPatern("%steam%\\steamui", "licenses.txt"),

            /* Ironsight_wpg */
            new DirectoryPatern("%steam%\\steamapps\\common\\Ironsight_wpg", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Ironsight_wpg", "*.txt"),

            /* Terraria */
            new DirectoryPatern("%steam%\\steamapps\\common\\Terraria", "changelog.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Terraria", "changelog.txt"),

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
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Innersloth\\Among Us", "*.log"),

            /* Idle Research */
            new DirectoryPatern("%steam%\\steamapps\\common\\Idle Research", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Idle Research", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\CryptoGrounds\\Idle Research", "*.log"),

            /* Dota 2 */
            new DirectoryPatern("%steam%\\steamapps\\common\\dota 2 beta\\game", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\dota 2 beta\\game", "*.txt"),

            /* Unturned */
            new DirectoryPatern("%steam%\\steamapps\\common\\Unturned", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Unturned", "*.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Unturned\\BattlEye", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Unturned\\BattlEye", "*.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Unturned\\BattlEye\\Privacy", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Unturned\\BattlEye\\Privacy", "*.txt"),
            new DirectoryFull("%steam%\\steamapps\\common\\Unturned\\Logs"),
            new DirectoryFull("D:\\SteamLibrary\\steamapps\\common\\Unturned\\Logs"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Unturned\\Extras\\Rocket.Unturned", "*.md"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Unturned\\Extras\\Rocket.Unturned", "*.md"),

            /* Warframe */
            new DirectoryPatern("%steam%\\steamapps\\common\\Warframe\\Tools\\OpenSSL\\x64", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Warframe\\Tools\\OpenSSL\\x64", "*.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Warframe\\Tools\\ZStandard", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Warframe\\Tools\\ZStandard", "*.txt"),

            /* Idle Skilling */
            new DirectoryPatern("%steam%\\steamapps\\common\\Idle Skilling", "*.txt"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Idle Skilling", "*.txt"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Idle Skilling", "*.html"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Idle Skilling", "*.html"),

            /* Crafting Idle Clicker */
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Bling Bling Games GmbH\\Crafting Idle Clicker\\Browser", "*.log"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Bling Bling Games GmbH\\Crafting Idle Clicker", "*.log"),

            /* Lords Mobile */
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\IGG\\Lords Mobile", "*.txt"),
            #endregion

            #region DevExpress
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\DevExpress", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\DevExpress 21.2\\Components", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\DevExpress 21.2\\Components\\Support", "*.log"),
            #endregion

            #region DotNET
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\dotnet\\shared", "*.rtf"),
            #endregion

            #region Unity
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\plastic4\\logs", "*.txt"),
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
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Xamarin\\Simulator", "*.rtf"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Xamarin\\Simulator", "*.txt"),
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
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\Google\\Picasa3\\cdautorun", "*.url"),
            #endregion

            #region Microsoft Web Deploy V3
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3", "*.txt"),
            #endregion

            #region IIS Express
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\IIS Express", "*.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\IIS Express", "*.url"),
            new DirectoryPatern("%cycdrive%\\Program Files (x86)\\IIS Express", "ThirdPartyNotices.txt"),
            #endregion

            #region BitTorrentHelper
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\BitTorrentHelper", "*.log"),
            #endregion

            #region Notepad++
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++", "readme.txt"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++", "LICENSE"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Notepad++", "*.log"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++\\updater", "*.md"),
            new DirectoryPatern("%cycdrive%\\Program Files\\Notepad++\\updater", "LICENSE"),
            #endregion

            #region iTop Screen Recorder
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\iTop Screen Recorder\\Logs", "*.log")
            #endregion
        };

        public static List<WorkingI> images = new List<WorkingI>()
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
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.cristalix\\updates\\Minigames\\screenshots", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.minecraft\\screenshots", "*"),
            #endregion

            #region Android
            new DirectoryFullAndroid("Android\\media\\com.whatsapp\\WhatsApp\\Media\\WhatsApp Images"),
            new DirectoryFullAndroid("Android\\media\\org.telegram.messenger\\Telegram\\Telegram Images"),
            new DirectoryFullAndroid("Pictures"),
            new DirectoryFullAndroid("DCIM\\Camera"),
            new DirectoryFullAndroid("DCIM\\Screenshots"),
            new DirectoryFullAndroid("DroidCamX"),
            #endregion
        };

        public static List<WorkingI> media = new List<WorkingI>()
        {
            #region Bandicam
            new DirectoryFull("%cycdrive%\\Users\\%username%\\Documents\\Bandicam"),
            #endregion

            #region Android
            new DirectoryFullAndroid("Android\\media\\com.whatsapp\\WhatsApp\\Media\\WhatsApp Video"),
            new DirectoryFullAndroid("Android\\media\\org.telegram.messenger\\Telegram\\Telegram Video"),
            #endregion

            #region Minecraft
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\replay_recordings", "*.mcpr"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\curseforge\\minecraft\\Instances\\%unknowfolder%\\replay_recordings", "*.mcpr"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\replay_recordings", "*.mcpr"),
            #endregion
        };

        public static List<WorkingI> cache = new List<WorkingI>()
        {
            #region Cifrazia
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\cache\\%unknowfolder%", "*"),
            #endregion

            #region Verus Desktop
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Verus-Desktop\\Cache\\Cache_Data", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Verus-Desktop\\GPUCache", "*"),
            #endregion

            #region WoW (Sirus)
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Sirus Launcher\\Cache", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Sirus Launcher\\GPUCache", "*"),
            #endregion

            #region Cifrazia
            new DirectoryFull("%cycdrive%\\Cifrazia\\temp"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Cifrazia\\DesktopApplication\\cache\\qmlcache", "*"),
            #endregion

            #region Gradle
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\.gradle\\.tmp", "*.bin"),
            #endregion

            #region Microsoft Lobe
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Lobe\\Cache", "*"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Lobe\\Code Cache"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Lobe\\GPUCache"),
            #endregion

            #region Minecraft
            new DirectoryFull("%cycdrive%\\Users\\%username%\\.cristalix\\updates\\Minigames\\squidgame"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\.cristalix\\updates\\Minigames\\modelCache"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\.cristalix\\updates\\Minigames\\cache"),
            #endregion

            #region Lords Mobile
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\IGG\\Lords Mobile\\%unknowfolder%"),
            #endregion

            #region VintageStory
            new DirectoryPatern("%cycdrive%\\VintageStory\\Mods", "*.pdb"),
            new DirectoryPatern("D:\\VintageStory\\Mods", "*.pdb"),
            #endregion

            #region Stalker Anomaly
            new DirectoryFull("%cycdrive%\\Stalker\\Anomaly 1.5.1\\appdata\\shaders_cache\\r4"),
            #endregion

            #region VK Play Game Center
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\Code Cache\\js", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\Cache\\Cache_Data", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\GameCenter\\Cache\\Chrome\\GPUCache", "*"),
            #endregion

            #region Windows
            new DirectoryPatern("%cycdrive%\\Games\\%unknowfolder%\\htmlcache", "*"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Microsoft\\CryptnetUrlCache\\Content"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\LocalLow\\Microsoft\\CryptnetUrlCache\\MetaData"),
            #endregion

            #region Opera GX
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable\\Code Cache\\js", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Opera Software\\Opera GX Stable", "*.tmp"),
            #endregion

            #region Yandex Browser
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\Application\\%unknowfolder%\\ntp\\NativeCacheStorage\\web_ntp_cache", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Cache\\Cache_Data", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Code Cache\\js", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\Code Cache\\wasm", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\GPUCache", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\Default\\TurboAppCache\\Nativecache\\%unknowfolder%", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\GrShaderCache\\GPUCache", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\ShaderCache\\GPUCache", "*"),
            #endregion

            #region Brave Browser
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Cache\\Cache_Data", "*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Code Cache\\js", "*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Code Cache\\wasm", "*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\DawnCache", "*"),
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default\\GPUCache", "*"),
            #endregion

            #region Driver Booster
            new DirectoryPatern("%cycdrive%\\ProgramData\\IObit\\Driver Booster\\Download", "*.dbo*"),
            new DirectoryPatern("%cycdrive%\\ProgramData\\IObit\\Driver Booster\\Download", "*.dbx*"),
            #endregion

            #region LGHUB
            new DirectoryPatern("%cycdrive%\\ProgramData\\LGHUB\\cache", "*"),
            #endregion

            #region Discord
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord", "*.tmp"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Cache", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\js", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\js\\index-dir", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\wasm", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Code Cache\\wasm\\index-dir", "*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\discord\\Service Worker\\CacheStorage\\%unknowfolder%", "*.txt"),
            #endregion

            #region Steam
            new DirectoryPatern("%steam%\\config\\avatarcache", "*.png"),   
            new DirectoryPatern("%steam%\\appcache\\stats", "*.bin"),
            new DirectoryPatern("%steam%\\appcache\\librarycache", "*.jpg"),
            new DirectoryPatern("%steam%\\appcache\\librarycache", "*.png"),
            new DirectoryPatern("%steam%\\dumps", "*.dmp"),
            new DirectoryFull("%steam%\\appcache\\httpcache"),

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

            #region Python
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Local\\pip\\cache"),
            #endregion
        };

        public static List<WorkingI> cheats = new List<WorkingI>()
        {
            #region AlterNative
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\AlterNative Hack"),
            #endregion

            #region Pandora
            new DirectoryFull("%steam%\\steamapps\\common\\Counter-Strike Global Offensive\\Pandora"),
            new DirectoryFull("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive\\Pandora"),
            #endregion

            #region HPP
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\AltFixHpp"),
            #endregion

            #region ANGIGNIGHT
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\ANGIGNIGHT Hack"),
            #endregion

            #region Gamesense
            new DirectoryFull("%steam%\\steamapps\\common\\Counter-Strike Global Offensive\\gamesense"),
            new DirectoryFull("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive\\gamesense"),
            #endregion

            #region Reborn Injector
            new DirectoryFull("%cycdrive%\\RebornInjector"),
            #endregion

            #region Monolith
            new DirectoryFull("%cycdrive%\\Monolith"),
            #endregion

            #region LegendWare
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\Legendware"),
            #endregion

            #region HPP
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\hpp"),
            #endregion

            #region NeverLose
            new DirectoryPatern("%cycdrive%\\", "NeverBSOD.log"),
            new DirectoryFull("%steam%\\steamapps\\common\\Counter-Strike Global Offensive\\nl"),
            new DirectoryFull("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive\\nl"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.signatures"),
            #endregion

            #region OTCv2 and Eternity
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.cfg"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.cfg"),
            new DirectoryPatern("%steam%\\steamapps\\common\\Counter-Strike Global Offensive", "*.ini"),
            new DirectoryPatern("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive", "*.ini"),
            #endregion

            #region Weave
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\weave"),
            #endregion

            #region rebornhack
            new DirectoryFull("%cycdrive%\\rebornhack"),
            #endregion

            #region NixWare
            new DirectoryFull("%cycdrive%\\nixware"),
            new DirectoryFull("%steam%\\steamapps\\common\\Counter-Strike Global Offensive\\nix"),
            new DirectoryFull("D:\\SteamLibrary\\steamapps\\common\\Counter-Strike Global Offensive\\nix"),
            #endregion

            #region Rawetrip
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\rawetripp"),
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

            #region Impact
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\Impact"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\Impact"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\curseforge\\minecraft\\Instances\\%unknowfolder%\\Impact"),
            #endregion

            #region Supremacy
            new DirectoryFull("%cycdrive%\\supremacy-csgo"),
            #endregion

            #region Meteor Client
            new DirectoryFull("cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\meteor-client"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\meteor-client"),
            new DirectoryFull("%cycdrive%\\Users\\%username%\\curseforge\\minecraft\\Instances\\%unknowfolder%\\meteor-client"),
            #endregion

            #region Baritone
            new DirectoryPatern("cycdrive%\\Users\\%username%\\AppData\\Roaming\\.minecraft\\.fabric\\processedMods", "*baritone*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\AppData\\Roaming\\PolyMC\\instances\\%unknowfolder%\\.minecraft\\.fabric\\processedMods", "*baritone*"),
            new DirectoryPatern("%cycdrive%\\Users\\%username%\\curseforge\\minecraft\\Instances\\%unknowfolder%\\.fabric\\processedMods", "*baritone*"),
            #endregion

            #region Minecraft (Cristalix MAS)
            new DirectoryFull("%cycdrive%\\Users\\%username%\\.cristalix\\updates\\Minigames\\MAS"),
            #endregion
        };

        public static List<WorkingI> lastactivity_safe = new List<WorkingI>()
        {
            new DirectoryPatern("C:\\Windows\\Minidump", "*"),
            new DirectoryUnsafeFileNames("%cycdrive%\\Windows\\Prefetch", new SafeNames().names)
        };

        public static List<WorkingI> lastactivity_full = new List<WorkingI>()
        {
            new DirectoryPatern("%cycdrive%\\Windows\\Prefetch", "*.pf")
        };

        public static List<WorkingI> accounts = new List<WorkingI>()
        {
            #region Steam accounts
            new DirectoryPatern("%steam%\\config", "loginusers.vdf"),
            new DirectoryFull("%steam%\\userdata"),
            #endregion
        };
    }
}
