using Kiosk.DataAccess.Context;
using Kiosk.DataAccess.Repositories.Interfaces;
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.DataAccess.Repositories.Implementations
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task DeleteAsync(long id)
        {
            T toDelete = await _context.Set<T>().FindAsync(id);
            if (toDelete == null) return;

            _context.Set<T>().Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            var res = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var res = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
    }
}
