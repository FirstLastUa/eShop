namespace eShop.Domain.Core.Primitives.Result
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get; }

        public static Result Success() => new(true, Error.None);

        public static Result<TValue> Success<TValue>(TValue value) =>
            new(value, true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Failure<TValue>(Error error) =>
            new(default, false, error);

        /// <summary>
        /// Creates a new <see cref="Result{TValue}"/> with the specified nullable value and the specified error.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="value">The result value.</param>
        /// <param name="error">The error in case the value is null.</param>
        /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified value or an error.</returns>
        public static Result<TValue> Create<TValue>(TValue value, Error error)
            where TValue : class
            => value is null ? Failure<TValue>(error) : Success(value);
    }
}
