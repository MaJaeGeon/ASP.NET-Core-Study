using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager { get; set; }
        private SignInManager<ApplicationUser> SignInManager { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    FullName = model.FullName, 
                    Email = model.Email,
                    UserName = model.Email,
                    Gender = model.Gender
                };
                var result = await UserManager.CreateAsync(user, model.Password);

                if(result.Succeeded) return RedirectToAction("Login");

                ModelState.AddModelError("", "회원가입 실패");
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                
                if(result.Succeeded) 
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "로그인 실패");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
