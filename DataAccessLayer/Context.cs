using Libraries.EmployeesTracking.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Data
{
    public class Context:DbContext
    {
        //public Context(DbContextOptions<Context> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Employees; integrated security=true;");


        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=Employees;Trusted_Connection=true");
        //}
        public DbSet<Personel> Personels { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MaritalStatu> MaritalStatus { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
