using IMDB.Entites.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Infrastructure.DTO
{
   public class UserDTO
    {
        
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserMovie> UserMovie { get; set; }


    }
}
