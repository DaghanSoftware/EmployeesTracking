using Libraries.EmployeesTracking.Core.Models.Entities;
using Libraries.EmployeesTracking.Core.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Services
{
    public interface IPersonelService : IGenericService<Personel>
    {
        List<PersonelViewModel> PersonelleriListele(string q, int gendernumber, int maritalnumber, int sehir, DateTime baslangictarih, DateTime bitistarih, int Districtid, int page = 1);
        PersonelViewModel PersonelEkleGuncellePartial(int? id);
        void PersonelEkle(PersonelViewModel personelgelenveri);
        void PersonelGüncelle(PersonelViewModel personelgelenveriguncelle);
        void PersonelSil(int id);
        PersonelDetayCardViewModel PersonelDetayCardPartial(int id);
        PersonelDetayCardViewModel PersonelImageUploadCardModel(int id);
        Task PersonelImageUpload(PersonelImageUpdateModel personelgelenresimverisi);
    }
}
