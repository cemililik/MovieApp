using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        public async Task<List<Movie>> GetAllMovies()
        {
            using var contex = new ApplicationContext();
            return await contex.Movies
                .ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            using var contex = new ApplicationContext();
            return contex.Movies
                .Include(i => i.Reviews)
                .FirstOrDefault(j => j.MovieId == id);
        }
        public void Dispose()
        {
            using var contex = new ApplicationContext();
            contex.Dispose();
        }

        public Movie UpdateMovie(Movie movie)
        {
            using var contex = new ApplicationContext();
            {
                contex.Movies.Update(movie);
                return movie;
            }
             
        }
        public int SaveChanges()
        {
            using (var contex = new ApplicationContext())
            {
                return contex.SaveChanges();
            }
        }

        public Root ApiCall(string url,string apiKey,string language, int pageNumber)
        {
            var ApiUrl = url + "?api_key=" + apiKey + "&language=" + language + "&page=" + pageNumber;

            Uri url1 = new Uri(ApiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url1);
            Root rootdata = JsonConvert.DeserializeObject<Root>(json);
            return rootdata;
        }
            
        public void GetMoviesFromApi(string url, string apiKey, string language, int pageNumber)
        {
            for (int i = 1; i <= pageNumber; i++)
            {
                
                Root rootdata = ApiCall(url, apiKey, language, i);
                using var contex = new ApplicationContext();
                {
                    foreach (var item in rootdata.results)
                    {
                        Movie movietemp = new Movie();
                        movietemp.MovieName = item.title;
                        movietemp.Description = item.overview;
                        movietemp.TotalScore = 0;

                        var check = contex.Movies.FirstOrDefault(i => i.MovieName == item.title);
                        if (check == null)
                        {
                            contex.Movies.Add(movietemp);
                        }


                    }
                    contex.SaveChanges();
                }
            }
        }

        

        public async Task<Movie> RandomMovie()
        {
            var movies = await GetAllMovies();
            Random rnd = new Random();
            int rand = rnd.Next(0, movies.Count);
            var randmovie = movies[rand];
            return randmovie;
        }

        public Movie SendMovieWithEmail(string emailAddress, Movie movie)
        {
            //----- Message 
            MailMessage msg = new MailMessage(); 
            msg.Subject = "Recommended Movie";
            msg.From = new MailAddress("movieapprecommender@gmail.com", "Recommender from MovieApp");
            msg.To.Add(new MailAddress(emailAddress, emailAddress));

            
            msg.IsBodyHtml = false;
            msg.Body = "\nMovie Name : " + movie.MovieName + "\n\nMovie Description : " + movie.Description;
            msg.Priority = MailPriority.High;

            //Client information
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("movieapprecommender@gmail.com", "Ma2021Ma.");
            client.EnableSsl = true;
            client.Send(msg);
            return movie;
        }
    }
}
