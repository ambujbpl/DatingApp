using AutoMapper;
using DotNetDatingApp.api.Data;
using DotNetDatingApp.api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDatingApp.api.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDatingRepository repo;
        public MessagesController(IDatingRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;

        }
    }
}