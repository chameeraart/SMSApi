using SMSApi.Dto;
using SMSApi.Infrastructure;
using SMSApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace SMSApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;

        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [AllowAnonymous]
        [HttpPost("Login")] 
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _auth.Auth(loginDto);
            return new ObjectResult(token);
        }
    }
}
