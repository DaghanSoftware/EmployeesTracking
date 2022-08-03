using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Models.ViewModel
{
    public class PersonelDetayCardViewModel
    {

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
        public string Resim { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime KurumBaslamaTarihi { get; set; }
        public string Biyografi { get; set; }
        public Int64 PhoneNumber { get; set; }
        public int Puan { get; set; }
        public string Mail { get; set; }
        public string Hakkinda { get; set; }
        public string Position { get; set; }
        public string Adres { get; set; }
    }
}
