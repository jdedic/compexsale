using Microsoft.EntityFrameworkCore;
using RetailPlatform.Common.Entities;

namespace RetailPlatform.Infrastructure.Data
{
    public class RetailContext : DbContext
    {
        public RetailContext(DbContextOptions<RetailContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Add> Adds { get; set; }
        public DbSet<ProfileCategory> ProfileCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
