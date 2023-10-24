using Kiosk.Domain.Models;

namespace Kiosk.DataAccess.Repositories.Interfaces
{
    public interface ITokenRepository : IRepository<UserRefreshToken>
    {
        Task<List<UserRefreshToken>> GetAllByUserIdAsync(string userId);
        Task RefreshAsync(UserRefreshToken oldToken,  UserRefreshToken newToken);
        Task RemoveAllByUserIdAsync(string userId);
    }
}
