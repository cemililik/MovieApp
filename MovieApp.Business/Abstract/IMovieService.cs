using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Business.Abstract
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        double MovieAvarageScore(int id);
    }
}
