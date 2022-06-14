using EmployeesTracking.Entities;
using EmployeesTracking.Models;
using EmployeesTracking.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult PersonelListesiPartial(string q, int gendernumber, int maritalnumber, int sehir, int page = 1)
        {
            var query = (from p in _context.Personels
                         from s in _context.Genders.Where(x => x.GenderId == p.GenderId).DefaultIfEmpty()
                         from c in _context.Cities.Where(x => x.CityId == p.CityId).DefaultIfEmpty()
                         from m in _context.MaritalStatus.Where(x => x.MaritalStatusId == p.MaritalStatusId).DefaultIfEmpty()
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
                             CityName = c.CityName
                         });

            if (gendernumber > 0)
                query = query.Where(x => x.GenderId == gendernumber);
            if (maritalnumber > 0)
                query = query.Where(x => x.MaritalStatusId == maritalnumber);
            if (sehir > 0)
                query = query.Where(x => x.CityId == sehir);
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(i => i.Adi.ToLower().Contains(q.ToLower()) || i.Soyadi.ToLower().Contains(q.ToLower()));
            }
            var yazarlar = query.ToList();
            return View(yazarlar);
        }
        public IActionResult PersonelPartial(int? id)
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            Personel model;
            if (id > 0)
            {
                model = _context.Personels.FirstOrDefault(m => m.Id == id);
            }
            else
            {
                model = new Personel();
            }
            return PartialView("_PersonelPartial", model);
        }

        [HttpPost]
        public IActionResult PersonelKaydet(Personel personelGelen, string hatalar)
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
                }
                else
                {
                    _context.Personels.Add(personelGelen);

                }
                _context.SaveChanges();

                return Json(new ReturnModel() { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false, Message = ex.Message });
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
    }
}
