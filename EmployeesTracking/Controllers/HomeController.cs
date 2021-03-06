using ClosedXML.Excel;
using EmployeesTracking.Filter;
using FluentValidation.Results;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using EmployeesTracking.ValidationRules;
using BusinessLayer.ValidationRules;
using CoreLayer.Models;

namespace EmployeesTracking.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {

        PersonelManager pm = new PersonelManager(new EfPersonelRepository());

        private readonly Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            return View();
        }
        public IActionResult PersonelListele()
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            return View();
        }

        public IActionResult PersonelListesiPartial(string q, int gendernumber, int maritalnumber, int sehir, DateTime baslangictarih, DateTime bitistarih, int Districtid, int page = 1)
        {
            var personeller = pm.PersonelleriListele(q,gendernumber,maritalnumber,sehir,baslangictarih,bitistarih,Districtid,page);
            return View(personeller);
        }
        public IActionResult PersonelEkleGuncellePartial(int? id)
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");

            PersonelViewModel model;
            Personel personel;
            if (id > 0)
            {
                personel = _context.Personels.FirstOrDefault(m => m.Id == id);
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
            }
            else
            {
                model = new PersonelViewModel
                {
                    DogumTarihi = DateTime.Parse(DateTime.Now.ToShortDateString()),
                    KurumBaslamaTarihi = DateTime.Parse(DateTime.Now.ToShortDateString())
                };
            }
            return PartialView("_PersonelEkleGuncellePartial", model);
        }

        [HttpPost]
        public IActionResult PersonelKaydet(PersonelViewModel personelGelen)
        {
            try
            {

                var sonucMesaji = "";
                PersonelValidator validationRules = new PersonelValidator();
                ValidationResult result = validationRules.Validate(personelGelen);
                var response = new ReturnModel();
                List<string> ValidationMessages = new List<string>();

                if (!result.IsValid)
                {
                    foreach (ValidationFailure failure in result.Errors)
                    {
                        ValidationMessages.Add(failure.ErrorMessage);
                    }
                    response.Message2 = ValidationMessages;
                    return Json(new ReturnModel() { Success = false, Message2 = response.Message2 });
                }



                if (personelGelen.Id > 0)
                {
                    sonucMesaji = "Güncelleme işlemi başarıyla yapıldı";
                    var personel = _context.Personels.SingleOrDefault(p => p.Id == personelGelen.Id);
                    personel.Adi = personelGelen.Adi;
                    personel.Soyadi = personelGelen.Soyadi;
                    personel.BabaAdi = personelGelen.BabaAdi;
                    personel.TcNo = personelGelen.TcNo;
                    personel.AnaAdi = personelGelen.AnaAdi;
                    personel.GenderId = personelGelen.GenderId;
                    personel.MaritalStatusId = personelGelen.MaritalStatusId;
                    personel.CityId = personelGelen.CityId;
                    personel.DistrictId = personelGelen.DistrictId;
                    personel.DogumTarihi = DateTime.Parse(personelGelen.DogumTarihi.ToShortDateString());
                    //personel.Resim = personelGelen.Resim;
                    personel.Biyografi = personelGelen.Biyografi;
                    personel.PhoneNumber = personelGelen.PhoneNumber;
                    personel.Mail = personelGelen.Mail;
                    personel.Hakkinda = personelGelen.Hakkinda;
                    personel.Position = personelGelen.Position;
                    personel.Adres = personelGelen.Adres;
                    personel.KurumBaslamaTarihi = DateTime.Parse(personelGelen.KurumBaslamaTarihi.ToShortDateString());
                    //if (personelGelen.Resim != null)
                    //{
                    //    var extension = Path.GetExtension(personelGelen.Resim.FileName);
                    //    var newimagename = Guid.NewGuid() + extension;
                    //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    //    var stream = new FileStream(location, FileMode.Create);
                    //    personelGelen.Resim.CopyTo(stream);
                    //    personel.Resim = newimagename;
                    //}
                }
                else
                {
                    sonucMesaji = "Ekleme işlemi başarıyla yapıldı";
                    Personel personel = new Personel();
                    personel.Adi = personelGelen.Adi;
                    personel.Soyadi = personelGelen.Soyadi;
                    personel.BabaAdi = personelGelen.BabaAdi;
                    personel.TcNo = personelGelen.TcNo;
                    personel.AnaAdi = personelGelen.AnaAdi;
                    personel.GenderId = personelGelen.GenderId;
                    personel.MaritalStatusId = personelGelen.MaritalStatusId;
                    personel.CityId = personelGelen.CityId;
                    personel.DistrictId = personelGelen.DistrictId;
                    personel.DogumTarihi = DateTime.Parse(personelGelen.DogumTarihi.ToShortDateString());
                    personel.Biyografi = personelGelen.Biyografi;
                    personel.PhoneNumber = personelGelen.PhoneNumber;
                    personel.Mail = personelGelen.Mail;
                    personel.Hakkinda = personelGelen.Hakkinda;
                    personel.Position = personelGelen.Position;
                    personel.Adres = personelGelen.Adres;
                    personel.KurumBaslamaTarihi = DateTime.Parse(personelGelen.KurumBaslamaTarihi.ToShortDateString());
                    //if (personelGelen.Resim != null)
                    //{
                    //    var extension = Path.GetExtension(personelGelen.Resim.FileName);
                    //    var newimagename = Guid.NewGuid() + extension;
                    //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    //    var stream = new FileStream(location, FileMode.Create);
                    //    personelGelen.Resim.CopyTo(stream);
                    //    personel.Resim = newimagename;
                    //}
                    _context.Personels.Add(personel);

                }
                _context.SaveChanges();

                return Json(new ReturnModel() { Success = true, Message = sonucMesaji });
            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false, Message = "hatalı işlem" });
            }
        }
        public IActionResult PersonelSil(int id)
        {
            try
            {
                _context.Personels.Remove(_context.Personels.SingleOrDefault(e => e.Id == id));
                _context.SaveChanges();

                return Json(new ReturnModel() { Success = true, Message = "Silme İşlemi Başarıyla Gerçekleşti" });
            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false, Message = ex.Message });
            }

            //var yazarlar = "Başarılı Bir Şekilde Silindi";
            //var jsonWriters = JsonConvert.SerializeObject(yazarlar);
            //return Json(jsonWriters);
            //var jsonWriters = JsonConvert.SerializeObject(employee);
            //return Json(jsonWriters);
        }

        public IActionResult PersonelDetayCardPartial(int id)
        {

            var query = (from p in _context.Personels
                         from s in _context.Genders.Where(x => x.GenderId == p.GenderId).DefaultIfEmpty()
                         from c in _context.Cities.Where(x => x.CityId == p.CityId).DefaultIfEmpty()
                         from m in _context.MaritalStatus.Where(x => x.MaritalStatusId == p.MaritalStatusId).DefaultIfEmpty()
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
            return PartialView("_PersonelDetayCardPartial", yazarlar);
        }

        public IActionResult PersonelImageUploadCardModel(int id)
        {

            var query = (from p in _context.Personels
                         from s in _context.Genders.Where(x => x.GenderId == p.GenderId).DefaultIfEmpty()
                         from c in _context.Cities.Where(x => x.CityId == p.CityId).DefaultIfEmpty()
                         from m in _context.MaritalStatus.Where(x => x.MaritalStatusId == p.MaritalStatusId).DefaultIfEmpty()
                             //where p.GenderId==gendernumber || p.MaritalStatusId==maritalnumber
                         select new PersonelDetayCardViewModel
                         {
                             Id = p.Id,
                             Adi = p.Adi,
                             Soyadi = p.Soyadi,
                             Resim = p.Resim
                         });

            var yazarlar = query.FirstOrDefault(x => x.Id == id);
            return PartialView("_PersonelImageUploadModalPartial", yazarlar);
        }
        [HttpPost]
        public IActionResult PersonelImageUpload(PersonelImageUpdateModel personelGelen)
        {

            try
            {

                var sonucMesaji = "";
                PersonelImageUpdateValidator validationRules = new PersonelImageUpdateValidator();
                ValidationResult result = validationRules.Validate(personelGelen);
                var response = new ReturnModel();
                List<string> ValidationMessages = new List<string>();

                if (!result.IsValid)
                {
                    foreach (ValidationFailure failure in result.Errors)
                    {
                        ValidationMessages.Add(failure.ErrorMessage);
                    }
                    response.Message2 = ValidationMessages;
                    return Json(new ReturnModel() { Success = false, Message2 = response.Message2 });
                }



                if (personelGelen.Resim != null)
                {
                    sonucMesaji = "Resim Güncelleme işlemi başarıyla yapıldı";
                    var personel = _context.Personels.SingleOrDefault(p => p.Id == personelGelen.Id);

                    var extension = Path.GetExtension(personelGelen.Resim.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    personelGelen.Resim.CopyTo(stream);
                    personel.Resim = newimagename;
                    _context.SaveChanges();

                    return Json(new ReturnModel() { Success = true, Message = sonucMesaji });

                }
                else
                {
                    sonucMesaji = "Lütfen resim seçiniz";
                    return Json(new ReturnModel() { Success = false, Message = sonucMesaji });

                }

            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false, Message = "hatalı işlem" });
            }
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Personel Listesi");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Adı";
                worksheet.Cell(1, 3).Value = "Soyadi";
                worksheet.Cell(1, 4).Value = "BabaAdi";
                worksheet.Cell(1, 5).Value = "AnaAdi";
                worksheet.Cell(1, 6).Value = "TcNo";

                int BlogRowCount = 2;
                foreach (var item in BlogTitlelist())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.Adi;
                    worksheet.Cell(BlogRowCount, 3).Value = item.Soyadi;
                    worksheet.Cell(BlogRowCount, 4).Value = item.BabaAdi;
                    worksheet.Cell(BlogRowCount, 5).Value = item.AnaAdi;
                    worksheet.Cell(BlogRowCount, 6).Value = item.TcNo;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PersonelListesi.xlsx");
                }
            }
        }

        public List<PersonelDetayCardViewModel> BlogTitlelist()
        {
            List<PersonelDetayCardViewModel> bm = new List<PersonelDetayCardViewModel>();
            bm = _context.Personels.Select(x => new PersonelDetayCardViewModel
            {
                Id = x.Id,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                BabaAdi = x.BabaAdi,
                AnaAdi = x.AnaAdi,
                TcNo = x.TcNo

            }).ToList();

            return bm;
        }

        public IActionResult PersonelIlcePartial(int? id)
        {
            var result = _context.Districts.Where(x => x.CityID == id).ToList();
            if (id > 0)
            {

                return Json(new SelectList(result, "DistrictId", "DistrictName"));
            }
            return Json(new SelectList(_context.Districts.Where(x => x.CityID == 0).ToList(), "DistrictId", "DistrictName"));
        }

        public IActionResult Test(int? id)
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");

            PersonelViewModel model;
            Personel personel;
            if (id > 0)
            {
                personel = _context.Personels.FirstOrDefault(m => m.Id == id);
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
                    DogumTarihi = DateTime.Parse(personel.DogumTarihi.ToShortDateString())
                };
            }
            else
            {
                model = new PersonelViewModel
                {
                    DogumTarihi = DateTime.Parse(DateTime.Now.ToShortDateString())
                };
            }
            return PartialView("Test", model);
        }
    }
}
