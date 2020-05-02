using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Services.Abstract
{
    public interface IMovieUserService
    {
        bool Any(string userId, int movieId);
    }
}
