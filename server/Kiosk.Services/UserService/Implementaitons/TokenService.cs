using Kiosk.DataAccess.Repositories.Interfaces;
using Kiosk.Domain.Models;
using Kiosk.Services.UserService.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Kiosk.Services.UserService.Implementaitons
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository _tokenRepository;
        public TokenService(IConfiguration configuration, ITokenRepository tokenRepository)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var expireTime = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:Expire"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expireTime,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateRefreshTokenAsync(User user)
        {
            string token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            UserRefreshToken tokenEntry = new UserRefreshToken { User = user, RefreshToken = token, UserId = user.Id, ExpireTime = DateTime.Now.AddDays(7) };
            await _tokenRepository.InsertAsync(tokenEntry);
            return token;
        }

        public async Task<string?> ValidateRefreshTokenAsync(User user, string refreshToken)
        {
            List<UserRefreshToken> userTokens = await _tokenRepository.GetAllByUserIdAsync(user.Id);
            UserRefreshToken foundToken = userTokens.FirstOrDefault(t => t.RefreshToken == refreshToken);

            if (foundToken == null) return null;
            if(foundToken.ExpireTime < DateTime.Now)
            {
                await _tokenRepository.DeleteAsync(foundToken.Id);
                return null;
            }

            string newToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            UserRefreshToken newTokenEntry = new UserRefreshToken { User = user, UserId = user.Id, RefreshToken = newToken, ExpireTime = DateTime.Now.AddDays(7) };

            await _tokenRepository.RefreshAsync(foundToken, newTokenEntry);
            return newToken;
        }

        public async Task InvalidateAllTokens(User user)
        {
            await _tokenRepository.RemoveAllByUserIdAsync(user.Id);
        }
    }
}
