using EmployeesTracking.Core;
using Libraries.EmployeesTracking.Core.Repositories;
using Libraries.EmployeesTracking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTracking.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        
        public IAdminRepository _Admins => throw new NotImplementedException();

        public ICityRepository _Cities => throw new NotImplementedException();

        public IDistrictRepository _Districts => throw new NotImplementedException();

        public IGenderRepository _Genders => throw new NotImplementedException();

        public IMaritalStatusRepository _MaritalStatus => throw new NotImplementedException();

        public IPersonelRepository _Personels => throw new NotImplementedException();

        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
