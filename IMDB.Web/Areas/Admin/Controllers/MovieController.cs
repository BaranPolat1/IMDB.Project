using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IMDB.BLL.Services.Abstract;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using IMDB.Infrastructure.VM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private ICategoryService _categoryService;
        private IMovieService movieService;
        public MovieController(IMovieService _movieService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
             movieService = _movieService;
        }
        [HttpGet]
        public IActionResult Add(MovieCategoryVM model)
        {
            model.Categories = _categoryService.GetList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(MovieCategoryVM model,int categoryId, List<IFormFile> files,string name,string descreption)
        {
           movieService.Add(model.Movie, categoryId, files, name, descreption);
            return new JsonResult("");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(movieService.Update(Id));
        }
        [HttpPost]
        public IActionResult Edit(MovieDTO model)
        {   
            movieService.Update(model);
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View(movieService.GetList());
        }

    }
}