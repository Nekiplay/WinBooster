﻿namespace WinBooster.GameOptimize
{
    public interface GameOptimizeI
    {
        string GameName();
        void Optimize();

        bool GameInstalled();

        void SetOptimizeData(params int[] data);
    }
}
