using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IMDB.BLL.Services.Abstract;
using IMDB.Infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private IMovieService movieService;
        public MovieController(IMovieService _movieService)
        {
             movieService = _movieService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MovieDTO model, int categoryId,List<IFormFile> files,string name,string descreption)
        {
            movieService.Add(model, categoryId, files, name, descreption);
            return new JsonResult("");
        }
        [HttpPost]
        public IActionResult Edit(int Id)
        {
            return View(movieService.GetById(Id)); 
        }
    }
}