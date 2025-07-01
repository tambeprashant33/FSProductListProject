using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductListApp.Models;
using ProductListApp.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login model)
        {
            var token = GenerateToken.CreateToken(model);
            if(token != null)
            {
                return Ok(new { token });
            }
            
            return Unauthorized();
        }
    }
}
