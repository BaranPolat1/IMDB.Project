using IMDB.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Infrastructure.VM
{
    public class MovieCategoryVM
    {
       
        public MovieDTO Movie { get; set; }
        public IList<CategoryDTO> Categories { get; set; }
    }
}
