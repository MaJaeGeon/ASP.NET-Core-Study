using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWeb.HomeWeb.Models;
using MyWeb_bluepope.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult TicketList()
        {
            var status = "In Progress";
            return View(TicketModel.GetList(status));
        }

        public IActionResult TicketUpdate([FromForm] TicketModel model)
        {
            model.Update();

            return RedirectToAction("TicketList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
