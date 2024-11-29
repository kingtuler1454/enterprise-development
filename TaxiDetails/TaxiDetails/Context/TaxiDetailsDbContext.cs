using Microsoft.EntityFrameworkCore;

namespace TaxiDetails.Context;
/// <summary>
/// class about context of taxi details
/// </summary>
public class TaxiDetailsDbContext(DbContextOptions<TaxiDetailsDbContext> options) : DbContext(options)
{
    public DbSet<Travel> Travels { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Travel>()
            .HasOne(t => t.AssignedCar)
                .WithMany()
                .HasForeignKey("assigned_car")
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Travel>()
            .Property(t => t.TripDate)
                .HasConversion(
                    v => v.HasValue ? v.Value.ToUniversalTime() : (DateTime?)null,
                    v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : (DateTime?)null
                );

        modelBuilder.Entity<Travel>()
            .HasOne(t => t.Client)
                .WithMany()
                .HasForeignKey("client")
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Car>()
            .HasOne(c => c.AssignedDriver)
                .WithMany()
                .HasForeignKey("assigned_driver")
                .OnDelete(DeleteBehavior.Cascade);
    }
}
