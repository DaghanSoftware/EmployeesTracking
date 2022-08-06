using ClosedXML.Excel;
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
using Libraries.EmployeesTracking.Core.Models.Entities;
using Libraries.EmployeesTracking.Core.Models.ViewModel;
using Libraries.EmployeesTracking.Data;
using Libraries.EmployeesTracking.Services.Filter;
using Libraries.EmployeesTracking.Services.ValidationRules;
using Libraries.EmployeesTracking.Core.Services;
using EmployeesTracking.Data;
using EmployeesTracking.Core;

namespace EmployeesTracking.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {

        private readonly IPersonelService _personelService;
        private readonly ICityService _cityServices;
        private readonly IDistrictService _districtServices;

        public HomeController(IPersonelService personelService,ICityService cityServices, IDistrictService districtServices)
        {
            _personelService = personelService;
            _cityServices = cityServices;
            _districtServices = districtServices;
        }
        public IActionResult Index()
        {
            ViewBag.Cities = new SelectList(_cityServices.GetList(), "CityId", "CityName");
            return View();
        }
        public IActionResult PersonelListele()
        {
            ViewBag.Cities = new SelectList(_cityServices.GetList(), "CityId", "CityName");
            return View();
        }

        public IActionResult PersonelListesiPartial(string q, int gendernumber, int maritalnumber, int sehir, DateTime baslangictarih, DateTime bitistarih, int Districtid, int page = 1)
        {
            var personeller = _personelService.PersonelleriListele(q,gendernumber,maritalnumber,sehir,baslangictarih,bitistarih,Districtid,page);
            return View(personeller);
        }
        public IActionResult PersonelEkleGuncellePartial(int? id)
        {
            ViewBag.Cities = new SelectList(_cityServices.GetList(), "CityId", "CityName");
            return PartialView("_PersonelEkleGuncellePartial", _personelService.PersonelEkleGuncellePartial(id));
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
                    
                    _personelService.PersonelGüncelle(personelGelen);
                    sonucMesaji = "Güncelleme işlemi başarıyla yapıldı";
                }
                else
                {
                    
                    _personelService.PersonelEkle(personelGelen);
                    sonucMesaji = "Ekleme işlemi başarıyla yapıldı";

                }

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
                _personelService.PersonelSil(id);
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
            return PartialView("_PersonelDetayCardPartial", _personelService.PersonelDetayCardPartial(id));
        }

        public IActionResult PersonelImageUploadCardModel(int id)
        {
            return PartialView("_PersonelImageUploadModalPartial", _personelService.PersonelImageUploadCardModel(id));
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
                    _personelService.PersonelImageUpload(personelGelen);
                    //var personel = _context.Personels.SingleOrDefault(p => p.Id == personelGelen.Id);

                    //var extension = Path.GetExtension(personelGelen.Resim.FileName);
                    //var newimagename = Guid.NewGuid() + extension;
                    //var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    //var stream = new FileStream(location, FileMode.Create);
                    //personelGelen.Resim.CopyTo(stream);
                    //personel.Resim = newimagename;
                    //_context.SaveChanges();

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
        public IActionResult PersonelIlcePartial(int? id)
        {
            if (id > 0)
            {

                return Json(new SelectList(_districtServices.IlceleriListele(id), "DistrictId", "DistrictName"));
            }
            return Json(new SelectList(_districtServices.IlceleriListele(id), "DistrictId", "DistrictName"));
        }
        //public IActionResult ExportDynamicExcelBlogList()
        //{
        //    using (var workbook = new XLWorkbook())
        //    {
        //        var worksheet = workbook.Worksheets.Add("Personel Listesi");
        //        worksheet.Cell(1, 1).Value = "ID";
        //        worksheet.Cell(1, 2).Value = "Adı";
        //        worksheet.Cell(1, 3).Value = "Soyadi";
        //        worksheet.Cell(1, 4).Value = "BabaAdi";
        //        worksheet.Cell(1, 5).Value = "AnaAdi";
        //        worksheet.Cell(1, 6).Value = "TcNo";

        //        int BlogRowCount = 2;
        //        foreach (var item in BlogTitlelist())
        //        {
        //            worksheet.Cell(BlogRowCount, 1).Value = item.Id;
        //            worksheet.Cell(BlogRowCount, 2).Value = item.Adi;
        //            worksheet.Cell(BlogRowCount, 3).Value = item.Soyadi;
        //            worksheet.Cell(BlogRowCount, 4).Value = item.BabaAdi;
        //            worksheet.Cell(BlogRowCount, 5).Value = item.AnaAdi;
        //            worksheet.Cell(BlogRowCount, 6).Value = item.TcNo;
        //            BlogRowCount++;
        //        }

        //        using (var stream = new MemoryStream())
        //        {
        //            workbook.SaveAs(stream);
        //            var content = stream.ToArray();
        //            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PersonelListesi.xlsx");
        //        }
        //    }
        //}

        //public List<PersonelDetayCardViewModel> BlogTitlelist()
        //{
        //    List<PersonelDetayCardViewModel> bm = new List<PersonelDetayCardViewModel>();
        //    bm = _context.Personels.Select(x => new PersonelDetayCardViewModel
        //    {
        //        Id = x.Id,
        //        Adi = x.Adi,
        //        Soyadi = x.Soyadi,
        //        BabaAdi = x.BabaAdi,
        //        AnaAdi = x.AnaAdi,
        //        TcNo = x.TcNo

        //    }).ToList();

        //    return bm;
        //}



        //public IActionResult Test(int? id)
        //{
        //    ViewBag.Cities = new SelectList(_cityServices.GetList(), "CityId", "CityName");

        //    PersonelViewModel model;
        //    Personel personel;
        //    if (id > 0)
        //    {
        //        personel = _context.Personels.FirstOrDefault(m => m.Id == id);
        //        // ViewBag.Ilceler = new SelectList(_context.Districts.Where(x => x.CityID == personel.CityId).ToList(), "DistrictId", "DistrictName");
        //        model = new PersonelViewModel
        //        {
        //            Id = personel.Id,
        //            Adi = personel.Adi,
        //            Soyadi = personel.Soyadi,
        //            TcNo = personel.TcNo,
        //            BabaAdi = personel.BabaAdi,
        //            AnaAdi = personel.AnaAdi,
        //            GenderId = personel.GenderId,
        //            MaritalStatusId = personel.MaritalStatusId,
        //            CityId = personel.CityId,
        //            DistrictId = personel.DistrictId,
        //            DogumTarihi = DateTime.Parse(personel.DogumTarihi.ToShortDateString())
        //        };
        //    }
        //    else
        //    {
        //        model = new PersonelViewModel
        //        {
        //            DogumTarihi = DateTime.Parse(DateTime.Now.ToShortDateString())
        //        };
        //    }
        //    return PartialView("Test", model);
        //}
    }
}
