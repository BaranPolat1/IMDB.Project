using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace IMDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private IMovieService movieService;
        public HomeController(IMovieService _movieService)
        {
            movieService = _movieService;
        }
        public IActionResult Index(int sayfa = 1)
        {
            var model = movieService.GetList().ToPagedList(sayfa, 9);
           return View(model);
        }
    }
}