using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Models.Entities
{
    public class MaritalStatu
    {
        [Key]
        public int MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; }
    }
}
