using Microsoft.AspNetCore.Mvc;
using NetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // 위조방지토큰을 통해 View로부터 받은 Post data가 유효한지 검증
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;

            if (ModelState.IsValid)
            {
                string userId = "test1234";
                string userPassword = "test1234";

                if (login.UserId.Equals(userId) && login.Password.Equals(userPassword))
                {
                    TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";
                    return RedirectToAction("Index", "Membership");
                }
                else
                    message = "로그인되지 않았습니다.";
            }
            else
            {
                message = "로그인 정보를 올바르게 입력하세요.";
            }

            ModelState.AddModelError(string.Empty, message);
            
            return View();
        }
    }
}
