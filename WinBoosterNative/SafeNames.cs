using System.Collections.Generic;

namespace WinBooster.Native
{
    public class SafeNames
    {
        public bool IsSafeName(string text)
        {
            bool safe = false;
            foreach (string name in names)
            {
                if (text.Contains(name))
                {
                    safe = true;
                }
            }
            foreach (string name in files)
            {
                if (text == name)
                {
                    safe = true;
                }
            }
            return safe;
        }
        public List<string> names = new List<string>()
        {
            "JAVAW.EXE",
            "JAVA.EXE",
            "OPERA_AUTOUPDATE.EXE",
            "OPERA.EXE",
            "PICASA3.EXE",
            "STEAM.EXE",
            "STEAMSERVICE.EXE",
            "STEAMWEBHELPER.EXE",
            "DISCORD.EXE",
            "CMD.EXE",
            "CONHOST.EXE",
            "SVCHOST.EXE",
            "TASKMGR.EXE",
            "TASKHOSTW.EXE",
            "SYSTRAY.EXE",
            "SYSTEMSETTINGSBROKER.EXE",
            "TEXTINPUTHOST.EXE",
            "TIWORKER.EXE",

            "rundll32.exe",
            "notepad.exe",
            "Taskmgr.exe",
            "cmd.exe",
            "rundll32.exe",
            "conhost.exe",
            "explorer.exe",
            "notepad++.exe",
            "opera.exe",
            "git.exe",

            "Discord.exe",
            "Telegram.exe",

            "PolyMC.exe",
            "Terraria.exe",
            "HL2.EXE",
            "csgo.exe",

            "regedit.exe",
            "mmc.exe",
            "TCPSVCS.EXE",
            "java.exe",
            "javaw.exe",
            "msiexec.exe",
            "OpenWith.exe",
            "readedWaitDialog.exe",
        };
        public List<string> files = new List<string>()
        {
            "C:\\Windows\\System32\\dwm.exe",
            "C:\\Windows\\hh.exe",
            "C:\\Windows\\System32\\csrss.exe",
            "C:\\Windows\\System32\\ApplicationFrameHost.exe",
            "C:\\Windows\\System32\\WerFault.exe",
            "C:\\Windows\\System32\\wlrmdr.exe",
            "C:\\Windows\\SysWOW64\\WerFault.exe",
            "C:\\Program Files\\WinRAR\\WinRAR.exe",
            "C:\\Windows\\System32\\dllhost.exe",
            "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe",
        };
        public SafeNames()
        {

        }
    }
}
