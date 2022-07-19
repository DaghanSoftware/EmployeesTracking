using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class PersonelImageUpdateModel
    {

        public int Id { get; set; }
        public IFormFile Resim { get; set; }
    }
}
