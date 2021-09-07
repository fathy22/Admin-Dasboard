using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.Areas.BillsInfo.Controllers
{
    public class BillManagmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
