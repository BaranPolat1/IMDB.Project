using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.BLL.Services.Abstract;
using IMDB.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IAppUserService userService;
        public UserController(IAppUserService _userService)
        {
            userService = _userService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserDTO model)
        {
            userService.Add(model);
            return View();
        }
    }
}