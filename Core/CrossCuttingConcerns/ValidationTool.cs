using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns
{
   public static class ValidationTool
    {
        public static void Validate(IValidator validator,object Entity)
        {
            var Context = new ValidationContext<object>(Entity);
            var result = validator.Validate(Context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
                        
        }
    }
}
