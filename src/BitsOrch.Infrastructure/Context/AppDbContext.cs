using BitsOrch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitsOrch.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<FieldEntity> Fields { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FieldEntity>()
            .Property(b => b.Salary)
            .HasPrecision(14, 2);
    }
}