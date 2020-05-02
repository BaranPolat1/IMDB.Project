using IMDB.Base.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMDB.Entites.Entity
{
   public class Movie:BaseEntity
    {
        public string Name { get; set; }
        public string Descreption { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [NotMapped]
        public List<string> ImagePaths { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
       [NotMapped]
        public ICollection<UserMovie> UserMovies { get; set; }
    }
}
