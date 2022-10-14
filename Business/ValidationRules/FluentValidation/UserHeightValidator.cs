﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class UserHeightValidator : AbstractValidator<UserHeight>
    {
        public UserHeightValidator()
        {
            // RuleFor().();
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.HeightId).NotEmpty();
        }
    }
}