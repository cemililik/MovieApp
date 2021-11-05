using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities
{
    public class Review
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        [Range(1,10,ErrorMessage ="Must be between 1 and 10")]
        public int ReviewScore { get; set; }


        public User User { get; set; }
        public Movie Movie { get; set; }




    }
}
