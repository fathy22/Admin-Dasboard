using MyDemo.BL.Intrfaces;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DeptDbContext db;

        public CityRepository(DeptDbContext _db)
        {
            db = _db;
        }
        public IQueryable<CityViewModel> Get()
        {
            IQueryable<CityViewModel> data = GetAllCity();
            return data;
        }

        public CityViewModel GetById(int id)
        {
            CityViewModel data = GetCityById(id);
            return data;
        }

        public IQueryable<CityViewModel> GetAllCity()
        {
            return db.City.Select(c => new CityViewModel {Id=c.Id,CityName=c.CityName,CountryId=c.CountryId });
        }
        public CityViewModel GetCityById(int id)
        {
            return db.City.Where(c=>c.Id==id)
                            .Select(c => new CityViewModel { Id = c.Id, CityName = c.CityName, CountryId = c.CountryId })
                            .FirstOrDefault();
        }
    }
}
