using Microsoft.EntityFrameworkCore;
using WebLesson1.Models;

namespace WebApplication1.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<PC> PCs { get; set; } = null!;
    public DbSet<PCComponent> PCComponents { get; set; } = null!;
    public DbSet<ComponentType> ComponentTypes { get; set; } = null!;
    public DbSet<Component> Components { get; set; } = null!;
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; } = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCComponent>().HasKey(pc => new { pc.PCId, pc.ComponentCode });
        ////PC
        //modelBuilder.Entity<PC>()
        //    .HasKey(pc => pc.Id);
        ////Component
        //modelBuilder.Entity<Component>()
        //    .HasKey(p => p.Code);
        //modelBuilder.Entity<ComponentType>()
        //    .HasKey(pt => pt.Id);
        //modelBuilder.Entity<ComponentManufacturer>()
        //    .HasKey(mp => mp.Id);
        modelBuilder.Entity<ComponentType>().HasData(
                new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor"},
                new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics card" },
                new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
            );
        modelBuilder.Entity<ComponentManufacturer>().HasData(
                new ComponentManufacturer { Id = 1, Abbreviation = "Intel", FullName = "Intel Corp.", foundationDate = new DateTime(1970, 1, 1)},
                new ComponentManufacturer { Id = 2, Abbreviation = "NVIDIA", FullName = "NVIDIA Corp.", foundationDate = new DateTime(1990, 1, 1)},
                new ComponentManufacturer { Id = 3, Abbreviation = "Kingston", FullName = "Kingston Corp.", foundationDate = new DateTime(1980, 1, 1)}
            );
        modelBuilder.Entity<Component>().HasData(
                new Component { Code = "I7-14700KF", Name = "Intel Core I7 14th gen", ComponentTypeId = 1, ComponentManufacturerId = 1},
                new Component { Code = "RTX4070", Name = "GeForce RTX4070", ComponentTypeId = 2, ComponentManufacturerId = 2},
                new Component { Code = "DDR4_32GB", Name = "Kingston 32GB DDR4 3200", ComponentTypeId = 3, ComponentManufacturerId = 3},
                new Component { Code = "DDR4_16GB", Name = "Kingston 16GB DDR4 3200", ComponentTypeId = 3, ComponentManufacturerId = 3}
            );
        modelBuilder.Entity<PC>().HasData(
                new PC { Id = 1, Name = "Gaming PC", Weight = 100, Warranty = 12, Stock = 1},
                new PC { Id = 2, Name = "Office PC", Weight = 1000, Warranty = 0, Stock = 10 }
            );
        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "I7-14700KF", Amount = 1},
            new PCComponent { PCId = 1, ComponentCode = "RTX4070", Amount = 1},
            new PCComponent { PCId = 1, ComponentCode = "DDR4_32GB", Amount = 1},
            new PCComponent { PCId = 2, ComponentCode = "I7-14700KF", Amount = 1},
            new PCComponent { PCId = 2, ComponentCode = "DDR4_16GB", Amount = 1}
            );
    }
}