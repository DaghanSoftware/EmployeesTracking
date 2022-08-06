﻿using Libraries.EmployeesTracking.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Services
{
    public interface IDistrictService : IGenericService<District>
    {
        List<District> IlceleriListele(int? id);
    }
}
