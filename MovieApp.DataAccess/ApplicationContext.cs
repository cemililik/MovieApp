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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieCategory>()
                .HasKey(mc => new { mc.CategoryId, mc.MovieId });
            builder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.MovieId);
            builder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.CategoryId);

            builder.Entity<MovieStar>()
                .HasKey(ms => new { ms.MovieId, ms.StarId });
            builder.Entity<MovieStar>()
                .HasOne(ms => ms.Movie)
                .WithMany(s => s.MovieStars)
                .HasForeignKey(ms => ms.MovieId);
            builder.Entity<MovieStar>()
                .HasOne(ms => ms.Star)
                .WithMany(s => s.MovieStars)
                .HasForeignKey(ms => ms.StarId);
            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieStar> MovieStars { get; set; }
        public DbSet<Star> Stars { get; set; }

    }
}
