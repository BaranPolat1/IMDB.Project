
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
        public void Update(MovieDTO model,int Id,string name,string descreption,int categoryId,string[] IdToAdd);
        public ICollection<MovieDTO> GetList();
        public void Add(MovieDTO model,string name,string descreption,int categoryId);
        public MovieCategoryVM Update(int Id);
        public void Delete(int Id);
        public MovieDTO GetById(int id);
        public MovieDTO GetByName(string name);
        public ICollection<MovieDTO> GetByCategory(int categoryId);
        public ICollection<MovieDTO> GetByStarOrDirector(string userId);
        void AddImage(List<IFormFile> files, int Id);
        MovieDTO Details(int Id);
     
        
        
    }
}
