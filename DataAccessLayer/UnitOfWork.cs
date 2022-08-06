using EmployeesTracking.Core;
using Libraries.EmployeesTracking.Core.Repositories;
using Libraries.EmployeesTracking.Data;
using Libraries.EmployeesTracking.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTracking.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;
        
        private AdminRepository _AdminsRepository;
        private CityRepository _CitiesRepository;
        private DistrictRepository _DistrictsRepository;
        private GenderRepository _GendersRepository;
        private MaritalStatusRepository _MaritalStatusRepository;
        private PersonelRepository _PersonelsRepository;

        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public IAdminRepository _Admins => _AdminsRepository = _AdminsRepository ??= new AdminRepository(_context);

        public ICityRepository _Cities => _CitiesRepository = _CitiesRepository ??= new CityRepository(_context);

        public IDistrictRepository _Districts => _DistrictsRepository = _DistrictsRepository ??= new DistrictRepository(_context);

        public IGenderRepository _Genders => _GendersRepository = _GendersRepository ??= new GenderRepository(_context);

        public IMaritalStatusRepository _MaritalStatus => _MaritalStatusRepository = _MaritalStatusRepository ??= new MaritalStatusRepository(_context);

        public IPersonelRepository _Personels => _PersonelsRepository = _PersonelsRepository ??= new PersonelRepository(_context);




        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
