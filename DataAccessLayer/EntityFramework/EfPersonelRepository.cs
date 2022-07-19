using CoreLayer.Models;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EmployeesTracking;
using EntityLayer.Concrete;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPersonelRepository : GenericRepository<Personel>, IPersonelDal
    {
        public List<PersonelViewModel> GetListAllPersonelOrFilterPersonel(string q, int gendernumber, int maritalnumber, int sehir, DateTime baslangictarih, DateTime bitistarih, int Districtid, int page = 1)
        {
            using (var _context = new Context())
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

                var query = (from p in _context.Personels.Where(predicate)
                             from s in _context.Genders.Where(x => x.GenderId == p.GenderId).DefaultIfEmpty()
                             from c in _context.Cities.Where(x => x.CityId == p.CityId).DefaultIfEmpty()
                             from m in _context.MaritalStatus.Where(x => x.MaritalStatusId == p.MaritalStatusId).DefaultIfEmpty()
                             from d in _context.Districts.Where(x => x.DistrictId == p.DistrictId).DefaultIfEmpty()
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

        }
    }
}
