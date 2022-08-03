using Libraries.EmployeesTracking.Core.Models.Entities;
using Libraries.EmployeesTracking.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Data.Repositories
{
    public class MaritalStatusRepository : GenericRepository<MaritalStatu>, IMaritalStatusRepository
    {
        public MaritalStatusRepository(DbContext context) : base(context)
        {
        }
    }
}
