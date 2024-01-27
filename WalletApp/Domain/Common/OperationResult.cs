namespace WalletApp.Domain.Common
{
    public class OperationResult<T> : OperationResult
    {
        public T? Data { get; }

        private OperationResult(T? data, string? message = null, bool isSuccessful = true)
            : base(message, isSuccessful)
        {
            Data = data;
        }

        public static OperationResult<T> Success(T? data = default) =>
            new(data);

        public static OperationResult<T> Success(string message, T? data = default) =>
            new(data, message);

        public static OperationResult<T> Failure(string message, T? data = default) =>
            new(data, message, false);
    }

    public class OperationResult
    {
        public bool IsSuccessful { get; }

        public string? Message { get; }

        public OperationResult(string? message = null, bool isSuccessful = true)
        {
            Message = message;
            IsSuccessful = isSuccessful;
        }

        public static OperationResult Success() => new();

        public static OperationResult Failure(string? message) => new(message, false);

        public static OperationResult Success(string? message) => new(message);
    }
}
