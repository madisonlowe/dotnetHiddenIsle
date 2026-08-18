using Microsoft.EntityFrameworkCore;
using HiddenIsle.API.Models;

namespace HiddenIsle.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Agent> Agents => Set<Agent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Agent>(agent =>
    {
        agent.OwnsOne(a => a.CoreSelf, core =>
        {
            core.Property(c => c.ChildSelf)
                .HasColumnName("CoreSelfChildSelf");

            core.Property(c => c.AdultSelf)
                .HasColumnName("CoreSelfAdultSelf");

            core.PrimitiveCollection(c => c.FulfilledVirtues)
                .HasColumnName("CoreSelfFulfilledVirtues")
                .HasColumnType("text[]");
        });

        agent.OwnsOne(a => a.Inventory, inventory =>
        {
            inventory.Property(i => i.Load)
                .HasColumnName("InventoryLoad");

            inventory.PrimitiveCollection(i => i.Items)
                .HasColumnName("InventoryItems")
                .HasColumnType("text[]");
        });
    });
}
}