using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Entities
{
    public class Personel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string BabaAdi { get; set; }
        public string AnaAdi { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int CityId { get; set; }
        public Int64 TcNo { get; set; }
        public int DistrictId { get; set; }
        public string Resim { get; set; }
        public DateTime DogumTarihi { get; set; }

    }
}
