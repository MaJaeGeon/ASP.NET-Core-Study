using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCheck()
        {
            if(User.IsInRole("ADMIN")) return Json(new { a = 9 });

            return Json(new { a = 1 });
        }

        [AllowAnonymous]
        public IActionResult GetUserCheck()
        {
            if (User.Identity.IsAuthenticated) return Json(new { a = 9 });

            return Json(new { a = 1 });
        }
    }
}
