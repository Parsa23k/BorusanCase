using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BorusanCase.Models
{
    public partial class BorusanCaseContext : DbContext
    {
        public BorusanCaseContext()
        {
        }

        public BorusanCaseContext(DbContextOptions<BorusanCaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatus { get; set; } = null!;
        public virtual DbSet<PiecesType> PiecesType { get; set; } = null!;
        public virtual DbSet<WeightType> WeightType { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BorusanCase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.ArrivalAddress).HasMaxLength(1000);

                entity.Property(e => e.DepartureAddress).HasMaxLength(1000);

                entity.Property(e => e.ItemCode).HasMaxLength(500);

                entity.Property(e => e.ItemName).HasMaxLength(1000);

                entity.Property(e => e.Not).HasMaxLength(1000);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderStatus");

                entity.HasOne(d => d.PiecesType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PiecesTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PiecesType");

                entity.HasOne(d => d.WeightType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WeightTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_WeightType");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.Code).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<PiecesType>(entity =>
            {
                entity.ToTable("PiecesType");

                entity.Property(e => e.Code).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<WeightType>(entity =>
            {
                entity.ToTable("WeightType");

                entity.Property(e => e.Code).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}