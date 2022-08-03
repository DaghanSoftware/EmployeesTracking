using Libraries.EmployeesTracking.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Services
{
    public interface IAdminService : IGenericService<Admin>
    {

        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdminsById(int id);
        Task<Admin> CreateAdmin(Admin newAdmin);
        Task UpdateAdmin(Admin AdminToBeUpdated, Admin Admin);
        Task DeleteAdmin(Admin Admin);
    }
}
