namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        

        // ReSharper disable once UnusedMember.Global
        public SuccessDataResult(string message, T data) : base(true, message, data)
        {
        }

        public SuccessDataResult(T data) : base(true, data)
        {
        }

        // ReSharper disable once UnusedMember.Global
        public SuccessDataResult(string message): base(true,message,default)
        {
            
        }
    }
}