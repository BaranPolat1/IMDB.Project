using IMDB.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Infrastructure.VM
{
    public class MovieCategoryVM
    {
        public MovieCategoryVM()
        {
            Categories = new List<CategoryDTO>();
        }
        public MovieDTO Movie { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}
