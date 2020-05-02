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
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
       [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryDTO model)
        {
            categoryService.Add(model);
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(categoryService.GetById(Id));
        }
        [HttpPost]
        public IActionResult Edit(CategoryDTO model)
        {
            categoryService.Update(model);
            return RedirectToAction("GetList");
        }
        public IActionResult Delete(int Id)
        {
            categoryService.Delete(Id);
            return RedirectToAction("GetList");
        }
        public IActionResult GetList()
        {
            return View(categoryService.GetList());
        }


    }
}