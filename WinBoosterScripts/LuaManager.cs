using NLua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WinBoosterScripts.Classes;
using Console = WinBoosterScripts.Classes.Console;

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
