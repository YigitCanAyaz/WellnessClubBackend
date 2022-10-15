using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CollaborationValidator : AbstractValidator<Collaboration>
    {
        public CollaborationValidator()
        {
           RuleFor(c => c.Title).NotEmpty();
           RuleFor(c => c.Description).NotEmpty();
        }
    }
}
