using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.AuthenticationService.Contracts;
using University.AuthenticationService.Models;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody]TokenRequestModel model)
        {
            var token = _authService.GetToken(model);

            return Ok(token);
        }
    }
}
