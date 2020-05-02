using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Infrastructure.DTO
{
   public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}
