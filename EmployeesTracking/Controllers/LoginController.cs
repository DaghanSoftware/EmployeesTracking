using EmployeesTracking.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Controllers
{
    public class LoginController : Controller
    {
        private readonly EmployeesContext _context;
        public LoginController(EmployeesContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GirisYap(Admin p)
        
        {
            var user = _context.Admins.FirstOrDefault(x=>x.Email.Equals(p.Email) && x.Password.Equals(p.Password));
            if (user!=null)
            {
                HttpContext.Session.SetInt32("id", user.Id);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("fullname", user.Name+""+user.Surname);
                return RedirectToAction("Index","Home");
            }
            return View();
        }


        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(Admin p)
        {
            _context.Admins.Add(p);
            _context.SaveChanges();
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }
    }
}
