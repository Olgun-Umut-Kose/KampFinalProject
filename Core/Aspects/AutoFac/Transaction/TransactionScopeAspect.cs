using System;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interception;
using Core.Utilities.Results;

namespace Core.Aspects.AutoFac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    scope.Complete();
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    invocation.ReturnValue = new ErrorResult("Bir sorun ile karşılaşıldı: " + e.Message + "inner: " +
                                                             e.InnerException.Message);
                }
            }
        }
    }
}