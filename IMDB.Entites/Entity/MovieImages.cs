using IMDB.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Entites.Entity
{
   public class MovieImages:BaseEntity
    {
        public string Path { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
