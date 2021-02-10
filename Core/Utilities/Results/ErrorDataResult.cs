namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        // ReSharper disable once UnusedMember.Global
        public ErrorDataResult(string message, T data) : base(false, message, data)
        {
        }

        // ReSharper disable once UnusedMember.Global
        public ErrorDataResult(T data) : base(false, data)
        {
            
        }

        public ErrorDataResult(string message) : base(false,message,default)
        {
            
        }
    }
}