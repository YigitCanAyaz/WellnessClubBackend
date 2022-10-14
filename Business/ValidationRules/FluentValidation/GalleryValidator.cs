using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class GalleryValidator : AbstractValidator<Gallery>
    {
        public GalleryValidator()
        {
            RuleFor(g => g.ImagePath).NotEmpty();
            RuleFor(g => g.ImageName).NotEmpty();
        }
    }
}
