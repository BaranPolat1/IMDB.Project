using IMDB.Base.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMDB.Entites.Entity
{
   public class AppUser:IdentityUser
    {
      
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<UserMovie> UserMovie { get; set; }

     
        
        

    }
}
