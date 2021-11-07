using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities
{
    public class MovieCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieCategoryId { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Movie Movie { get; set; }
        public Category Category { get; set; }
    }
}
