using BitsOrch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitsOrch.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<FieldEntity> Fields { get; set; }
}