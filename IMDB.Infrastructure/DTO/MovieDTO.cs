using IMDB.Entites.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Infrastructure.DTO
{
    public class MovieDTO
    {
      
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public string[] IdToAdd { get; set; }
         public IList<AppUser> Member { get; set; }
        public IList<AppUser> NonMember { get; set; }
        public IList<MovieImages> Images { get; set; }
        

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public ICollection<UserMovie> UserMovies { get; set; }
        
    }
}
