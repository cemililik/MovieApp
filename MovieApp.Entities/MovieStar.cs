using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities
{
    public class MovieStar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieStarId { get; set; }
        public int MovieId { get; set; }
        public int StarId { get; set; }
    }
}
