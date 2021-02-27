using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interception
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        
        protected virtual void OnBefore(IInvocation invocation){}
        protected virtual void OnAfter(IInvocation invocation){}
        protected virtual void OnException(IInvocation invocation, Exception e){}
        protected virtual void OnSuccess(IInvocation invocation){}
        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;
            try
            {
                OnBefore(invocation);
                invocation.Proceed();
                OnAfter(invocation);
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
        }
    }
}