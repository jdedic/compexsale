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
    }
}
