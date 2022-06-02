using EmployeesTracking.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.ValidationRules
{
    public class PersonelValidator : AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.Adi).NotEmpty().WithMessage("İsim alanını  boş geçemezsiniz");
            RuleFor(x => x.Adi).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");

            RuleFor(x => x.BabaAdi).NotEmpty().WithMessage("Baba Adını boş geçemezsiniz");

            RuleFor(x => x.AnaAdi).NotEmpty().WithMessage("Ana Adını  boş geçemezsiniz");
        }
    }
}
