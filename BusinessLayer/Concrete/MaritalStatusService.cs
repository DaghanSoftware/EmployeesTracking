using EmployeesTracking.Core;
using Libraries.EmployeesTracking.Core.Models.Entities;
using Libraries.EmployeesTracking.Core.Repositories;
using Libraries.EmployeesTracking.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Services.Concrete
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MaritalStatusService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
