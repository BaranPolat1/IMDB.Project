using IMDB.Base.Repository.Abstraction;
using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.DAL.Repository.Abstract
{
   public interface IMovieRepository:IEntityRepository<Movie>
    {
        ICollection<Movie> GetByStarOrDirector(string Id);
    }
}
