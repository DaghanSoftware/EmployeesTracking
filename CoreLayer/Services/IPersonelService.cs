using Libraries.EmployeesTracking.Core.Models.ViewModel;
using Libraries.EmployeesTracking.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Services
{
    public interface IPersonelService : IGenericService<Personel>
    {
        //List<PersonelViewModel> PersonelleriListele(string q, int gendernumber, int maritalnumber, int sehir, DateTime baslangictarih, DateTime bitistarih, int Districtid, int page = 1);
    }
}
