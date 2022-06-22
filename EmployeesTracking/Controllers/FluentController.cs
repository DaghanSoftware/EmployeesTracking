using EmployeesTracking.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Controllers
{
    public class FluentController : Controller
    {
        public IActionResult FluentDeneme()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FluentDeneme(Admin model)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return View(model);
            }
            return View();
        }
    }
}
