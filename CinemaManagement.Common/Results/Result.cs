namespace CinemaManagement.Common.Results
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public string? ErrorMessage { get; protected set; }

        public static Result Success() => new() { IsSuccess = true };
        public static Result Fail(string message) => new() { IsSuccess = false, ErrorMessage = message };
    }

    public class Result<T> : Result
    {
        public T? Data { get; private set; }

        public static Result<T> Success(T data) => new() { IsSuccess = true, Data = data };
        public new static Result<T> Fail(string message) => new() { IsSuccess = false, ErrorMessage = message };
    }
}