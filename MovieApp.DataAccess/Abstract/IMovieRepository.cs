using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Abstract
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Movie UpdateMovie(Movie movie);
        void GetMoviesFromApi(string url, string apiKey, string language, int pageNumber);
        Task<Movie> RandomMovie();
        Movie SendMovieWithEmail(string emailAddress, Movie movie);
        Root ApiCall(string url, string apiKey, string language, int pageNumber);
        int SaveChanges();
        //double MovieAvarageScore(int id);
    }
}
