using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Abstract
{
   public interface IMovieImageService
    {
        void Add(MovieImages image,int movieId,string path);
        ICollection<MovieImages> GetByMovies(int movieId);
    }
}
