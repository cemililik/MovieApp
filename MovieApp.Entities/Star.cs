using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities
{
    public class Star
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StarId { get; set; }
        public string StarName { get; set; }
        public string StarDescription { get; set; }

        public List<MovieStar> MovieStars { get; set; }
    }
}
