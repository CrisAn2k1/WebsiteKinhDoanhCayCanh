using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebsiteKinhDoanhCayCanh.Models
{
    public partial class MyDataEF : DbContext
    {
        public MyDataEF()
            : base("name=MyDataEF")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<CachChamSoc> CachChamSoc { get; set; }
        public virtual DbSet<CTCapNhat> CTCapNhat { get; set; }
        public virtual DbSet<CTDH> CTDH { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<HinhAnhSP> HinhAnhSP { get; set; }
        public virtual DbSet<NhomSP> NhomSP { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<ThongTinThemVeSP> ThongTinThemVeSP { get; set; }
        public virtual DbSet<UserVoucher> UserVoucher { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.trangThai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.id_SP)
                .IsUnicode(false);

            modelBuilder.Entity<CachChamSoc>()
                .Property(e => e.id_CCS)
                .IsUnicode(false);

            modelBuilder.Entity<CachChamSoc>()
                .Property(e => e.tuoiNuoc)
                .IsUnicode(false);

            modelBuilder.Entity<CachChamSoc>()
                .Property(e => e.dat)
                .IsUnicode(false);

            modelBuilder.Entity<CachChamSoc>()
                .Property(e => e.anhSang)
                .IsUnicode(false);

            modelBuilder.Entity<CachChamSoc>()
                .Property(e => e.viTriDatCay)
                .IsUnicode(false);

            modelBuilder.Entity<CachChamSoc>()
                .Property(e => e.duongChat)
                .IsUnicode(false);

            modelBuilder.Entity<CTCapNhat>()
                .Property(e => e.id_SP)
                .IsUnicode(false);

            modelBuilder.Entity<CTDH>()
                .Property(e => e.id_SP)
                .IsUnicode(false);

            modelBuilder.Entity<DanhGia>()
                .Property(e => e.trangThai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhGia>()
                .Property(e => e.id_SP)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.trangThaiThanhToan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.trangThaiGiaoHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.phuongThucThanhToan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.id_Voucher)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.CTDH)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HinhAnhSP>()
                .Property(e => e.duongDan)
                .IsUnicode(false);

            modelBuilder.Entity<HinhAnhSP>()
                .Property(e => e.id_SP)
                .IsUnicode(false);

            modelBuilder.Entity<NhomSP>()
                .Property(e => e.id_Nhom)
                .IsUnicode(false);

            modelBuilder.Entity<NhomSP>()
                .Property(e => e.id_CCS)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.id_SP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.id_Nhom)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTCapNhat)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTDH)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasOptional(e => e.ThongTinThemVeSP)
                .WithRequired(e => e.SanPham);

            modelBuilder.Entity<ThongTinThemVeSP>()
                .Property(e => e.id_SP)
                .IsUnicode(false);

            modelBuilder.Entity<UserVoucher>()
                .Property(e => e.id_voucher)
                .IsUnicode(false);

            modelBuilder.Entity<Voucher>()
                .Property(e => e.id_voucher)
                .IsUnicode(false);

            modelBuilder.Entity<Voucher>()
                .HasMany(e => e.UserVoucher)
                .WithRequired(e => e.Voucher)
                .WillCascadeOnDelete(false);
        }
    }
}
