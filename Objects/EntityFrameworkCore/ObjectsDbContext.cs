namespace Backroom.Functions.Objects.EntityFrameworkCore;

using Backroom.Functions.Objects.Models;
using Microsoft.EntityFrameworkCore;

public class ObjectsDbContext : DbContext
{
    public ObjectsDbContext(DbContextOptions<ObjectsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ObjectPropertyDbModel>().ToTable("UserProperties");
        modelBuilder.Entity<ObjectPropertyDbModel>().HasKey(x => x.Id);
        modelBuilder.Entity<ObjectPropertyDbModel>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ObjectPropertyDbModel>().Property(x => x.ObjectId).IsRequired().HasColumnName("UserId");
        modelBuilder.Entity<ObjectPropertyDbModel>().Property(x => x.Key).IsRequired().HasColumnName("Property");
    }

    public DbSet<ObjectPropertyDbModel>? ObjectProperties { get; set; }
}