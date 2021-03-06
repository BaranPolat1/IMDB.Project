﻿using IMDB.Base.Repository.Abstraction;
using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDB.DAL.Repository.Abstract
{
   public interface IAppUserRepository:IEntityRepository<AppUser>
    {
        ICollection<AppUser> GetByRole(string Id);
        IList<AppUser> GetByMovie(int Id);
    }
}
