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
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
    }
}
