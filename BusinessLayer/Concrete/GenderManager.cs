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
    public class GenderManager : IGenderService
    {
        IGenderDal _genderdal;
        public GenderManager(IGenderDal genderdal)
        {
            _genderdal = genderdal;
        }

        public Gender GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Gender> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Gender t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Gender t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Gender t)
        {
            throw new NotImplementedException();
        }
    }
}
