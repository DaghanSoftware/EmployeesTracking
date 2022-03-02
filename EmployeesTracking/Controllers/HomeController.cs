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
            Personel personel = new Personel() {Id=1,Adi="Semih",Soyadi="Dağhan",AnaAdi="Rukiye",BabaAdi="Halil",Cinsiyet="Erkek",DogumYeri="Eskişehir",MedeniHali="Bekar"};
            //EmployeeDal employeeDal = new EmployeeDal();
            //employeeDal.Add(personel);
            _context.Personels.Add(personel);
            _context.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult Ekleme()
        {
            return View();
        }
    }
}
