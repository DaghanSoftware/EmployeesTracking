using Libraries.EmployeesTracking.Core.Models.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Services.ValidationRules
{
    public class AdminRegisterValidator : AbstractValidator<RegisterModel>
    {
        public AdminRegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanını  boş geçemezsiniz");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Mail Alanını 50 karakterden daha fazla giremezsiniz.");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Mail Alanını 5 karakterden daha az giremezsiniz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mailiniz formatı mail formatında değildir.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanını  boş geçemezsiniz");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı alanını  boş geçemezsiniz");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanını  boş geçemezsiniz");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı alanını  boş geçemezsiniz");
        }
    }
}
