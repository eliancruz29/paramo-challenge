using System;

namespace Sat.Recruitment.Domain.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, string msg)
        {
            IsSuccess = isSuccess;
            Message = msg;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Message { get; }

        public static Result Success(string msg = null) => new Result(true, msg);
        
        public static Result Error(string msg = null) => new Result(false, msg);

        public static Result<TValue> Success<TValue>(TValue value, string msg = null) => new Result<TValue>(value, true, msg);

        public static Result<TValue> Error<TValue>(TValue value, string msg = null) => new Result<TValue>(value, false, msg);
    }
}
