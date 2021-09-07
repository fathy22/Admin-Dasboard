using MyDemo.BL.Intrfaces;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DeptDbContext db;

        public CountryRepository(DeptDbContext _db)
        {
            db = _db;
        }
        public IQueryable<CountryViewModel> Get()
        {
            IQueryable<CountryViewModel> data = GetAllCountry();
            return data;
        }

        public CountryViewModel GetById(int id)
        {
            CountryViewModel data = GetCountryById(id);
            return data;
        }

        public IQueryable<CountryViewModel> GetAllCountry()
        {
            return db.Country.Select(c => new CountryViewModel { Id = c.Id, CountryName = c.CountryName});
        }
        public CountryViewModel GetCountryById(int id)
        {
            return db.Country.Where(c => c.Id == id)
                            .Select(c => new CountryViewModel { Id = c.Id, CountryName = c.CountryName })
                            .FirstOrDefault();
        }
    }
}
