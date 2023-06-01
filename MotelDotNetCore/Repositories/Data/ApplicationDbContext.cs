using Helpers;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repositories.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> UserEntities { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        var connectionString = AppSettings.Get("ConnectionStrings:PostgresqlDb");
        
        optionsBuilder.UseNpgsql(connectionString, builder =>
        {
            builder.MigrationsAssembly("MotelDotNetCore");
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>();
    }
}