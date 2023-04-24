using System;

namespace Sat.Recruitment.Domain.Shared
{
    public class Result<TValue> : Result
    {
        private readonly TValue _value;

        protected internal Result(TValue value, bool isSuccess, string errors)
            : base(isSuccess, errors) => _value = value;

        public TValue Value => _value;
    }
}
