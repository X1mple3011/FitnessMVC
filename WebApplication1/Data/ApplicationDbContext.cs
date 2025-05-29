using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<PhanQuyen> PhanQuyens { get; set; }
        public DbSet<BaiTap> BaiTaps { get; set; }
        public DbSet<LoTrinh> LoTrinhs { get; set; }
        public DbSet<LoTrinh_BaiTap> LoTrinh_BaiTaps { get; set; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<LikeBaiViet> LikeBaiViets { get; set; }
        public DbSet<ChiSoBMI> ChiSoBMIs { get; set; }
        public DbSet<UserLoTrinh> UserLoTrinhs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .HasRequired(b => b.NguoiDung)
                .WithMany(n => n.BinhLuans)
                .HasForeignKey(b => b.IdNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LikeBaiViet>()
                .HasRequired(l => l.NguoiDung)
                .WithMany(n => n.LikeBaiViets)
                .HasForeignKey(l => l.IdNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiSoBMI>()
                .HasRequired(c => c.NguoiDung)
                .WithMany(n => n.ChiSoBMIs)
                .HasForeignKey(c => c.IdNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaiViet>()
                .HasRequired(b => b.NguoiDung)
                .WithMany(n => n.BaiViets)
                .HasForeignKey(b => b.IdNguoiDung)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}