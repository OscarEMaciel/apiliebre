using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ItemDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        public ItemDbContext() { }

        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {
        }
    }
}
