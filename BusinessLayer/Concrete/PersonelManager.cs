using BusinessLayer.Abstract;
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
            throw new NotImplementedException();
        }

        public List<Personel> GetList()
        {
            throw new NotImplementedException();
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
