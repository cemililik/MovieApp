using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Models;
using MovieApp.Business.Abstract;
using MovieApp.Business.Concrete;
using MovieApp.DataAccess;
using MovieApp.Entities;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MovieApp.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService movieService;
        private IReviewService reviewService;
        private UserManager<User> userManager;
        public MoviesController(
            IMovieService _movieService,
            IReviewService _reviewService,
            UserManager<User> _userManager)
        {
            movieService = _movieService;
            reviewService = _reviewService;
            userManager = _userManager;
        }
        [HttpGet]
        [Route("[action]/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllMovies(int pageNumber,int pageSize)
        {
            var movies = await movieService.GetAllMovies();
            PagedList<Movie> result = new PagedList<Movie>(movies, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            if (User.Identity.IsAuthenticated)
            {

                var movie = await movieService.GetMovieById(id);
                if (movie != null)
                {
                    var user = await userManager.FindByNameAsync(User.Identity.Name);
                    var reviews = await reviewService.GetReviewByUserIdByMovieId(user.Id, id);
                    movie.Reviews = reviews;
                    return Ok(movie);
                }
                else
                    return NotFound();

            }
            else
            {
                var movie = await movieService.GetMovieById(id);
                if (movie != null)
                {
                    return Ok(movie);
                }
                else
                    return NotFound();
            }
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                review.UserId = user.Id;
                await reviewService.CreateReview(review);

                //--for calculate awarage score for movie
                var movie = await movieService.GetMovieById(review.MovieId);
                movie.TotalScore += review.ReviewScore;
                int scorecount = movie.Reviews.Count();
                movie.AvarageScore = movie.TotalScore / scorecount;
                movieService.UpdateMovie(movie);
                reviewService.SaveChanges();
                return Ok(review);
            }
            else
            {
                //----- For now
                review.UserId = "144145ac-e163-47cd-89bb-d59d682ddfba";
                await reviewService.CreateReview(review);

                //---- Temp for test

                //--for calculate awarage score for movie ********IS NOT WORKING********
                var movie = await movieService.GetMovieById(review.MovieId);
                movie.TotalScore = movie.TotalScore + review.ReviewScore;
                int scorecount = movie.Reviews.Count();
                movie.MovieName = "Changed1111";
                movie.AvarageScore = movie.TotalScore / scorecount;
                //movieService.UpdateMovie(movie);
                movieService.SaveChanges();
                //--- Temp for test end
                reviewService.SaveChanges();
                return Ok(review);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetFromApiManual()
        {
            string url = "https://api.themoviedb.org/3/movie/popular"; 
            string apiKey = "113287fcce86d993c720b63139ee4826";
            string language = "en-US";
            int pageNumber = 55;
            movieService.GetMoviesFromApi(url, apiKey, language, pageNumber);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RecommendRandomMovie([FromBody] string emailaddress)
        {
            var movie = await movieService.RandomMovie();
            var sendedMovie = movieService.SendMovieWithEmail(emailaddress, movie);
            return Ok(sendedMovie);
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> RecommendMovieById(int id, [FromBody] string emailaddress)
        {
            var movie = await movieService.GetMovieById(id);
            var sendedMovie = movieService.SendMovieWithEmail(emailaddress, movie);
            return Ok(sendedMovie);
        }
    }
}
