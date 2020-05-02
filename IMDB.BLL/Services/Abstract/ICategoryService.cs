using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Abstract
{
    public interface ICategoryService
    {
        ICollection<CategoryDTO> GetList();
        void Add(CategoryDTO model);
        void Delete(int Id);
        void Update(CategoryDTO category);
        CategoryDTO GetById(int id);
    }
}
