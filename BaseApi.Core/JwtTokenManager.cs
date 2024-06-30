using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BaseApi.Core
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string userName);
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string userId, string userName)
        {
            var secretKey = new byte[32]; // 256 bit (32 byte) uzunluğunda bir gizli anahtar oluşturun
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(secretKey);
            }
            //var secretKey = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var signKey = new SymmetricSecurityKey(secretKey);
            var signingCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token süresi
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
