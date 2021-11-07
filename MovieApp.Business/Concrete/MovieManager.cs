using MovieApp.Business.Abstract;
using MovieApp.DataAccess.Abstract;
using MovieApp.DataAccess.Concrete;
using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovieRepository _movieRepository;
        public MovieManager()
        {
            _movieRepository = new MovieRepository();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _movieRepository.GetMovieById(id);
        }

        //public double MovieAvarageScore(int id)
        //{
        //    return _movieRepository.MovieAvarageScore(id);
        //}
    }
}
