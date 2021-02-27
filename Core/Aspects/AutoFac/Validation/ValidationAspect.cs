using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;
using Core.Cross_Cutting_Concerns.Validation;
using Core.Utilities.Interception;
using Core.Utilities.Results;
using FluentValidation;

namespace Core.Aspects.AutoFac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Geçersiz Validator Girildi");
            }

            _validatorType = validatorType;

        }

        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator = (IValidator) Activator.CreateInstance(_validatorType);
            Type entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = invocation.Arguments?.Where(t => t.GetType() == entityType);
            foreach (object entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
            
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            invocation.ReturnValue = new ErrorResult("Bir sorun ile karşılaşıldı: " + e.Message);
        }
    }
}