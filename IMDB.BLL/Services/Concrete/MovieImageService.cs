using IMDB.BLL.Services.Abstract;
using IMDB.DAL.Repository.Abstract;
using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Concrete
{
  
    public class MovieImageService : IMovieImageService
    {
        private IMovieImageRepository _movieImageRepository;
        public MovieImageService(IMovieImageRepository movieImageRepository)
        {
            _movieImageRepository = movieImageRepository;
        }
        public void Add(MovieImages image, int movieId,string path)
        {
            image.Path = path;
            image.MovieId = movieId;
            _movieImageRepository.Add(image);
           
        }

        public IList<MovieImages> GetByMovies(int movieId)
        {
            return _movieImageRepository.GetList(x => x.MovieId == movieId);
        }
    }
}
