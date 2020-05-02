using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Abstract
{
    public interface IMovieUserService
    {
        void Add(string userId,int movieId);
    }
}
