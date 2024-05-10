using APBDTest1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookEdition> BookEditions { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Editions)
            .WithOne(e => e.Book);
    }
}
