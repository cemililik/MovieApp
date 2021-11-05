using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }


        public List<Review> Reviews { get; set; }
    }
}
