using System;

namespace FluentGuard
{
    public static class GuardClauseDateTimeExtensions
    {
        public static IGuardClauseWithInput<DateTime> NotOutOfSqlDateRange(this IGuardClauseWithInput<DateTime> guardClause, string? errorMessage = null)
        {
            const long sqlMinDateTicks = 552877920000000000;
            const long sqlMaxDateTicks = 3155378975999970000;

            return guardClause.NotOutOfRange(new DateTime(sqlMinDateTicks), new DateTime(sqlMaxDateTicks), errorMessage: errorMessage);
        }
    }
}
