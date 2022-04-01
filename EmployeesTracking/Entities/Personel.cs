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

        [Required(ErrorMessage ="İsim alanını doldurmanız gerekmektedir")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyadi alanını doldurmanız gerekmektedir")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "BabaAdi alanını doldurmanız gerekmektedir")]
        public string BabaAdi { get; set; }

        [Required(ErrorMessage = "AnaAdi alanını doldurmanız gerekmektedir")]
        public string AnaAdi { get; set; }


        public int GenderId { get; set; }

        public int MaritalStatusId { get; set; }


        public int CityId { get; set; }

        [Required(ErrorMessage = "TcNo alanını doldurmanız gerekmektedir")]
        public Int64 TcNo { get; set; }
        public int DistrictId { get; set; }

        public List<City> Cities { get; set; }
        public List<Gender> Genders { get; set; }
    }
}
