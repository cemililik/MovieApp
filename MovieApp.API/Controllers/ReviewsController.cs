﻿using Microsoft.AspNetCore.Authorization;
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
    public class ReviewsController : ControllerBase
    {
        private IReviewService reviewService;
        private IMovieService movieService;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public ReviewsController(IReviewService _reviewService, IMovieService _movieService, UserManager<User> _userManager, SignInManager<User> _signInManager)
        {
            reviewService = _reviewService;
            movieService = _movieService;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpPost]
        [Route("[Action]")]
        [Authorize]
        public async Task<IActionResult> CreateReview([FromBody]Review reviewModel)
        {
            //var movie = await movieService.GetMovieById(reviewModel.MovieId);
            //var CreatedReview = new Review();
            //CreatedReview.ReviewText = reviewModel.ReviewText;
            //CreatedReview.ReviewScore = reviewModel.ReviewScore;
            //CreatedReview.MovieId = movie.MovieId;
            if (User.Identity.IsAuthenticated)
            {
                //var user = await userManager.FindByIdAsync(User.Identity.Name);
                //CreatedReview.UserId = user.Id;
            }
            else
            {
                //var user = await userManager.FindByIdAsync("9ee005d1-733d-4aa1-83cc-d05cb3c19854");
                reviewModel.UserId = "9ee005d1-733d-4aa1-83cc-d05cb3c19854";
            }
            await reviewService.CreateReview(reviewModel);
            reviewService.SaveChanges();
            return  Ok(reviewModel);
        }

      

    }
}
