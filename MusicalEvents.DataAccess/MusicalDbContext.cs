using Microsoft.EntityFrameworkCore;
using MusicalEvents.Entities;

namespace MusicalEvents.DataAccess;
public class MusicalDbContext : DbContext
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
