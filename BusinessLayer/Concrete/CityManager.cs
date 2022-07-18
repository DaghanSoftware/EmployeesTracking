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
    public class CityManager : ICityService
    {
        ICityDal _citydal;
        public CityManager(ICityDal citydal)
        {
            _citydal = citydal;
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<City> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(City t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(City t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(City t)
        {
            throw new NotImplementedException();
        }
    }
}
