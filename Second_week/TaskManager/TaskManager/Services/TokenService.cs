﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaskManager.Services
{

    public interface ITokenService
    {
        string GenerateToken(string userId, string role);
    }

    public class TokenService : ITokenService
    {

        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:SecretKey"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
        }

        public string GenerateToken(string userId, string role) 
        {
            // Определяем токен-параметры
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId),  // ID пользователя
            new Claim(ClaimTypes.Role, role),               // Роль пользователя
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Уникальный идентификатор токена
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Время жизни токена
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
