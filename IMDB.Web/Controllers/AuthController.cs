using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.BLL.Services.Abstract;
using IMDB.BLL.Services.Concrete;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace IMDB.Web.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                Redirect("/Admin/Home");
            }
            else if (User.Identity.IsAuthenticated)
            {
                Redirect("/Member/Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {

                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect("/Admin/Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please check your information");
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.InjectFrom(model);
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(" ", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}