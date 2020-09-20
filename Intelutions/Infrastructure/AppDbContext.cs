using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());

            FillDB(modelBuilder);
        }

        private void FillDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType
                {
                    Id = 1,
                    Description = "Enfermedad"
                },
                new PermissionType
                {
                    Id = 2,
                    Description = "Diligencias"
                },
                new PermissionType
                {
                    Id = 3,
                    Description = "Vacaciones"
                }
            );
        }
    }
}
