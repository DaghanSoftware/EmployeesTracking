using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Entities
{
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int CityID { get; set; }
    }
}
