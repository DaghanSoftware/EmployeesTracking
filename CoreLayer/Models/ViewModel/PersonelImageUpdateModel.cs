using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Models.ViewModel
{
    public class PersonelImageUpdateModel
    {

        public int Id { get; set; }
        public IFormFile Resim { get; set; }
    }
}
