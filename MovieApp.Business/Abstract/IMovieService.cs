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
        Movie UpdateMovie(Movie movie);
        void GetMoviesFromApi(string url, string apiKey, string language, int pageNumber);
        Task<Movie> RandomMovie();
        Movie SendMovieWithEmail(string emailAddress, Movie movie);
        int SaveChanges();
        //double MovieAvarageScore(int id);
    }
}
