using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jwt.Repository;
using jwt.Model;

namespace jwt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jwtManager;

        public UsersController(IJWTManagerRepository jwtManager)
        {
            this._jwtManager = jwtManager;
        }
        [HttpGet]

        public List<string> Get()
        {
            var users = new List<string>
            {
                "DataOne",
                "DataTwo",
                "DataThree"
            };
            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]

        public IActionResult Authenticate(Users userdata)
        {
            var token = _jwtManager.Authenticate(userdata);

            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
    
}
