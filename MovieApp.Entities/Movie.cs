using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public double? AvarageScore { get; set; }


        public List<Review> Reviews { get; set; }
        public List<MovieStar> MovieStars { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
    }
}
