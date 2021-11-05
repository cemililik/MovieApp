using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Models;
using MovieApp.DataAccess;
using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<User> usermanager;
        private SignInManager<User> signInManager;
        private ApplicationContext context;
        public UsersController(UserManager<User> _usermanager, ApplicationContext _context, SignInManager<User> _signInManager)
        {
            usermanager = _usermanager;
            context = _context;
            signInManager = _signInManager;
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> SignUp([FromBody] UserModel user)
        {
            var newuser = new User();
            newuser.UserName = user.EmailAddress;
            newuser.Email = user.EmailAddress;
            IdentityResult result = await usermanager.CreateAsync(newuser, user.Password);
            if (result.Succeeded)
            {
                context.SaveChanges();
                return Ok(newuser);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> SignIn([FromBody] UserModel user)
        {
            var _user = await usermanager.FindByEmailAsync(user.EmailAddress);
            var result = await signInManager.PasswordSignInAsync(_user, user.Password,true,true);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
