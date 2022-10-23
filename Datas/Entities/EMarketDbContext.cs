using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mendata.Net.Datas.Entities
{
    public partial class EMarketDbContext : DbContext
    {
        public EMarketDbContext()
        {
        }

        public EMarketDbContext(DbContextOptions<EMarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Pembeli> Pembelis { get; set; }
        public virtual DbSet<Penjual> Penjuals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost; Port=5433; Database=EMarketDb; User Id=postgres; Password=1234567;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasIndex(e => e.IdPenjual, "IX_Barangs_IdPenjual");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Kode).HasMaxLength(10);

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdPenjualNavigation)
                    .WithMany(p => p.Barangs)
                    .HasForeignKey(d => d.IdPenjual);
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasIndex(e => e.IdUser, "IX_Pembelis_IdUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Pembelis)
                    .HasForeignKey(d => d.IdUser);
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasIndex(e => e.IdUser, "IX_Penjuals_IdUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Penjuals)
                    .HasForeignKey(d => d.IdUser);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}