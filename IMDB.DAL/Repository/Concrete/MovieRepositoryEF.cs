using IMDB.DAL.Context;
using IMDB.DAL.Repository.Abstract;
using IMDB.DAL.Repository.BaseRepositoryEF;
using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDB.DAL.Repository.Concrete
{
    public class MovieRepositoryEF : EntityRepositoryEF<Movie, ProjectContext>, IMovieRepository
    {
        public ICollection<Movie> GetByStarOrDirector(string Id)
        {
            using (var db = new ProjectContext())
            {
                var result = db.UserMovies.Where(x => x.AppUserId == Id).ToList();
                List<Movie> movie = new List<Movie>();
                foreach (var item in result)
                {
                    movie.AddRange(db.Movies.Where(x => x.Id == item.MovieId));
                }
                return movie;
            }

        }
    }
}
