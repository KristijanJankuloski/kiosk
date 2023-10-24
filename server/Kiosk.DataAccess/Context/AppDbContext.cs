using Kiosk.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products {  get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserRefreshToken> RefreshTokens { get; set; }

        public AppDbContext(DbContextOptions options): base(options) { }
    }
}
