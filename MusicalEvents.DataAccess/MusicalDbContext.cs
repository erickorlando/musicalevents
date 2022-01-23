using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicalEvents.Entities;

namespace MusicalEvents.DataAccess;
public class MusicalDbContext : IdentityDbContext<MusicalUserIdentity>
{
    public MusicalDbContext() 
    {
        
    }

    public MusicalDbContext(DbContextOptions<MusicalDbContext> options)
    : base (options)
    {
        
    }

    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Concert>? Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Concert>()
            .Property(p => p.Price)
            .HasPrecision(11, 2);
        
        modelBuilder.Entity<Sale>()
            .Property(p => p.UnitPrice)
            .HasPrecision(11, 2);
        
        modelBuilder.Entity<Sale>()
            .Property(p => p.TotalSales)
            .HasPrecision(11, 2);

        modelBuilder.Entity<Sale>()
            .HasIndex(p => p.UserId, $"IX_Sale_User");

    }
}
