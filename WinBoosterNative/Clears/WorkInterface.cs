using System.Collections.Generic;

namespace WinBooster.Native
{
    public interface WorkingI
    {
        string GetDirectory();
        string GetPattern();
        List<string> GetSafeNames();
        long Work();
    }
}
