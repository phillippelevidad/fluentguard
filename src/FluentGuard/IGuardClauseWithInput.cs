namespace FluentGuard
{
    public interface IGuardClauseWithInput<TInput> : IGuardClause
    {
        TInput Input { get; }
        string Name { get; }
    }
}
