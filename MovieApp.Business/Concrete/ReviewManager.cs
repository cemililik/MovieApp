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
    public class ReviewManager : IReviewService
    {
        private IReviewRepository _reviewRepository;
        public ReviewManager()
        {
            _reviewRepository = new ReviewRepository();
        }
        public async Task<Review> CreateReview(Review review)
        {

            return await _reviewRepository.CreateReview(review);
        }

        public async Task<List<Review>> GetReviewByMovieId(int MovieId)
        {
            return await _reviewRepository.GetReviewByMovieId(MovieId);
        }

        public async Task<List<Review>> GetReviewByUserIdByMovieId(string UserId, int MovieId)
        {
            return await _reviewRepository.GetReviewByUserIdByMovieId(UserId, MovieId);
        }

        public int SaveChanges()
        {
            return _reviewRepository.SaveChanges();
        }
    }
}
