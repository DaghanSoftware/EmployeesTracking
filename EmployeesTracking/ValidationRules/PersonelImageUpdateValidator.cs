using EmployeesTracking.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.ValidationRules
{
    public class PersonelImageUpdateValidator : AbstractValidator<PersonelImageUpdateModel>
    {
        public PersonelImageUpdateValidator()
        {
            RuleFor(x => x.Resim).NotEmpty().WithMessage("resim alanını  boş geçemezsiniz");
        }
    }
}
