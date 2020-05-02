using IMDB.DAL.Context;
using IMDB.DAL.Repository.Abstract;
using IMDB.DAL.Repository.BaseRepositoryEF;
using IMDB.Entites.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.DAL.Repository.Concrete
{
   public class UserMovieRepositoryEF:EntityRepositoryEF<UserMovie,ProjectContext>,IMovieUserRepository
    {
        


    }
}
