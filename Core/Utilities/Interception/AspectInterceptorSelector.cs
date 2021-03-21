using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Core.Aspects.AutoFac.Performance;


namespace Core.Utilities.Interception
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
           List<MethodInterceptionBaseAttribute> classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
           var methodAttributes =
               type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
           if (methodAttributes != null)
           {
               classAttributes.AddRange(methodAttributes);
               classAttributes.Add(new PerformansAspect(10));
           }

           // ReSharper disable once CoVariantArrayConversion
           return classAttributes.OrderByDescending(x => x.Priority).ToArray();
           
           
               
        }
    }
}