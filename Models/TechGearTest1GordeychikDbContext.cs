using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TechGear_WpfApp_Test1.Models;

public partial class TechGearTest1GordeychikDbContext : DbContext
{
    public TechGearTest1GordeychikDbContext()
    {
    }

    public TechGearTest1GordeychikDbContext(DbContextOptions<TechGearTest1GordeychikDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=STEPAN\\SQLEXPRESS;Database=TechGear_Test1_Gordeychik_db;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.ProductMaterialId);

            entity.ToTable("MaterialType");

            entity.Property(e => e.PercentDamage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProductMaterialName).HasMaxLength(50);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.Property(e => e.Inn)
                .HasMaxLength(50)
                .HasColumnName("INN");
            entity.Property(e => e.PartnerAddress).HasMaxLength(150);
            entity.Property(e => e.PartnerCeo).HasMaxLength(100);
            entity.Property(e => e.PartnerEmail).HasMaxLength(50);
            entity.Property(e => e.PartnerName).HasMaxLength(50);
            entity.Property(e => e.PartnerPhone).HasMaxLength(50);

            entity.HasOne(d => d.PartnerType).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnerTypeId)
                .HasConstraintName("FK_Partners_PartnerType");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_PartnerProducts_Partners");

            entity.HasOne(d => d.Product).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PartnerProducts_Products");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.ToTable("PartnerType");

            entity.Property(e => e.PartnerTypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Articul).HasMaxLength(50);
            entity.Property(e => e.MinimumPrice).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.ProductMaterial).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductMaterialId)
                .HasConstraintName("FK_Products_MaterialType");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK_Products_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.Coefficient).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProductTypeName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
