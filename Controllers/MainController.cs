using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        const string SessionKeyDate = "_Date";
        public IActionResult Index()
        {
            
            ViewBag.MyStatus = TempData["status"];
            if (HttpContext.Session != null)
            {
                ViewBag.Name = HttpContext.Session.GetString(SessionName);
                ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);
                ViewBag.Date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
            }
            return View();
        }
    }
}