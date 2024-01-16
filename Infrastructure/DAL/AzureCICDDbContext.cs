using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL
{
    public class AzureCICDDbContext : DbContext
    {
        public AzureCICDDbContext(DbContextOptions<AzureCICDDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Model configuration goes here
        }
    }
}
