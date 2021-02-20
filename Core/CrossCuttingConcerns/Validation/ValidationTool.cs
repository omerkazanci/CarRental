using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            // CarValidator carValidator = new CarValidator();  // Buna ihtiyaç kalmadı. Çünkü CarValidator sınıfı AbstractValidator abstract sınıfından
            // implementasyon yapar. AbstractValidator sınıfı da IValidator'dan implementasyon yapıyor. Bu kullanım yerine Validator olarak IValidator 
            // veririm ve referans tutuculuğunu kullanarak istediğim Validator sınıfını bu yapıya gönderebilirim.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
