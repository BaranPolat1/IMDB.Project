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

            builder.Entity<UserMovie>(b => b.HasOne<AppUser>(navigationExpression: uf => uf.AppUser)
           .WithMany(navigationExpression: nf => nf.UserMovie)
           .HasForeignKey(nf => nf.AppUserId));

            builder.Entity<UserMovie>(b => b.HasOne<Movie>(navigationExpression: uf => uf.Movie)
          .WithMany(navigationExpression: nf => nf.UserMovies)
          .HasForeignKey(nf => nf.MovieId));

            builder.Entity<UserMovie>(b => b.HasKey(x => new { x.AppUserId, x.MovieId }));

            base.OnModelCreating(builder);
        }



        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }


    }
}
