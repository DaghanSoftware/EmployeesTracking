using Libraries.EmployeesTracking.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTracking.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository _Admins { get; }
        ICityRepository _Cities { get; }
        IDistrictRepository _Districts { get; }
        IGenderRepository _Genders { get; }
        IMaritalStatusRepository _MaritalStatus { get; }
        IPersonelRepository _Personels { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
