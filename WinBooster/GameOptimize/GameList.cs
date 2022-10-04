using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBooster.GameOptimize.Games;

namespace WinBooster.GameOptimize
{
    public class GameList
    {
        public List<GameOptimizeI> games = new List<GameOptimizeI>()
        {
            new Minecraft()
        };
    }
}
