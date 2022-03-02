using EmployeesTracking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Models
{
    public interface IEmployeeDal
    {
        List<Personel> GetAll();
        void Add(Personel personel);
        void Update(Personel personel);
        void Delete(Personel personel);
    }
}
