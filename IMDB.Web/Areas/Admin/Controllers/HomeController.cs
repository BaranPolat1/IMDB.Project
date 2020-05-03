using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
          var result =  movieService.GetList().OrderByDescending(x => x.AddedDate).Take(5);
           
           return View(result);
        }
    }
}