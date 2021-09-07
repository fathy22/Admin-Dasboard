using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Intrfaces
{
    public interface IDistrictRepository
    {
        public IQueryable<DistrictViewModel> Get();
        DistrictViewModel GetById(int id);
    }
}
