using EmployeesTracking.Core;
using Libraries.EmployeesTracking.Core.Models.Entities;
using Libraries.EmployeesTracking.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Services.Concrete
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<City> GetList()
        {
            return _unitOfWork._Cities.Table.ToList();
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
