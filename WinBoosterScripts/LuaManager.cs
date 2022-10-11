using NLua;
using System.IO;
using System.Text;
using WinBoosterScripts.Classes;
using Console = WinBoosterScripts.Classes.Console;
using Directory = WinBoosterScripts.Classes.Directory;
using File = WinBoosterScripts.Classes.File;
using Random = WinBoosterScripts.Classes.Random;

namespace WinBoosterScripts
{
    public class LuaManager
    {
        public bool RunLua(FileInfo file)
        {
            if (file.Exists)
            {
                using (Lua lua = new Lua())
                {
                    lua.State.Encoding = Encoding.UTF8;
                    lua["Randon"] = new Random();
                    lua["File"] = new File();
                    lua["Directory"] = new Directory();
                    lua["Console"] = new Console();
                    lua["Cleaner"] = new Cleaner();
                    var luaObject = lua.DoFile(file.FullName);
                    return true;
                }
            }
            return false;
        }
    }
}
