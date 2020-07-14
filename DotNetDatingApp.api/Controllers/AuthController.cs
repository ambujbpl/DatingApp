using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotNetDatingApp.api.Data;
using DotNetDatingApp.api.Dtos;
using DotNetDatingApp.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DotNetDatingApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // validation request
            userForRegisterDto.username = userForRegisterDto.username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.username))
                return BadRequest("user name already exist");
            var userToCreate = new User
            {
                userName = userForRegisterDto.username
            };
            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.password);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            // try {
                throw new Exception("test exception for handling exception module");
                var userFromRepo = await _repo.Login(userForLoginDto.username.ToLower(), userForLoginDto.password);
                if (userFromRepo == null)
                    return Unauthorized();

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.userName)
                };
                

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new {
                    token = tokenHandler.WriteToken(token)
                });
            // } catch {
            //     return StatusCode(500,"computer realy says no");
            // }           
            
        }
    }
}