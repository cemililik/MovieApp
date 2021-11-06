using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Models;
using MovieApp.Business.Abstract;
using MovieApp.Business.Concrete;
using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService movieService;
        private IReviewService reviewService;
        //private UserManager<User> userManager;
        public MoviesController(IMovieService _movieService, IReviewService _reviewService)
        {
            movieService = _movieService;
            reviewService = _reviewService;
        }
        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await movieService.GetMovieById(id);
            if (movie != null)
            {
                var _movie = new MovieReviewModel();
                _movie.Movie = movie;
                if (User.Identity.IsAuthenticated)
                {
                    _movie.Reviews = await reviewService.GetReviewByMovieId(id);
                    return Ok(movie);
                }
                else
                {
                    _movie.Reviews = await reviewService.GetReviewByMovieId(id);
                    return Ok(movie);
                }
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public double ReviewCount(int id)
        {
            double c = movieService.MovieAvarageScore(id);
            return c;
        }
    }
}
