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
    public DbSet<Event>? Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>()
            .Property(p => p.Price)
            .HasPrecision(11, 2);


    }
}
