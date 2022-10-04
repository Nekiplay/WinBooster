﻿using System.Collections.Generic;

namespace WinBooster.Fixer
{
    public class FixerData
    {
        public List<FixerI> fixers = new List<FixerI>()
        {
            new Fixes.TaskManager(),
            new Fixes.Regedit(),
            new Fixes.NoClose(),
            new Fixes.ViewContextMenu()
        };

    }
}