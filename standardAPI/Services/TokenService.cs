using Microsoft.IdentityModel.Tokens;
using standardAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace standardAPI.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string audience, UserDto user);
    }
    public class TokenService : ITokenService
    {
        private readonly TimeSpan ExpiryDuration = new TimeSpan(3, 0, 0);

        public string BuildToken(string key, string issuer, string audience, UserDto user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
             };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
                expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
