using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Concrete
{
    public class ReviewRepository : IReviewRepository
    {
        public async Task<Review> CreateReview(Review review)
        {
            using (var contex = new ApplicationContext())
            {
                await contex.Reviews.AddAsync(review);
                await contex.SaveChangesAsync();
                return review;
            }
        }

        public async Task<List<Review>> GetReviewByMovieId(int MovieID)
        {
            using (var contex = new ApplicationContext())
            {
                return await contex.Reviews
                    //.Include(j=>j.Movie)
                    //.Include(k=>k.User)
                    .Where(i => i.MovieId == MovieID).ToListAsync();
            }
        }

        public async Task<List<Review>> GetReviewByUserIdByMovieId(string UserId, int MovieId)
        {
            using (var contex = new ApplicationContext())
            {
                return await contex.Reviews.Where(i => i.MovieId == MovieId && i.UserId == UserId) .ToListAsync();
            }
        }

        public int SaveChanges()
        {
            using (var contex = new ApplicationContext())
            {
                return contex.SaveChanges();
            }
        }
    }
}
