using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class ZeroHungerDbContext : DbContext
{
    public ZeroHungerDbContext()
    {
    }

    public ZeroHungerDbContext(DbContextOptions<ZeroHungerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CollectionRequest> CollectionRequests { get; set; }

    public virtual DbSet<Distribution> Distributions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectionRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("CollectionRequest");

            entity.Property(e => e.CollectionTime).HasColumnType("datetime");
            entity.Property(e => e.EId).HasColumnName("E_id");
            entity.Property(e => e.FoodDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PreserveUntil).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RId).HasColumnName("R_id");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EIdNavigation).WithMany(p => p.CollectionRequests)
                .HasForeignKey(d => d.EId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectionRequest_Employee");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.CollectionRequests)
                .HasForeignKey(d => d.RId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectionRequest_Restaurant");
        });

        modelBuilder.Entity<Distribution>(entity =>
        {
            entity.HasKey(e => e.DId);

            entity.ToTable("Distribution");

            entity.Property(e => e.DId).HasColumnName("D_id");
            entity.Property(e => e.DistributionDate).HasColumnType("datetime");
            entity.Property(e => e.EId).HasColumnName("E_id");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuantityDistributed).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.EIdNavigation).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.EId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_Employee");

            entity.HasOne(d => d.Request).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_CollectionRequest");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EId);

            entity.ToTable("Employee");

            entity.Property(e => e.EId).HasColumnName("E_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ename)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RId);

            entity.ToTable("Restaurant");

            entity.Property(e => e.RId).HasColumnName("R_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PersonContacted)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
