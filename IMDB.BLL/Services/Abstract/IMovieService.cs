
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using IMDB.Infrastructure.VM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Abstract
{
   public interface IMovieService
    {
        public void Update(MovieDTO model);
        public ICollection<MovieDTO> GetList();
        public void Add(MovieDTO model,int categoryId,List<IFormFile> files, string name, string descreption);
        public MovieDTO Update(int Id);
        public void Delete(int Id);
        public MovieDTO GetById(int id);
        public MovieDTO GetByName(string name);
        public ICollection<MovieDTO> GetByCategory(int categoryId);
        public ICollection<MovieDTO> GetByStarOrDirector(string userId);
     
        
        
    }
}
