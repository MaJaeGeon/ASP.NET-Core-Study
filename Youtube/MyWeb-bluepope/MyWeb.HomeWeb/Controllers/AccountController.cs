using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWeb.HomeWeb.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MyWeb.HomeWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        #region Login
        public IActionResult Login(string msg)
        {
            ViewData["msg"] = msg;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]UserModel input)
        {
            try
            {
                input.ConvertPassword();
                var user = input.GetLoginUser();

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.User_seq.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.User_name));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim("LastCheckDateTime", DateTime.UtcNow.ToString("yyyyMMddHHmmss")));

                if (user.User_name == "akworjs0517")
                    identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddHours(4),
                    AllowRefresh = true
                });

                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/account/login?msg={HttpUtility.UrlEncode(ex.Message)}");
            }

        }

        #endregion

        #region Register

        public IActionResult Register(string msg)
        {
            ViewData["msg"] = msg;

            return View();
        }

        [HttpPost]
        [Route("/account/register")]
        public IActionResult Register([FromForm] UserModel input)
        {
            try
            {
                string password2 = Request.Form["password2"];

                if (input.Password != password2) throw new Exception("비밀번호 불일치");

                input.ConvertPassword();

                input.Register();

                return RedirectToAction("login");
            }
            catch (Exception ex)
            {
                return Redirect($"/account/register?msg={HttpUtility.UrlEncode(ex.Message)}");
            }
        }

        #endregion

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}
