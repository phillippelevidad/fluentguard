using System;
using System.Text.RegularExpressions;

namespace FluentGuard
{
    public static class GuardClauseStringExtensions
    {
        public static IGuardClauseWithInput<string> MaxLength(this IGuardClauseWithInput<string> guardClause, int maxLength, string? errorMessage = null)
        {
            return guardClause.Length(int.MinValue, maxLength, errorMessage);
        }

        public static IGuardClauseWithInput<string> MinLength(this IGuardClauseWithInput<string> guardClause, int minLength, string? errorMessage = null)
        {
            return guardClause.Length(minLength, int.MaxValue, errorMessage);
        }

        public static IGuardClauseWithInput<string> Length(this IGuardClauseWithInput<string> guardClause, int minLength, int maxLength, string? errorMessage = null)
        {
            if (guardClause.Input != null)
            {
                if (guardClause.Input.Length < minLength)
                {
                    guardClause.Errors.Add(new ArgumentException(
                        guardClause.Name, errorMessage ?? $"{guardClause.Name} must have at least {minLength} characters."));
                }

                if (guardClause.Input.Length > maxLength)
                {
                    guardClause.Errors.Add(new ArgumentException(
                        guardClause.Name, errorMessage ?? $"{guardClause.Name} must have at most {maxLength} characters."));
                }
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<string> NotNullOrEmpty(this IGuardClauseWithInput<string> guardClause, string? errorMessage = null)
        {
            if (string.IsNullOrEmpty(guardClause.Input))
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"Required input {guardClause.Name} was empty."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<string> NotNullOrWhiteSpace(this IGuardClauseWithInput<string> guardClause, string? errorMessage = null)
        {
            NotNullOrEmpty(guardClause);

            if (string.IsNullOrWhiteSpace(guardClause.Input))
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"Required input {guardClause.Name} was empty."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<string> Match(this IGuardClauseWithInput<string> guardClause, string pattern, RegexOptions options = RegexOptions.None, string? errorMessage = null)
        {
            if (!Regex.IsMatch(guardClause.Input, pattern, options))
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} was not in the required format."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<string> NotMatch(this IGuardClauseWithInput<string> guardClause, string pattern, RegexOptions options = RegexOptions.None, string? errorMessage = null)
        {
            if (Regex.IsMatch(guardClause.Input, pattern, options))
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"{guardClause.Name} was in a format that is not allowed."));
            }

            return guardClause;
        }
    }
}
