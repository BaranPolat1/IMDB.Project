using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.BLL.Services.Abstract;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IAppUserService _userService;
        public UserController(IAppUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(model);
                return RedirectToAction("GetList");
            }
            return View();
        }
        public IActionResult List()
        {
            return View(_userService.GetList());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            AppUser user = await _userManager.FindByIdAsync(Id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(model);
                return View();
            }
            return View(model);
        }
        public IActionResult Delete(string Id)
        {
            _userService.Delete(Id);
            return RedirectToAction("GetList");
        }
    }
}