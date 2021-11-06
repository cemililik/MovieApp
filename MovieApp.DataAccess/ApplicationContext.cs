using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entities;
using System;

namespace MovieApp.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:94.73.170.45;Database=u0010046_north;User ID=u0010046_north;Password=IKoj35Q0SSqz14G;Trusted_Connection=False;MultipleActiveResultSets=true;");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieStar> MovieStars { get; set; }
        public DbSet<Star> Stars { get; set; }

    }
}
