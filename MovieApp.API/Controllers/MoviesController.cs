using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        //private UserManager<User> userManager;
        public MoviesController(IMovieService _movieService/*, UserManager<User> _userManager*/)
        {
            movieService = _movieService;
            //userManager = _userManager;
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
                //if (User.Identity.IsAuthenticated)
                //{
                //    //buraya user a ait yorum olan metod gelecek
                //    return Ok(movie);
                //}
                //else
                //{
                //    return Ok(movie);
                //}
                return Ok(movie);
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
