using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MovieApp.Entities
{
    public class User : IdentityUser
    {

        public ICollection<Review> Reviews { get; set; }
    }
}
