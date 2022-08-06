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
using System.IO;

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


        

        public PersonelViewModel PersonelEkleGuncellePartial(int? id)
        {
            PersonelViewModel model;
            Personel personel;
            if (id > 0)
            {
                personel = _unitOfWork._Personels.Table.FirstOrDefault(m => m.Id == id);
                // ViewBag.Ilceler = new SelectList(_context.Districts.Where(x => x.CityID == personel.CityId).ToList(), "DistrictId", "DistrictName");
                model = new PersonelViewModel
                {
                    Id = personel.Id,
                    Adi = personel.Adi,
                    Soyadi = personel.Soyadi,
                    TcNo = personel.TcNo,
                    BabaAdi = personel.BabaAdi,
                    AnaAdi = personel.AnaAdi,
                    GenderId = personel.GenderId,
                    MaritalStatusId = personel.MaritalStatusId,
                    CityId = personel.CityId,
                    DistrictId = personel.DistrictId,
                    DogumTarihi = DateTime.Parse(personel.DogumTarihi.ToShortDateString()),
                    Resim = personel.Resim,
                    Biyografi = personel.Biyografi,
                    PhoneNumber = personel.PhoneNumber,
                    Mail = personel.Mail,
                    Hakkinda = personel.Hakkinda,
                    Position = personel.Position,
                    Adres = personel.Adres,
                    KurumBaslamaTarihi = DateTime.Parse(personel.KurumBaslamaTarihi.ToShortDateString())
                };
                return model;
            }
            else
            {
                model = new PersonelViewModel
                {
                    DogumTarihi = DateTime.Parse(DateTime.Now.ToShortDateString()),
                    KurumBaslamaTarihi = DateTime.Parse(DateTime.Now.ToShortDateString())
                };
                return model;
            }
        }

        public void PersonelEkle(PersonelViewModel personelgelenveri)
        {
            Personel personel = new Personel();
            personel.Adi = personelgelenveri.Adi;
            personel.Soyadi = personelgelenveri.Soyadi;
            personel.BabaAdi = personelgelenveri.BabaAdi;
            personel.TcNo = personelgelenveri.TcNo;
            personel.AnaAdi = personelgelenveri.AnaAdi;
            personel.GenderId = personelgelenveri.GenderId;
            personel.MaritalStatusId = personelgelenveri.MaritalStatusId;
            personel.CityId = personelgelenveri.CityId;
            personel.DistrictId = personelgelenveri.DistrictId;
            personel.DogumTarihi = DateTime.Parse(personelgelenveri.DogumTarihi.ToShortDateString());
            personel.Biyografi = personelgelenveri.Biyografi;
            personel.PhoneNumber = personelgelenveri.PhoneNumber;
            personel.Mail = personelgelenveri.Mail;
            personel.Hakkinda = personelgelenveri.Hakkinda;
            personel.Position = personelgelenveri.Position;
            personel.Adres = personelgelenveri.Adres;
            personel.KurumBaslamaTarihi = DateTime.Parse(personelgelenveri.KurumBaslamaTarihi.ToShortDateString());
            _unitOfWork._Personels.Add(personel);
            _unitOfWork.Commit();
        }
        public void PersonelGüncelle(PersonelViewModel personelgelenveriguncelle)
        {
            Personel personel = _unitOfWork._Personels.Get(personelgelenveriguncelle.Id);
            personel.Adi = personelgelenveriguncelle.Adi;
            personel.Soyadi = personelgelenveriguncelle.Soyadi;
            personel.BabaAdi = personelgelenveriguncelle.BabaAdi;
            personel.TcNo = personelgelenveriguncelle.TcNo;
            personel.AnaAdi = personelgelenveriguncelle.AnaAdi;
            personel.GenderId = personelgelenveriguncelle.GenderId;
            personel.MaritalStatusId = personelgelenveriguncelle.MaritalStatusId;
            personel.CityId = personelgelenveriguncelle.CityId;
            personel.DistrictId = personelgelenveriguncelle.DistrictId;
            personel.DogumTarihi = DateTime.Parse(personelgelenveriguncelle.DogumTarihi.ToShortDateString());
            personel.Biyografi = personelgelenveriguncelle.Biyografi;
            personel.PhoneNumber = personelgelenveriguncelle.PhoneNumber;
            personel.Mail = personelgelenveriguncelle.Mail;
            personel.Hakkinda = personelgelenveriguncelle.Hakkinda;
            personel.Position = personelgelenveriguncelle.Position;
            personel.Adres = personelgelenveriguncelle.Adres;
            personel.KurumBaslamaTarihi = DateTime.Parse(personelgelenveriguncelle.KurumBaslamaTarihi.ToShortDateString());
            _unitOfWork._Personels.Update(personel);
            _unitOfWork.Commit();
        }

        PersonelDetayCardViewModel IPersonelService.PersonelDetayCardPartial(int id)
        {
            var query = (from p in _unitOfWork._Personels.Table
                         from s in _unitOfWork._Genders.Table.Where(x => x.GenderId == p.GenderId).DefaultIfEmpty()
                         from c in _unitOfWork._Cities.Table.Where(x => x.CityId == p.CityId).DefaultIfEmpty()
                         from m in _unitOfWork._MaritalStatus.Table.Where(x => x.MaritalStatusId == p.MaritalStatusId).DefaultIfEmpty()
                             //where p.GenderId==gendernumber || p.MaritalStatusId==maritalnumber
                         select new PersonelDetayCardViewModel
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
                             Resim = p.Resim
                         });

            var yazarlar = query.FirstOrDefault(x => x.Id == id);
            return yazarlar;
        }

        public PersonelDetayCardViewModel PersonelImageUploadCardModel(int id)
        {
            var query = (from p in _unitOfWork._Personels.Table
                         from s in _unitOfWork._Genders.Table.Where(x => x.GenderId == p.GenderId).DefaultIfEmpty()
                         from c in _unitOfWork._Cities.Table.Where(x => x.CityId == p.CityId).DefaultIfEmpty()
                         from m in _unitOfWork._MaritalStatus.Table.Where(x => x.MaritalStatusId == p.MaritalStatusId).DefaultIfEmpty()
                             //where p.GenderId==gendernumber || p.MaritalStatusId==maritalnumber
                         select new PersonelDetayCardViewModel
                         {
                             Id = p.Id,
                             Adi = p.Adi,
                             Soyadi = p.Soyadi,
                             Resim = p.Resim
                         });

            var yazarlar = query.FirstOrDefault(x => x.Id == id);
            return yazarlar;
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

        public void PersonelSil(int id)
        {
            Personel personel = _unitOfWork._Personels.Get(id);
            _unitOfWork._Personels.Remove(personel);
            _unitOfWork.Commit();
        }

        public async Task PersonelImageUpload(PersonelImageUpdateModel personelgelenresimverisi)
        {
            Personel personel = _unitOfWork._Personels.Get(personelgelenresimverisi.Id);

            var extension = Path.GetExtension(personelgelenresimverisi.Resim.FileName);
            var newimagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
            var stream = new FileStream(location, FileMode.Create);
            personelgelenresimverisi.Resim.CopyTo(stream);
            personel.Resim = newimagename;
            await _unitOfWork.CommitAsync();
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
