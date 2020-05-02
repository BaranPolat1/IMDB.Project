using IMDB.BLL.Services.Abstract;
using IMDB.DAL.Repository.Abstract;
using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Concrete
{
    
    public class MovieUserService : IMovieUserService
    {
        private IMovieUserRepository movieUserRepository;
        public MovieUserService(IMovieUserRepository _movieUserRepository)
        {
            movieUserRepository = _movieUserRepository;
        }
        public void Add(string userId,int movieId)
        {
            UserMovie userMovie = new UserMovie();
            userMovie.AppUserId = userId;
            userMovie.MovieId = movieId;
            movieUserRepository.Add(userMovie);
        }
    }
}
