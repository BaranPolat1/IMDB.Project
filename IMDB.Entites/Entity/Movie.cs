using IMDB.Base.Entities;
using System;
using System.Collections;
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
   
       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
       
        public virtual ICollection<UserMovie> UserMovies { get; set; }
        public virtual ICollection<MovieImages> Images { get; set; }

    }
}
