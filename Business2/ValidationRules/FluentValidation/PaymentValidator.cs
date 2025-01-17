﻿using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.ValidationRules.FluentValidation
{
  public   class PaymentValidator:AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.NameSurname).NotEmpty();
            RuleFor(p => p.CardNo).NotEmpty();
            RuleFor(p => p.ExpirationDate).NotEmpty();
            RuleFor(p => p.Cvc).NotEmpty();
        }
    }
}
