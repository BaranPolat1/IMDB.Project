using IMDB.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Entites.Entity
{
   public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Descreption { get; set; }
    }
}
