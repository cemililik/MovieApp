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

        public Movie UpdateMovie(Movie movie)
        {
            return _movieRepository.UpdateMovie(movie);
        }
        public int SaveChanges()
        {
            return _movieRepository.SaveChanges();
        }

        public void GetMoviesFromApi(string url, string apiKey, string language, int pageNumber)
        {
            _movieRepository.GetMoviesFromApi(url, apiKey, language, pageNumber);
        }

        public Task<Movie> RandomMovie()
        {
            return _movieRepository.RandomMovie();
        }

        public Movie SendMovieWithEmail(string emailAddress, Movie movie)
        {
            return _movieRepository.SendMovieWithEmail(emailAddress, movie);
        }
    }
}
