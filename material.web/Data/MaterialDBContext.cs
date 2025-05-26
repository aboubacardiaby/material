using Material.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace material.web.Data
{
    public class MaterialDBContext:DbContext
    {
        public MaterialDBContext(DbContextOptions<MaterialDBContext> options) : base(options)
        {
        }
        public DbSet<MaterialEntity> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialEntity>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<MaterialEntity>()
                .Property(m => m.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<MaterialEntity>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<MaterialEntity>()
                .Property(m => m.Quantity)
                .IsRequired();
            modelBuilder.Entity<MaterialEntity>()
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<MaterialEntity>()
                .Property(m => m.UpdatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
