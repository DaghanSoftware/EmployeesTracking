using ClosedXML.Excel;
using EmployeesTracking.Entities;
using EmployeesTracking.Models;
using EmployeesTracking.ValidationRules;
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

namespace EmployeesTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeesContext _context;

        public HomeController(EmployeesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            return View();
        }

        public IActionResult PersonelListesiPartial(string q, int gendernumber, int maritalnumber, int sehir,DateTime baslangictarih,DateTime bitistarih, int page = 1)
        {
            var predicate = PredicateBuilder.New<Personel>();
            predicate = predicate.And(te => te.Id > 0);

            if (gendernumber > 0)
                predicate = predicate.And(te => te.GenderId == gendernumber);
            if (maritalnumber > 0)
                predicate = predicate.And(te => te.MaritalStatusId == maritalnumber);
            if (sehir > 0)
                predicate = predicate.And(te => te.CityId == sehir);
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
                             DistrictName=d.DistrictName
                         }).ToList();

            return View(query);
        }
        public IActionResult PersonelPartial(int? id)
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            ViewBag.Ilce = new SelectList(_context.Districts.Where(x => x.CityID == id).ToList(), "DistrictId", "DistrictName");
            PersonelViewModel model;
            Personel personel;
            if (id > 0)
            {
                personel = _context.Personels.FirstOrDefault(m => m.Id == id);
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
                    DogumTarihi = DateTime.Parse(personel.DogumTarihi.ToShortDateString())
            };
            }
            else
            {
                model = new PersonelViewModel { 
                DogumTarihi=  DateTime.Parse(DateTime.Now.ToShortDateString())
                };
            }
            return PartialView("_PersonelPartial", model);
        }

        [HttpPost]
        public IActionResult PersonelKaydet(PersonelViewModel personelGelen)
        {
            try
            {
                PersonelValidator validationRules = new PersonelValidator();
                ValidationResult result = validationRules.Validate(personelGelen);
                var sonucMesaji = "";
                if (!result.IsValid)
                    throw new Exception("validasyon hatası");

                
                if (personelGelen.Id > 0)
                {

                    var personel = _context.Personels.SingleOrDefault(p => p.Id == personelGelen.Id);
                    personel.Adi = personelGelen.Adi;
                    personel.Soyadi = personelGelen.Soyadi;
                    personel.BabaAdi = personelGelen.BabaAdi;
                    personel.TcNo = personelGelen.TcNo;
                    personel.AnaAdi = personelGelen.AnaAdi;
                    personel.GenderId = personelGelen.GenderId;
                    personel.MaritalStatusId = personelGelen.MaritalStatusId;
                    personel.CityId = personelGelen.CityId;
                    personel.DogumTarihi = DateTime.Parse(personelGelen.DogumTarihi.ToShortDateString());
                    if (personelGelen.Resim != null)
                    {
                        var extension = Path.GetExtension(personelGelen.Resim.FileName);
                        var newimagename = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                        var stream = new FileStream(location, FileMode.Create);
                        personelGelen.Resim.CopyTo(stream);
                        personel.Resim = newimagename;
                    }
                }
                else
                {
                    Personel personel = new Personel();
                    personel.Adi = personelGelen.Adi;
                    personel.Soyadi = personelGelen.Soyadi;
                    personel.BabaAdi = personelGelen.BabaAdi;
                    personel.TcNo = personelGelen.TcNo;
                    personel.AnaAdi = personelGelen.AnaAdi;
                    personel.GenderId = personelGelen.GenderId;
                    personel.MaritalStatusId = personelGelen.MaritalStatusId;
                    personel.CityId = personelGelen.CityId;
                    personel.DogumTarihi = DateTime.Parse(personelGelen.DogumTarihi.ToShortDateString());
                    if (personelGelen.Resim != null)
                    {
                        var extension = Path.GetExtension(personelGelen.Resim.FileName);
                        var newimagename = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                        var stream = new FileStream(location, FileMode.Create);
                        personelGelen.Resim.CopyTo(stream);
                        personel.Resim = newimagename;
                    }
                    _context.Personels.Add(personel);

                }
                _context.SaveChanges();

                return Json(new ReturnModel() { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false,Message="hatalı işlem" });
            }
        }
        public IActionResult PersonelSil(int id)
        {
            try
            {
                _context.Personels.Remove(_context.Personels.SingleOrDefault(e => e.Id == id));
                _context.SaveChanges();

                return Json(new ReturnModel() { Success = true,Message = "Silme İşlemi Başarıyla Gerçekleşti" });
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

            var yazarlar = query.FirstOrDefault(x=>x.Id==id);
            return PartialView("_PersonelDetayCardPartial", yazarlar);
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
            if (id>0)
            {
                ViewBag.Ilce = new SelectList(_context.Districts.Where(x => x.CityID == id).ToList(), "DistrictId", "DistrictName");
                return PartialView("_PersonelIlcePartial", ViewBag.Ilce);
            }
            return PartialView("_PersonelIlcePartial");
        }
    }
}
