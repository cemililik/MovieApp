using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.API.Models
{
    public class MovieReviewModel
    {
        public Movie Movie { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
