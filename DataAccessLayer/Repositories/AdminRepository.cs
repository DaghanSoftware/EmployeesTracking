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
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(Context context) : base(context)
        {
        }
    }
}
