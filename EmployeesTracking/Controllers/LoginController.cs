using CoreLayer.Models;
using EmployeesTracking.ValidationRules;
using EntityLayer.Concrete;
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
        private readonly Context _context;
        public LoginController(Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GirisYap(LoginModel p)
        {
            try
            {
                AdminLoginValidator validationRules = new AdminLoginValidator();
                ValidationResult result = validationRules.Validate(p);
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
                else
                {
                    var user = _context.Admins.FirstOrDefault(x => x.Email.Equals(p.Email) && x.Password.Equals(p.Password));
                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("id", user.Id);
                        HttpContext.Session.SetString("email", user.Email);
                        HttpContext.Session.SetString("username", user.UserName);
                        HttpContext.Session.SetString("fullname", user.Name + "" + user.Surname);
                        return Json(new ReturnModel() { Success = true, Message = "Giriş Yapma İşlemi Başarılı" });
                    }
                    else
                    {
                        return Json(new ReturnModel() { Success = false, Message = "Böyle bir kullanıcı yok" });
                    }
                }

            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false, Message = "hatalı işlem" });
            }
        }


        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(Admin p)
        {
            try
            {
                //AdminRegisterValidator validationRules = new AdminRegisterValidator();
                //ValidationResult result = validationRules.Validate(p);
                //var response = new ReturnModel();
                //List<string> ValidationMessages = new List<string>();

                //if (!result.IsValid)
                //{
                //    foreach (ValidationFailure failure in result.Errors)
                //    {
                //        ValidationMessages.Add(failure.ErrorMessage);
                //    }
                //    response.Message2 = ValidationMessages;
                //    return Json(new ReturnModel() { Success = false, Message2 = response.Message2 });
                //}
                //else
                //{
                    _context.Admins.Add(p);
                //}
                _context.SaveChanges();
                return Json(new ReturnModel() { Success = true, Message = "Kayıt Olma İşlemi Başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false, Message = "hatalı işlem" });
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }
    }
}
