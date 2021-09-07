using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Intrfaces
{
    public interface ICityRepository
    {
        public IQueryable<CityViewModel> Get();
        CityViewModel GetById(int id);
    }
}
