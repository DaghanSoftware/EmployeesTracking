using EmployeesTracking.Entities;
using EmployeesTracking.Models;
using EmployeesTracking.ValidationRules;
using FluentValidation.Results;
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
            return RedirectToAction("Index", "Login");
        }


        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(Admin p)
        {
            AdminLoginValidator validationRules = new AdminLoginValidator();
            ValidationResult result = validationRules.Validate(p);
            var response = new ReturnModel();
            List<string> ValidationMessages = new List<string>();
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                foreach (ValidationFailure failure in result.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.Message2 = ValidationMessages;
                return Json(new ReturnModel() { Success = false, Message2 = response.Message2 });

            }
            //if (!result.IsValid)
            //    return Json(new ReturnModel() { Success = false, Message = "Tüm Alanları Doldurunuz" });
            _context.Admins.Add(p);
            _context.SaveChanges();
            return View(p);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }
    }
}
