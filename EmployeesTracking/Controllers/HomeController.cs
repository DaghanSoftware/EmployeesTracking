using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesTracking.Models;
using EmployeesTracking.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesTracking.Controllers
{
    public class HomeController : Controller
    {

        private readonly EmployeesContext _context;
        public HomeController(EmployeesContext context)
        {
            _context = context;
        }
     
        public IActionResult Index(string q)
        {
            //Personel personel = new Personel() {Id=1,Adi="Semih",Soyadi="Dağhan",AnaAdi="Rukiye",BabaAdi="Halil",Cinsiyet="Erkek",DogumYeri="Eskişehir",MedeniHali="Bekar"};
            //EmployeeDal employeeDal = new EmployeeDal();
            //employeeDal.Add(personel);
            //_context.Personels.Add(personel);
            //_context.SaveChanges();
            //var personel = _context.Personels;

            var personelarama = q;

            var personels = _context.Personels.AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                personels = personels.Where(i => i.Adi.ToLower().Contains(q.ToLower()) || i.Soyadi.ToLower().Contains(q.ToLower()));
            }
            var sonuc = _context.Personels.FromSqlRaw("Select * From Personels").ToList();
            var model = new PersonelViewModel()
            {
                Personels = personels.ToList()
            };
            //if (_context.Personels!=null)
            //{
            //    ViewData["personeller"] = _context.Personels.ToList();
            //}

            //ViewBag.semih= employeeDal.GetAll().ToList();
            //return View(employeeDal.GetAll().ToList());

            
            return View(model);

        }



        public IActionResult PersonelEkle(int? id)
        {
            //ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");

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
                }
                else
                {
                    _context.Personels.Add(personelGelen);
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
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
