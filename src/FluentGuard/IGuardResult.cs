namespace FluentGuard
{
    public interface IGuardResult
    {
        bool IsFailure { get; }
        bool IsSuccess { get; }
        Errors Errors { get; }

        public void Deconstruct(out bool isSuccess, out Errors errors)
        {
            isSuccess = IsSuccess;
            errors = Errors;
        }
    }

    public interface IGuardResult<T> : IGuardResult
    {
        T? Value { get; }

        public void Deconstruct(out bool isSuccessful, out Errors errors, out T? value)
        {
            isSuccessful = IsSuccess;
            errors = Errors;
            value = Value;
        }
    }
}