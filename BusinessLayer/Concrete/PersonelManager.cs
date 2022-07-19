using BusinessLayer.Abstract;
using CoreLayer.Models;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;
        public PersonelManager(IPersonelDal personeldal)
        {
            _personelDal = personeldal;
        }

        public Personel GetById(int id)
        {
            return _personelDal.GetById(id);
        }

        public List<Personel> GetList()
        {
            throw new NotImplementedException();
        }

        public List<PersonelViewModel> PersonelleriListele(string q, int gendernumber, int maritalnumber, int sehir, DateTime baslangictarih, DateTime bitistarih, int Districtid, int page = 1)
        {
            return _personelDal.GetListAllPersonelOrFilterPersonel(q,gendernumber,maritalnumber,sehir,baslangictarih,bitistarih,Districtid,page);
        }

        public void TAdd(Personel t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Personel t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Personel t)
        {
            throw new NotImplementedException();
        }
    }
}
