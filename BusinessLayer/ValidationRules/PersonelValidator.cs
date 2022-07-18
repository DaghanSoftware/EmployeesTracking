using BusinessLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.ValidationRules
{
    public class PersonelValidator : AbstractValidator<PersonelViewModel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.Adi).NotEmpty().WithMessage("İsim alanını  boş geçemezsiniz");
            RuleFor(x => x.Adi).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");

            RuleFor(x => x.Soyadi).NotEmpty().WithMessage("Soyadı alanını  boş geçemezsiniz");

            RuleFor(x => x.BabaAdi).NotEmpty().WithMessage("Baba adını boş geçemezsiniz");

            //RuleFor(x => x.TcNo).NotEmpty().WithMessage("Tc kimlik numarasını boş geçemezsiniz");
            //RuleFor(x => x.TcNo).GreaterThan(11111111111).WithMessage("Tc kimlik numarası 11 haneli olmalıdır");
            RuleFor(x => x.TcNo).Must(x => x.ToString().Length == 11).WithMessage("Tc kimlik numarası 11 haneli olmalıdır");
            //RuleFor(x => x.TcNo).Must(x =>x ==11).WithMessage("Tc Kimlik Numarası 11 haneli olmalıdır");
            //RuleFor(x => x.TcNo).NotNull().WithMessage("Lütfen Tc kimlik numarasını giriniz").InclusiveBetween(11, 11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.");

            RuleFor(x => x.AnaAdi).NotEmpty().WithMessage("Ana adını  boş geçemezsiniz");

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Lütfen Cinsiyet Seçimi Yapınız");

            RuleFor(x => x.MaritalStatusId).NotEmpty().WithMessage("Lütfen Medeni Durum Seçimi Yapınız");

            RuleFor(x => x.CityId).NotEmpty().WithMessage("Lütfen doğum yerini seçiniz");
            RuleFor(x => x.DistrictId).NotEmpty().WithMessage("Lütfen  ilçeyi seçiniz seçiniz");
        }
    }
}
