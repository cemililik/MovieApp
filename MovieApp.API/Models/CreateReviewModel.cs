using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.API.Models
{
    public class CreateReviewModel
    {
        public string ReviewText { get; set; }
        [Range(1, 10, ErrorMessage = "Must be between 1 and 10")]
        public int ReviewScore { get; set; }
        public int MovieId { get; set; }
    }
}
