using Microsoft.EntityFrameworkCore;
using WebLesson1.Models;

namespace WebApplication1.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<PC> PCs { get; set; } = null!;
    public DbSet<PCComponent> PCComponents { get; set; } = null!;
    public DbSet<ComponentType> ComponentTypes { get; set; } = null!;
    public DbSet<Component> Components { get; set; } = null!;
    public DbSet<ComponentManufacturer> ComponentManufactorers { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //PC
        modelBuilder.Entity<PC>()
            .HasKey(pc => pc.Id);
        //Component
        modelBuilder.Entity<Component>()
            .HasKey(p => p.Code);
        modelBuilder.Entity<ComponentType>()
            .HasKey(pt => pt.Id);
        modelBuilder.Entity<ComponentManufacturer>()
            .HasKey(mp => mp.Id);
    }
}