using Microsoft.AspNetCore.Mvc;
using MyDemo.BL.Repository;
using MyDemo.DAL.Entities;
using MyDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository user;

        public AccountController(UserRepository _user)
        {
            user = _user;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Add(usr);
                    return RedirectToAction("Index", "Department");
                }
                return View(usr);

            }
            catch (Exception ex)
            {

                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(usr);
            }

        }

        public IActionResult Login()
        {
            return View();
        }

        //login
        //[HttpPost]
        //public IActionResult Login(LoginViewModel login)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            user.LoginFunction(login.UserName, login.Password);
        //            return RedirectToAction("Index", "Department");
        //        }
        //        return View(login);

        //    }
        //    catch (Exception ex)
        //    {

        //        EventLog log = new EventLog();
        //        log.Source = "Admin Dashboard";
        //        log.WriteEntry(ex.Message, EventLogEntryType.Error);
        //        return View(login);
        //    }
        //}


    }
}
