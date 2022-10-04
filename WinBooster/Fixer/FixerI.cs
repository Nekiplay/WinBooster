namespace WinBooster.Fixer
{
    public interface FixerI
    {
        bool NeedFix();
        void Fix();
    }
}
