using Microsoft.AspNetCore.Authorization;
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
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieService.GetAllMovies();
            return Ok(movies);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await movieService.GetMovieById(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }
    }
}
