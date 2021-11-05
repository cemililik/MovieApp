using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Abstract
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewByMovieId(int MovieId);
        Task<Review> CreateReview(Review review);
        Task<List<Review>> GetReviewByUserIdByMovieId(string UserId, int MovieId);
        int SaveChanges();

    }
}
