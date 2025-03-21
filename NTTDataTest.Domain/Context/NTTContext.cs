using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Entities;

namespace NTTDataTest.Domain.Context;

public class NTTContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cart> Carts { get; set; }
 
    public NTTContext(DbContextOptions<NTTContext> ctxOpts) : base(ctxOpts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>().HasMany(x => x.products);
    }
}
