namespace WinBooster
{
    public class Statistic : AppSettings<Statistic>
    {
        public long TotalGodClears;

        public long TotalSizeClear;
        public long TotalDeletedFiles;

        public long MaximumDeletedFiles;
        public long MaximumSizeClear;

        public long TotalFixes;
    }
}
