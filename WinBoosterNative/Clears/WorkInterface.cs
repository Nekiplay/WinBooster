using System;
using System.Collections.Generic;

namespace WinBooster.Native
{
    public interface WorkingI
    {
        string GetDirectory();
        string GetPattern();
        List<string> GetSafeNames();
        Tuple<long, long> Work();
    }
}
