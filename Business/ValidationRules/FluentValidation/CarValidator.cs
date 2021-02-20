using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).NotEmpty();  // Burada predicate dediğimiz delegasyon var
            RuleFor(p => p.Description).MinimumLength(10);
            RuleFor(p => p.Description).Must(StartWithA).WithMessage("Açıklama A harfi ile başlamalı");

            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.BrandId == 1);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");  // A ile başlarsa true döner.
        }
    }
}
