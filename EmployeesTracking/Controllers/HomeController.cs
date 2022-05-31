using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesTracking.Models;
using EmployeesTracking.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using Newtonsoft.Json;

namespace EmployeesTracking.Controllers
{
    public class HomeController : Controller
    {

        private readonly EmployeesContext _context;
        public HomeController(EmployeesContext context)
        {
            _context = context;
        }
     
        public IActionResult Index(string q,int gendernumber,int maritalnumber,int sehir,int page=1)
        {
            #region Eski Kodlar
            //Personel personel = new Personel() {Id=1,Adi="Semih",Soyadi="Dağhan",AnaAdi="Rukiye",BabaAdi="Halil",Cinsiyet="Erkek",DogumYeri="Eskişehir",MedeniHali="Bekar"};
            //EmployeeDal employeeDal = new EmployeeDal();
            //employeeDal.Add(personel);
            //_context.Personels.Add(personel);
            //_context.SaveChanges();
            //var personel = _context.Personels;

            //var personels = _context.Personels.AsQueryable();


            //var sonuc = _context.Personels.FromSqlRaw("Select * From Personels").ToList();
            //var personels = _context.Personels.FromSqlRaw("Select p.Id,p.Adi,p.Soyadi,p.TcNo,p.BabaAdi,p.AnaAdi,p.GenderId,p.MaritalStatusId,p.CityId,p.DistrictId,g.GenderName from Personels p left join Genders g on g.GenderId=p.GenderId");

            //var model = new PersonelViewModel()
            //{
            //    Personels = personels.ToList()
            //};
            //if (_context.Personels!=null)
            //{
            //    ViewData["personeller"] = _context.Personels.ToList();
            //}

            //ViewBag.semih= employeeDal.GetAll().ToList();
            //return View(employeeDal.GetAll().ToList());
            #endregion

            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");

            var query = (from p in _context.Personels
                         join s in _context.Genders on p.GenderId equals s.GenderId
                         join c in _context.Cities on p.CityId equals c.CityId
                         join m in _context.MaritalStatus on p.MaritalStatusId equals m.MaritalStatusId
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

            return View(query.ToList().ToPagedList(page,3));

        }



        public IActionResult PersonelEkle(int? id)
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

            return View(model);
        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel personelGelen)
        {
            var sonucMesaji= "";
            if (ModelState.IsValid)
            {
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

                    sonucMesaji = JsonConvert.SerializeObject($"{personelGelen.Adi} {personelGelen.Soyadi} İsimli Personeli Güncelleme İşlemi Başarılı");
                }
                else
                {
                    _context.Personels.Add(personelGelen);

                    sonucMesaji = JsonConvert.SerializeObject($"{personelGelen.Adi} {personelGelen.Soyadi} İsimli Personeli Ekleme İşlemi Başarılı");
                }

                _context.SaveChanges();

                //return RedirectToAction("Index");
                
                return Ok(sonucMesaji);
            }
            else
            {
                ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                return View(personelGelen);
            }
        }

        public IActionResult PersoneSil(int id)
        {
            _context.Personels.Remove(_context.Personels.SingleOrDefault(e => e.Id == id));
            TempData["Message"] = $"{id} id li personel silindi";
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Ajaxpersonelekleme()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajaxpersonelekleme(Personel p)
        {
            _context.Personels.Add(p);
            _context.SaveChanges();
            var jsonWriters = JsonConvert.SerializeObject(p);
            return Json(jsonWriters);
        }

        //public IActionResult PersonelGuncelle(int id)
        //{
        //    return View(_context.Personels.FirstOrDefault(m=>m.Id==id));
        //}
        //[HttpPost]
        //public IActionResult PersonelGuncelle(Personel personel)
        //{
        //    EmployeeDal employeeDal = new EmployeeDal(_context);
        //    employeeDal.Update(personel);
        //    return RedirectToAction("Index");
        //}
    }
}
