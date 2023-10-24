using Kiosk.Domain.Models;

namespace Kiosk.Services.UserService.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        Task<string?> ValidateRefreshTokenAsync(User user, string refreshToken);
        Task<string> GenerateRefreshTokenAsync(User user);
        Task InvalidateAllTokens(User user);
    }
}
