using System.Collections.Generic;
using WinBooster.Native;

namespace WinBoosterDataBase
{
    public class FixerData
    {
        public List<FixerI> fixers = new List<FixerI>()
        {
            new AutoRun(),
            new X7_Oscar_Keyboard_Editor(),
            new TaskManager(),
            new Regedit(),
            new NoClose(),
            new ViewContextMenu()
        };

    }
}
