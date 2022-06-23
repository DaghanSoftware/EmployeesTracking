using EmployeesTracking.Entities;
using EmployeesTracking.Models;
using EmployeesTracking.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Controllers
{
    public class FluentController : Controller
    {
        private readonly EmployeesContext _context;
        public FluentController(EmployeesContext context)
        {
            _context = context;
        }
        public IActionResult FluentDeneme()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FluentDeneme(Admin p)
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
                    _context.Admins.Add(p);
                }
                _context.SaveChanges();
                return Json(new ReturnModel() { Success = true, Message = "Kayıt Olma İşlemi Başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new ReturnModel() { Success = false, Message = "hatalı işlem" });
            }

        }
    }
}
