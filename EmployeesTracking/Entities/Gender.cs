using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Entities
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public List<Personel> Personels { get; set; }
    }
}
