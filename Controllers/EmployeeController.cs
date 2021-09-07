using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDemo.BL.Intrfaces;
using MyDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.Controllers
{
    public class EmployeeController : Controller
    {
        //loosly couple
        private readonly IEmployeeRepository employ;
        private readonly IDepartmentRepository depart;
        private readonly ICountryRepository country;
        private readonly ICityRepository city;
        private readonly IDistrictRepository district;

        //private readonly ICityRepository city;
        //private readonly IDistrictRepository district;

        public EmployeeController(IEmployeeRepository _employ,
                                  IDepartmentRepository _depart,
                                  ICountryRepository _Country,
                                  ICityRepository _city,
                                  IDistrictRepository _district)
        {
            employ = _employ;
            depart = _depart;
            country = _Country;
            city = _city;
            district = _district;
        }
        public IActionResult Index()
        {
            //var data = employ.Get();
            return View(employ.Get());
        }

        public IActionResult Create()
        {
            var data = depart.Get();
            var CountryData = country.Get();
            ViewBag.CountryList = new SelectList(CountryData, "Id", "CountryName");
            ViewBag.DepartsList = new SelectList(data,"Id","DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employ.Add(emp);
                    return RedirectToAction("Index","Employee");
                }
                var data = depart.Get();
                var CountryData = country.Get();
                ViewBag.CountryList = new SelectList(CountryData, "Id", "CountryName");
                ViewBag.DepartsList = new SelectList(data, "Id", "DepartmentName");
                return View(emp);

            }
            catch (Exception ex)
            {

                //EventLog log = new EventLog();
                //log.Source = "Admin Dashboard";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(emp);
            }

        }
        public IActionResult Details(int id)
        {
            var data = employ.GetById(id);
            var DepartsList = depart.Get();
            ViewBag.DepartmentList = new SelectList(DepartsList, "Id", "DepartmentName", data.DepartmentId);
            //selected district
            var DistrictList = district.Get();
            ViewBag.DistrictList = new SelectList(DistrictList, "Id", "DistrictName", data.DistrictId);
            return View(data);
        }
        public IActionResult Edit(int id)
        {
            var data = employ.GetById(id);
            //selected department
            var DepartsList = depart.Get();
            ViewBag.DepartmentList = new SelectList(DepartsList, "Id", "DepartmentName",data.DepartmentId);
            //list of countries
            var CountryData = country.Get();
            ViewBag.CountryList = new SelectList(CountryData, "Id", "CountryName");
            //selected district
            var DistrictList = district.Get();
            ViewBag.DistrictList = new SelectList(DistrictList,"Id", "DistrictName", data.DistrictId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employ.Edit(emp);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {

                    var DepartsList = depart.Get();
                    ViewBag.DepartmentList = new SelectList(DepartsList, "Id", "DepartmentName", emp.DepartmentId);
                    //list of countries
                    var CountryData = country.Get();
                    ViewBag.CountryList = new SelectList(CountryData, "Id", "CountryName");
                    //selected district
                    var DistrictList = district.Get();
                    ViewBag.DistrictList = new SelectList(DistrictList, "Id", "DistrictName", emp.DistrictId);
                    return View(emp);
                }
            }
            catch (Exception ex)
            {

                //EventLog log = new EventLog();
                //log.Source = "Admin Dashboard";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);
                var DepartsList = depart.Get();
                ViewBag.DepartmentList = new SelectList(DepartsList, "Id", "DepartmentName", emp.DepartmentId);

                return View(emp);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = employ.GetById(id);
            var DepartsList = depart.Get();
            ViewBag.DepartmentList = new SelectList(DepartsList, "Id", "DepartmentName", data.DepartmentId);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                employ.Delete(id);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {

                //EventLog log = new EventLog();
                //log.Source = "Admin Dashboard";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);
                var data = employ.GetById(id);
                var DepartsList = depart.Get();
                ViewBag.DepartmentList = new SelectList(DepartsList, "Id", "DepartmentName", data.DepartmentId);
                return View(data);
            }
        }
    }
}
