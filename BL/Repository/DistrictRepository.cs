using MyDemo.BL.Intrfaces;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Repository
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly DeptDbContext db;

        public DistrictRepository(DeptDbContext _db)
        {
            db = _db;
        }

        public IQueryable<DistrictViewModel> Get()
        {
            IQueryable<DistrictViewModel> data = GetAllDitrict();
            return data;
        }

        public DistrictViewModel GetById(int id)
        {
            DistrictViewModel data = GetDitrictById(id);
            return data;
        }


        public IQueryable<DistrictViewModel> GetAllDitrict()
        {
            return db.District.Select(d => new DistrictViewModel { Id = d.Id, DistrictName = d.DistrictName, CityId = d.CityId });
        }

        public DistrictViewModel GetDitrictById(int id)
        {
            return db.District.Where(d=>d.Id==id)
                              .Select(d => new DistrictViewModel { Id = d.Id, DistrictName = d.DistrictName, CityId = d.CityId })
                              .FirstOrDefault();
        }
    }
}
