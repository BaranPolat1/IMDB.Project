using AutoMapper;
using IMDB.BLL.Services.Abstract;
using IMDB.BLL.ValueInjecter;
using IMDB.DAL.Repository.Abstract;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private IMapper _map;
        private ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository _categoryRepository, IMapper map)
        {
            _map = map;
            categoryRepository = _categoryRepository;
        }
        public void Add(CategoryDTO model)
        {
            Category category = new Category();
            category.InjectFrom(model);
            categoryRepository.Add(category);

        }

        public void Delete(int Id)
        {
            Category category = categoryRepository.Get(x => x.Id == Id);
            categoryRepository.Delete(category);
        }

        public CategoryDTO GetById(int id)
        {
            CategoryDTO model = new CategoryDTO();
            var category = categoryRepository.Get(x => x.Id == id);
            model.InjectFrom(category);
            return model;
        }

        public List<CategoryDTO> GetList()
        {
            var category =categoryRepository.GetList();
            var model = _map.Map<List<CategoryDTO>>(category);
            return model;
        }

        public void Update(CategoryDTO model)
        {
            Category category = categoryRepository.Get(x => x.Id == model.Id);
            category.InjectFrom<FilterId>(model);
            categoryRepository.Update(category);
        }
    }
}
