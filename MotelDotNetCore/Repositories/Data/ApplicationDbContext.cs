using Microsoft.EntityFrameworkCore;
using Models.Entities;
using MotelDotNetCore;

namespace Repositories.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> UserEntities { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = AppSettings.Get("AppSettings:Postgresql");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>();
    }
}