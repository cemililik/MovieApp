using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        public async Task<List<Movie>> GetAllMovies()
        {
            using(var contex = new ApplicationContext())
            {
                
                return await contex.Movies.ToListAsync();
            }
        }

        public async Task<Movie> GetMovieById(int id)
        {
            using (var contex = new ApplicationContext())
            {
                return contex.Movies
                    .Include(i=>i.Reviews)
                    .FirstOrDefault(j=>j.MovieId == id); 
            }
        }
        public void Dispose()
        {
            using (var contex = new ApplicationContext())
            {
                contex.Dispose();
            }
        }

        public double MovieAvarageScore(int id)
        {
            using (var contex = new ApplicationContext())
            {
                var movie = contex.Movies
                    .Include(i => i.Reviews)
                    .Where(j => j.MovieId == id);
                double Avarage = movie.Average(i => i.Reviews.Count);
                return Avarage;
            }
        }
    }
}
