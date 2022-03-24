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
        [Required(ErrorMessage = "Cinsiyet alanını doldurmanız gerekmektedir")]
        public string Cinsiyet { get; set; }
        [Required(ErrorMessage = "MedeniHali alanını doldurmanız gerekmektedir")]
        public string MedeniHali { get; set; }
        [Required(ErrorMessage = "DogumYeri alanını doldurmanız gerekmektedir")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "TcNo alanını doldurmanız gerekmektedir")]
        public Int64 TcNo { get; set; }
    }
}
