
using Microsoft.EntityFrameworkCore;
using StockEnquiry.API.Models;

namespace StockEnquiry.API.Data;

public class StockDbContext : DbContext
{
    public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
    {
    }

    public DbSet<Part> Parts => Set<Part>();

    public DbSet<StockDetail> StockDetails => Set<StockDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Part>()
            .HasKey(p => p.PartNumber);

        modelBuilder.Entity<StockDetail>()
            .HasKey(s => s.StockId);

        modelBuilder.Entity<StockDetail>()
            .HasOne(s => s.Part)
            .WithMany(p => p.StockDetails)
            .HasForeignKey(s => s.PartNumber);
    }
}
