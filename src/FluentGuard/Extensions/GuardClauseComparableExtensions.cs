using System;
using System.Collections.Generic;

namespace FluentGuard
{
    public static class GuardClauseComparableExtensions
    {
        public static IGuardClauseWithInput<T> GreaterThan<T>(this IGuardClauseWithInput<T> guardClause, T minValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(minValue) <= 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} be greater than {minValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> GreaterThanOrEqualTo<T>(this IGuardClauseWithInput<T> guardClause, T minValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(minValue) < 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} be greater than or equal to {minValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> LessThan<T>(this IGuardClauseWithInput<T> guardClause, T maxValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(maxValue) >= 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} be less than {maxValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> LessThanOrEqualTo<T>(this IGuardClauseWithInput<T> guardClause, T maxValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(maxValue) > 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} be less than or equal to {maxValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> Negative<T>(this IGuardClauseWithInput<T> guardClause, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(default) >= 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} must be negative."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NegativeOrZero<T>(this IGuardClauseWithInput<T> guardClause, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(default) > 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} must be negative or zero."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotGreaterThan<T>(this IGuardClauseWithInput<T> guardClause, T maxValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(maxValue) > 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} not be greater than {maxValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotGreaterThanNorEqualTo<T>(this IGuardClauseWithInput<T> guardClause, T maxValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(maxValue) >= 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} not be greater than nor equal to {maxValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotLessThan<T>(this IGuardClauseWithInput<T> guardClause, T minValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(minValue) < 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} not be less than {minValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotLessThanNorEqualTo<T>(this IGuardClauseWithInput<T> guardClause, T minValue, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(minValue) <= 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} not be greater than nor equal to {minValue}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotInRange<T>(this IGuardClauseWithInput<T> guardClause, T from, T to, bool exclusive = false, string? errorMessage = null)
            where T : IComparable<T>
        {
            var comparer = Comparer<T>.Default;

            var inRange = comparer.Compare(guardClause.Input, from) >= 0 || comparer.Compare(guardClause.Input, to) <= 0;
            var inRangeExclusive = comparer.Compare(guardClause.Input, from) > 0 || comparer.Compare(guardClause.Input, to) < 0;

            if ((exclusive && inRangeExclusive) || (!exclusive && inRange))
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} was in forbidden range {from} to {to}."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotNegative<T>(this IGuardClauseWithInput<T> guardClause, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(default) < 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} must not be negative."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotNegativeNorZero<T>(this IGuardClauseWithInput<T> guardClause, string? errorMessage = null)
            where T : struct, IComparable<T>
        {
            if (guardClause.Input.CompareTo(default) <= 0)
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} must not be negative nor zero."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotOutOfRange<T>(this IGuardClauseWithInput<T> guardClause, T from, T to, bool inclusive = false, string? errorMessage = null)
            where T : IComparable<T>
        {
            var comparer = Comparer<T>.Default;

            var outOfRange = comparer.Compare(guardClause.Input, from) < 0 || comparer.Compare(guardClause.Input, to) > 0;
            var outOrRangeInclusive = comparer.Compare(guardClause.Input, from) <= 0 || comparer.Compare(guardClause.Input, to) >= 0;

            if (outOfRange || (inclusive && outOrRangeInclusive))
            {
                guardClause.Errors.Add(new ArgumentOutOfRangeException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} was out of expected range {from} to {to}."));
            }

            return guardClause;
        }
    }
}
