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
    public class MaritalStatusManager : IMaritalStatusService
    {
        IMaritalStatusDal _maritalstatusdal;
        public MaritalStatusManager(IMaritalStatusDal maritalstatusdal)
        {
            _maritalstatusdal = maritalstatusdal;
        }

        public MaritalStatu GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MaritalStatu> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(MaritalStatu t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MaritalStatu t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MaritalStatu t)
        {
            throw new NotImplementedException();
        }
    }
}
