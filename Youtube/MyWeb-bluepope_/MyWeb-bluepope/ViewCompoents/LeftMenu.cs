using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb_bluepope.ViewCompoents
{
    public class LeftMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
