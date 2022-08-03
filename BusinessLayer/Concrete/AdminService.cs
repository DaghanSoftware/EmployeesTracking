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
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Admin> CreateAdmin(Admin newAdmin)
        {
            await _unitOfWork._Admins.AddAsync(newAdmin);
            await _unitOfWork.CommitAsync();
            return newAdmin;
        }

        public async Task DeleteAdmin(Admin Admin)
        {
            _unitOfWork._Admins.Remove(Admin);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Admin> GetAdminsById(int id)
        {
            return await _unitOfWork._Admins.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _unitOfWork._Admins.GetAllAsync();
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Admin t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Admin t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin t)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAdmin(Admin AdminToBeUpdated, Admin Admin)
        {
            AdminToBeUpdated.Name = Admin.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
