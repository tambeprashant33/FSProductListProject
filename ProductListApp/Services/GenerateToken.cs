using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductListApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace ProductListApp.Services
{
    public class GenerateToken
    {
        public static string? CreateToken(Login model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Productlist@12345!#SuperSecureKey987!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "productlistissuer",
                    audience: "productlistaudience",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }
    }

}
