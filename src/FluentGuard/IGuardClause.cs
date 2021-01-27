namespace FluentGuard
{
    public interface IGuardClause
    {
        bool HasFailed { get; }
        Errors Errors { get; }
    }
}
