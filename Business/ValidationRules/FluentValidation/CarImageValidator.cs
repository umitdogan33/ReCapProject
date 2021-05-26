using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.Date_).NotEmpty();
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.ImagePath).NotEmpty();
        }
    }
}
