using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MovieApp.Entities
{
    public class User : IdentityUser
    {

        public List<Review> Reviews { get; set; }
    }
}
