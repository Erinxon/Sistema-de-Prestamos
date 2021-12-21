using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Prestamos.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Tools
{
    public static class GenerateJWT
    {
        public static string Generate(Usuario user, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Nombres),
                new Claim(ClaimTypes.Surname, user.Apellidos),
                new Claim(ClaimTypes.Role, user.Rol.Roles.ToString()),
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],config["Jwt:Audience"], 
              claims, expires: DateTime.Now.AddDays(2),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
