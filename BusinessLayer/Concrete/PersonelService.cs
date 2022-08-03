using Libraries.EmployeesTracking.Core.Models.ViewModel;
using Libraries.EmployeesTracking.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.EmployeesTracking.Core.Repositories;
using EmployeesTracking.Core;
using Libraries.EmployeesTracking.Core.Services;
using LinqKit;

namespace Libraries.EmployeesTracking.Services.Concrete
{
    public class PersonelService : IPersonelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonelService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Personel GetById(int id)
        {
            throw new NotImplementedException();
            //return _personelDal.GetById(id);
        }

        public List<Personel> GetList()
        {
            throw new NotImplementedException();
        }

        public List<PersonelViewModel> PersonelleriListele(string q, int gendernumber, int maritalnumber, int sehir, DateTime baslangictarih, DateTime bitistarih, int Districtid, int page = 1)
        {
            var predicate = PredicateBuilder.New<Personel>();
            predicate = predicate.And(te => te.Id > 0);

            if (gendernumber > 0)
                predicate = predicate.And(te => te.GenderId == gendernumber);
            if (maritalnumber > 0)
                predicate = predicate.And(te => te.MaritalStatusId == maritalnumber);
            if (sehir > 0)
                predicate = predicate.And(te => te.CityId == sehir);
            if (Districtid > 0)
                predicate = predicate.And(te => te.DistrictId == Districtid);
            if (baslangictarih != DateTime.MinValue && bitistarih != DateTime.MinValue)
            {
                predicate = predicate.And(te => te.DogumTarihi >= baslangictarih && te.DogumTarihi <= bitistarih);
            }
            if (!string.IsNullOrEmpty(q))
            {
                predicate = predicate.And(te => te.Adi.ToLower().Contains(q.ToLower()) || te.Soyadi.ToLower().Contains(q.ToLower()));
            }

            var query = (from p in _unitOfWork._Personels.Table.Where(predicate)
                         from s in _unitOfWork._Genders.Table.Where(x => x.GenderId == p.GenderId).DefaultIfEmpty()
                         from c in _unitOfWork._Cities.Table.Where(x => x.CityId == p.CityId).DefaultIfEmpty()
                         from m in _unitOfWork._MaritalStatus.Table.Where(x => x.MaritalStatusId == p.MaritalStatusId).DefaultIfEmpty()
                         from d in _unitOfWork._Districts.Table.Where(x => x.DistrictId == p.DistrictId).DefaultIfEmpty()
                             //where p.GenderId==gendernumber || p.MaritalStatusId==maritalnumber
                         select new PersonelViewModel
                         {
                             Id = p.Id,
                             Adi = p.Adi,
                             Soyadi = p.Soyadi,
                             TcNo = p.TcNo,
                             BabaAdi = p.BabaAdi,
                             AnaAdi = p.AnaAdi,
                             GenderId = p.GenderId,
                             GenderName = s.GenderName,
                             MaritalStatusId = p.MaritalStatusId,
                             MaritalStatusName = m.MaritalStatusName,
                             CityId = p.CityId,
                             CityName = c.CityName,
                             DistrictName = d.DistrictName
                         }).ToList();

            return query;
        }

        public void TAdd(Personel t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Personel t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Personel t)
        {
            throw new NotImplementedException();
        }
    }
}
