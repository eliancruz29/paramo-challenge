using System;

namespace Sat.Recruitment.Domain.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Message = msg;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Message { get; }

        public static Result Success(string msg) => new Result(true, msg);
        
        public static Result Error(string msg) => new Result(false, msg);

        public static Result<TValue> Success<TValue>(TValue value, string msg) => new Result<TValue>(value, true, msg);

        public static Result<TValue> Error<TValue>(TValue value, string msg) => new Result<TValue>(value, false, msg);
    }
}
