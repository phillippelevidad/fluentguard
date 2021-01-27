using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentGuard
{
    public static class GuardClauseExtensions
    {
        public static IGuardClauseWithInput<T> Must<T>(this IGuardClauseWithInput<T> guardClause, Func<T, bool> predicate, string? errorMessage = null)
        {
            if (!predicate.Invoke(guardClause.Input))
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"Input {guardClause.Name} does not satisfy precondition."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> MustNot<T>(this IGuardClauseWithInput<T> guardClause, Func<T, bool> predicate, string? errorMessage = null)
        {
            if (predicate.Invoke(guardClause.Input))
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"Input {guardClause.Name} satisfies forbidden precondition."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotDefault<T>(this IGuardClauseWithInput<T> guardClause, string? errorMessage = null)
        {
            if (EqualityComparer<T>.Default.Equals(guardClause.Input, default))
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"Required input {guardClause.Name} is empty."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<T> NotNull<T>(this IGuardClauseWithInput<T> guardClause, string? errorMessage = null)
        {
            if (guardClause.Input is null)
            {
                guardClause.Errors.Add(new ArgumentNullException(
                    guardClause.Name, errorMessage ?? $"Required input {guardClause.Name} is null."));
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<IEnumerable<T>> NotNullOrEmpty<T>(this IGuardClauseWithInput<IEnumerable<T>> guardClause, string? errorMessage = null)
        {
            NotNull(guardClause);

            if (!guardClause.Input.Any())
            {
                guardClause.Errors.Add(new ArgumentException(
                    guardClause.Name, errorMessage ?? $"Required input {guardClause.Name} is empty."));
            }

            return guardClause;
        }

        public static IGuardResult OnSuccess(this IGuardClause guardClause, Action action)
        {
            if (guardClause.HasFailed)
                return GuardResult.Failure(guardClause.Errors);

            action.Invoke();
            return GuardResult.Success();
        }

        public static IGuardResult<TResult> OnSuccess<TResult>(this IGuardClause guardClause, Func<TResult> func)
        {
            if (guardClause.HasFailed)
                return GuardResult.Failure<TResult>(guardClause.Errors);

            return GuardResult.Success(func());
        }

        public static IGuardClauseWithInput<T> ThrowIfError<T>(this IGuardClauseWithInput<T> guardClause, Func<IGuardClause, Exception>? exceptionGenerator = null)
        {
            if (guardClause.HasFailed)
            {
                var exception = exceptionGenerator?.Invoke(guardClause)
                    ?? (guardClause.Errors.Count == 1
                        ? guardClause.Errors[0].Value
                        : new AggregateException(guardClause.Errors.GetExceptions()));
                throw exception;
            }

            return guardClause;
        }

        public static IGuardClauseWithInput<TNewInput> With<TCurrentInput, TNewInput>(this IGuardClauseWithInput<TCurrentInput> guardClause, TNewInput input, string name)
        {
            var newGuardClause = new Guard<TNewInput>(input, name);
            newGuardClause.Errors.AddRange(guardClause.Errors);
            return newGuardClause;
        }
    }
}
