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
    public class DistrictManager : IDistrictService
    {
        IDistrictDal _districtdal;
        public DistrictManager(IDistrictDal districtdal)
        {
            _districtdal = districtdal;
        }

        public District GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<District> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(District t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(District t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(District t)
        {
            throw new NotImplementedException();
        }
    }
}
