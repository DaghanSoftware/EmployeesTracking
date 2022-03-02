using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTracking.Entities
{
    public class Personel
    {
        public Int32 Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string BabaAdi { get; set; }
        public string AnaAdi { get; set; }
        public string Cinsiyet { get; set; }
        public string MedeniHali { get; set; }
        public string DogumYeri { get; set; }
    }
}
