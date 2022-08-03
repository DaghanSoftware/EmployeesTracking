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
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
