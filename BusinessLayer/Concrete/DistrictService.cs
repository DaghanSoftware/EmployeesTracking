﻿using EmployeesTracking.Core;
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
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DistrictService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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