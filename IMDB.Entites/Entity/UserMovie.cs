using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Entites.Entity
{
    public class UserMovie
    {
     

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
