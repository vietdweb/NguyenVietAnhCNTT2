using BVN9_BTTL2.Models;
using Microsoft.EntityFrameworkCore;

namespace BVN9_BTTL2.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(x => x.Name).IsUnique();
            entity.Property(x => x.Status).HasDefaultValue((byte)1);
            entity.Property(x => x.CreatedDate).HasDefaultValueSql("CONVERT(date, GETDATE())");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(x => x.Name).IsUnique();
            entity.Property(x => x.Price).HasDefaultValue(0);
            entity.Property(x => x.SalePrice).HasDefaultValue(0);
            entity.Property(x => x.Status).HasDefaultValue((byte)1);
            entity.Property(x => x.CreatedDate).HasDefaultValueSql("CONVERT(date, GETDATE())");
            entity.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasIndex(x => x.Name).IsUnique();
            entity.Property(x => x.Status).HasDefaultValue((byte)1);
            entity.Property(x => x.Priority).HasDefaultValue(0);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasIndex(x => x.Name).IsUnique();
            entity.Property(x => x.Status).HasDefaultValue((byte)1);
            entity.Property(x => x.CreatedDate).HasDefaultValueSql("CONVERT(date, GETDATE())");
        });
    }
}
