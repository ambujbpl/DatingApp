using System.Threading.Tasks;
using DotNetDatingApp.api.Data;
using DotNetDatingApp.api.Dtos;
using DotNetDatingApp.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDatingApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // validation request
            userForRegisterDto.username = userForRegisterDto.username.ToLower();
            if(await _repo.UserExists(userForRegisterDto.username))
                return BadRequest("user name already exist");
            var userToCreate = new User
            {
                userName = userForRegisterDto.username
            };
            var createdUser = await _repo.Register(userToCreate,userForRegisterDto.password);
            return StatusCode(201);
        }
    }
}