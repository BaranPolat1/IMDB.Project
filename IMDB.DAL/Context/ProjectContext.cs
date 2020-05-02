using IMDB.Entites.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.DAL.Context
{
    public class ProjectContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            const string databaseName = "IMDBProject";
            

            return $"Server=localhost;" +
                   $"database={databaseName};" +
                   $"Trusted_Connection = True;" +
                   $"MultipleActiveResultSets = True;" +
                    $"pooling=true;";
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<UserMovie>(b => b.HasNoKey());
            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }

    }
}
