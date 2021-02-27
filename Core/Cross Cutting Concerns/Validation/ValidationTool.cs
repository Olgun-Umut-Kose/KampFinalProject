using System;
using FluentValidation;
using FluentValidation.Results;


namespace Core.Cross_Cutting_Concerns.Validation
{
    public class ValidationTool
    {
        public static void Validate<T> (IValidator validator,T entity )
        {
            ValidationContext<T> validationContext = new ValidationContext<T>(entity);
            ValidationResult result = validator.Validate(validationContext);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}