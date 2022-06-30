using EmployeesTracking.Entities;
using EmployeesTracking.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Models
{
    public class PersonelViewModel
    {
        //public List<Personel> Personels { get; set; }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string BabaAdi { get; set; }
        public string AnaAdi { get; set; }
        public int GenderId { get; set; }
        public Int64 TcNo { get; set; }
        public string GenderName { get; set; }
        public string MaritalStatusName { get; set; }
        public string CityName { get; set; }
        public int MaritalStatusId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Resim { get; set; }
        //public IFormFile Resim { get; set; }
    }
}
