using System;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        
        public T Data { get; }


        protected DataResult(bool success, string message,T data) : base(success, message)
        {
            Data = data;
        }

        protected DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }
    }
}