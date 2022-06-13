using EmployeesTracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EmployeesTracking.Controllers
{
    public class DenemeController : Controller
    {
        private readonly EmployeesContext _context;

        public DenemeController(EmployeesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "CityId", "CityName");
            return View();
        }

        public IActionResult AjaxilePopupAcma()
        {
            return View();
        }
        public IActionResult AjaxileVeriGetirme()
        {
            var yazarlar = _context.Personels.ToList();
            var jsonWriters = JsonConvert.SerializeObject(yazarlar);
            return Json(jsonWriters);

            //var jsonWriters = JsonConvert.SerializeObject(employee);
            //return Json(jsonWriters);
        }
        public IActionResult AjaxileFiltrelenVeriGetirme(string q, int gendernumber, int maritalnumber, int sehir, int page = 1)
        {
            

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
            var yazarlar = query.ToList();
            var jsonWriters = JsonConvert.SerializeObject(yazarlar);
            return Json(jsonWriters);

        }

        public static List<EmployeeList> employee = new List<EmployeeList>
        {
            new EmployeeList
            {
                Id=1,
                Name="Ayşe"
            },
            new EmployeeList
            {
                Id=2,
                Name="Mehmet"
            },
            new EmployeeList
            {
                Id=3,
                Name="Murat"
            },
        };

        
    }
}
