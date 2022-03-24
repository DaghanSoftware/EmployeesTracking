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
     
        public IActionResult Index()
        {
            //Personel personel = new Personel() {Id=1,Adi="Semih",Soyadi="Dağhan",AnaAdi="Rukiye",BabaAdi="Halil",Cinsiyet="Erkek",DogumYeri="Eskişehir",MedeniHali="Bekar"};
            //EmployeeDal employeeDal = new EmployeeDal();
            //employeeDal.Add(personel);
            Personel personel = new Personel();
            //_context.Personels.Add(personel);
            //_context.SaveChanges();
            //var personel = _context.Personels;

            EmployeeDal employeeDal = new EmployeeDal(_context);

            if (_context.Personels!=null)
            {
                ViewData["personeller"] = _context.Personels.ToList();
            }
            
            //ViewBag.semih= employeeDal.GetAll().ToList();
            //return View(employeeDal.GetAll().ToList());
            return View();

        }



        public IActionResult PersonelEkle(int? id)
        {
            if (id==null)
            {
                ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                return View();
            }
            else
            {
                ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                ViewBag.guncelle = id;
                return View(_context.Personels.FirstOrDefault(m => m.Id == id));
            }

        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel personel,int? id)
        {
            if (id==null)
            {
                if (ModelState.IsValid)
                {
                    _context.Personels.Add(personel);
                    _context.SaveChanges();
                    ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                    return View();
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                    var EmployeeToUpdate = _context.Personels.SingleOrDefault(p => p.Id == personel.Id);
                    EmployeeToUpdate.Adi = personel.Adi;
                    EmployeeToUpdate.Soyadi = personel.Soyadi;
                    EmployeeToUpdate.BabaAdi = personel.BabaAdi;
                    EmployeeToUpdate.TcNo = personel.TcNo;
                    EmployeeToUpdate.AnaAdi = personel.AnaAdi;
                    EmployeeToUpdate.Cinsiyet = personel.Cinsiyet;
                    EmployeeToUpdate.MedeniHali = personel.MedeniHali;
                    EmployeeToUpdate.CityId = personel.CityId;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
                    return View();
                } 
            }
            
            //_context.Personels.Add(personel);
            //_context.SaveChanges();
        }

        public IActionResult PersoneSil(int id)
        {
            _context.Personels.Remove(_context.Personels.SingleOrDefault(e => e.Id == id));
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
