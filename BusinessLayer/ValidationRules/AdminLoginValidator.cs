using BusinessLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.ValidationRules
{
    public class AdminLoginValidator : AbstractValidator<LoginModel>
    {
        public AdminLoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanını  boş geçemezsiniz");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Mail Alanını 50 karakterden daha fazla giremezsiniz.");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Mail Alanını 5 karakterden daha az giremezsiniz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mailiniz formatı mail formatında değildir.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanını  boş geçemezsiniz");

        }
        
    }
}
