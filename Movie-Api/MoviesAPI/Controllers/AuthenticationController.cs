using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Repo;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IJWTManagerRepository _TokenManager;

        public AuthenticationController(IJWTManagerRepository tokenManager)
        {
            this._TokenManager = tokenManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var token = _TokenManager.Authentication(login);

            return response = Ok(new { token = token }); ;
        }
    }
}
