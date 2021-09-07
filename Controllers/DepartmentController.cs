using Microsoft.AspNetCore.Mvc;
using MyDemo.BL.Intrfaces;
using MyDemo.BL.Repository;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.Controllers
{
    public class DepartmentController : Controller
    {
         //loosly couple
        private readonly IDepartmentRepository depart;

        public DepartmentController(IDepartmentRepository _depart)
        {
            depart = _depart;
        }
        public IActionResult Index()
        {
            return View(depart.Get());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewModel Dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    depart.Add(Dpt);
                    return RedirectToAction("Index", "Department");
                }
                return View(Dpt);

            }
            catch (Exception ex)
            {

                EventLog log = new EventLog();
                log.Source= "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(Dpt);
            }
          
        }

        public IActionResult Edit(int id)
        {
            var data = depart.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentViewModel dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    depart.Edit(dept);
                    return RedirectToAction("Index", "Department");
                }
                return View(dept);

            }
            catch (Exception ex)
            {

                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(dept);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = depart.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                    depart.Delete(id);
                    return RedirectToAction("Index", "Department");
            }
            catch (Exception ex)
            {

                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View();
            }
        }
    }
}
