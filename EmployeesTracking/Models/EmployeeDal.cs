using EmployeesTracking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Models
{
    public class EmployeeDal : IEmployeeDal
    {
        private readonly EmployeesContext _context;

        public EmployeeDal(EmployeesContext context)
        {
            _context = context;
        }
        public void Add(Personel personel)
        {
            using (_context)
            {
                _context.Personels.Add(personel);
                _context.SaveChanges();
            }
        }

        public void Delete(Personel personel)
        {
            using (_context)
            {
                _context.Personels.Remove(_context.Personels.SingleOrDefault(e => e.Id == personel.Id));
                _context.SaveChanges();
            }
        }

        //public List<Personel> GetAll()
        //{
        //    using (_context)
        //    {
        //        return _context.Personels.ToList();
        //    }
        //}


        public void Update(Personel personel)
        {
            using (_context)
            {
                var EmployeeToUpdate = _context.Personels.SingleOrDefault(p => p.Id == personel.Id);
                EmployeeToUpdate.Adi = personel.Adi;
                EmployeeToUpdate.Soyadi = personel.Soyadi;
                EmployeeToUpdate.BabaAdi = personel.BabaAdi;
                EmployeeToUpdate.AnaAdi = personel.AnaAdi;
                EmployeeToUpdate.Cinsiyet = personel.Cinsiyet;
                EmployeeToUpdate.MedeniHali = personel.MedeniHali;
                EmployeeToUpdate.CityId = personel.CityId;


                _context.SaveChanges();
            }
        }
    }
}
