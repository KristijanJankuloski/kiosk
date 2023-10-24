using Kiosk.DataAccess.Context;
using Kiosk.DataAccess.Repositories.Interfaces;
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.DataAccess.Repositories.Implementations
{
    public class TokenRepository : BaseRepository<UserRefreshToken>, ITokenRepository
    {
        private readonly AppDbContext _context;
        public TokenRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserRefreshToken>> GetAllByUserIdAsync(string userId)
        {
            return await _context.RefreshTokens.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task RefreshAsync(UserRefreshToken oldToken, UserRefreshToken newToken)
        {
            _context.RefreshTokens.Remove(oldToken);
            await _context.RefreshTokens.AddAsync(newToken);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAllByUserIdAsync(string userId)
        {
            var tokens = await _context.RefreshTokens.Where(t => t.UserId == userId).ToArrayAsync();
            _context.RefreshTokens.RemoveRange(tokens);
            await _context.SaveChangesAsync();
        }
    }
}
