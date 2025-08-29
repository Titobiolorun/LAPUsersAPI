using LAPUsersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LAPUsersAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}
