using System.Collections.Generic;

namespace FluentGuard
{
    public class GuardResult : IGuardResult
    {
        public GuardResult(bool isSuccessful, Errors errors)
        {
            IsSuccess = isSuccessful;
            IsFailure = !isSuccessful;
            Errors = errors;
        }

        public static GuardResult Success() => new GuardResult(true, Errors.Empty());
        public static GuardResult Failure(Errors errors) => new GuardResult(false, new Errors(errors));

        public static GuardResult<T> Success<T>(T value) => new GuardResult<T>(true, value, Errors.Empty());
        public static GuardResult<T> Failure<T>(Errors errors) => new GuardResult<T>(false, default, new Errors(errors));

        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public Errors Errors { get; }
    }

    public class GuardResult<T> : GuardResult, IGuardResult<T>
    {
        public GuardResult(bool isSuccessful, T? value, Errors errors) : base(isSuccessful, errors)
        {
            Value = value;
        }

        public T? Value { get; }
    }
}
