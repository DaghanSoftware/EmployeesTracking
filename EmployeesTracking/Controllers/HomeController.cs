using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesTracking.Models;
using EmployeesTracking.Entities;

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

            
            ViewData["personeller"] = employeeDal.GetAll().ToList();
            //ViewBag.semih= employeeDal.GetAll().ToList();
            //return View(employeeDal.GetAll().ToList());
            return View();

        }

        public IActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel personel)
        {
            EmployeeDal employeeDal = new EmployeeDal(_context);
            employeeDal.Add(personel);
            //_context.Personels.Add(personel);
            //_context.SaveChanges();
            return View();
        }

        public IActionResult PersonelListele()
        {
            EmployeeDal employeeDal = new EmployeeDal(_context);
            return View(employeeDal.GetAll().ToList());

        }

        public IActionResult PersoneSil(Personel personel)
        {
            EmployeeDal employeeDal = new EmployeeDal(_context);
            employeeDal.Delete(personel);
            return View("Index");
        }

        public IActionResult PersonelGuncelle(int id)
        {
            return View(_context.Personels.FirstOrDefault(m=>m.Id==id));
        }
        [HttpPost]
        public IActionResult PersonelGuncelle(Personel personel)
        {
            EmployeeDal employeeDal = new EmployeeDal(_context);
            employeeDal.Update(personel);
            return View("Index");
        }
    }
}
