using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Intrfaces
{
    public interface ICountryRepository
    {
        public IQueryable<CountryViewModel> Get();
        CountryViewModel GetById(int id);
    }
}
