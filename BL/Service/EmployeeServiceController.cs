using Microsoft.AspNetCore.Mvc;
using MyDemo.BL.Intrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Service
{
    public class EmployeeServiceController : Controller
    {
        private readonly ICityRepository city;
        private readonly IDistrictRepository district;
        public EmployeeServiceController(ICityRepository _city, IDistrictRepository _district)
        {
            city = _city;
            district = _district;
        }
        [HttpPost]
        [Route("/EmployeeService/GetCityDataByCountryId")]
        public JsonResult GetCityDataByCountryId(int CountryId)
        {
            var CityData = city.Get().Where(c => c.CountryId == CountryId);
            return Json(CityData);
        }

        [HttpPost]
        [Route("/EmployeeService/GetDistrictDataByCityId")]
        public JsonResult GetDistrictDataByCityId(int CityId)
        {
            var DistrictData = district.Get().Where(d => d.CityId == CityId);
            return Json(DistrictData);
        }
    }
}
