using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.DAL.Entities
{
    public class DeptDbContext:DbContext
    {
        public DeptDbContext(DbContextOptions<DeptDbContext> option):base(option)
        {

        }
       public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=MyDemoDB;Trusted_Connection=True");

        //}

    }
   
}
