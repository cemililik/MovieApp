using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieApp.API.Models;
using MovieApp.DataAccess;
using MovieApp.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        private IConfiguration configuration;
        private RoleManager<IdentityRole> roleManager;
        public UsersController(UserManager<User> _usermanager,
            ApplicationContext _context,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IConfiguration _configuration)
        {
            usermanager = _usermanager;
            context = _context;
            signInManager = _signInManager;
            configuration = _configuration;
            roleManager = _roleManager;
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> SignUp([FromBody] UserModel user)
        {
            var newuser = new User();
            newuser.UserName = user.EmailAddress;
            newuser.Email = user.EmailAddress;
            IdentityResult result = await usermanager.CreateAsync(newuser, user.Password);
            var role = "Admin";
            await roleManager.CreateAsync(new IdentityRole(role));
            if (result.Succeeded)
            {
                context.SaveChanges();
                return Ok(newuser);
            }
            else
            {
                return BadRequest(new { message = "Problem. Try" });
            }
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> SignIn([FromBody] UserModel user)
        {
            var _user = await usermanager.FindByEmailAsync(user.EmailAddress);
            var result = await signInManager.PasswordSignInAsync(_user, user.Password, true, true);
            var test = context.Users.Select(x => x.Email == user.EmailAddress);
            if (result.Succeeded)
            {
                //var token2 = generateJwtToken(user);
                //var token = generateJwtToken
                //---- - Token Creator
                var TokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configuration["JWTKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        //new Claim(ClaimTypes.Role)
                        new Claim("id", _user.Id)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = TokenHandler.CreateToken(tokenDescriptor);
                user.Token = TokenHandler.WriteToken(token);
                user.UserId = _user.Id;
                return Ok(user);
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
        }
    }
}

