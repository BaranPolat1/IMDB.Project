﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Infrastructure.VM
{
   public class RegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
