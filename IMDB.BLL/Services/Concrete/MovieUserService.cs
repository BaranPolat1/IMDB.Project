using IMDB.BLL.Services.Abstract;
using IMDB.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Concrete
{
    public class MovieUserService : IMovieUserService
    {
        private IMovieUserRepository _repo;
        public MovieUserService(IMovieUserRepository repo)
        {
            _repo = repo;
        }
        public bool Any(string userId, int movieId)
        {
            return _repo.Any(x => x.AppUserId == userId && x.MovieId == movieId);
        }
    }
}
