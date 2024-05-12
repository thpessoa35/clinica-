using employe;
using HospitalSolution.Application.Common.Interfaces.Authentication;
using HospitalSolution.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuaAplicacao.Infraestrutura.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly string _secretKey;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _secretKey = configuration["Logging:JwtSettings:SecretKey"];
        }

        public string GenerateToken(Employe employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, employee.FirstName.ToString())
            };                           
            var securityToken = new JwtSecurityToken(       
                claims: claims,                             
                expires: DateTime.UtcNow.AddDays(7),        
                signingCredentials: credentials             
            );                             
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }                       
    }
}
