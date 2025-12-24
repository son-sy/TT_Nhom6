using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanSu.Models;

public partial class QuanLyNhanSuContext : DbContext
{
    public QuanLyNhanSuContext()
    {
    }

    public QuanLyNhanSuContext(DbContextOptions<QuanLyNhanSuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChamCong> ChamCongs { get; set; }
    public virtual DbSet<DonNghiPhep> DonNghiPheps { get; set; }
    public virtual DbSet<Luong> Luongs { get; set; }
    public virtual DbSet<Nv> Nvs { get; set; }
    public virtual DbSet<TK> TKs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-E1BGTADO;Database=QuanLyNhanSu;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChamCong>(entity =>
        {
            entity.HasKey(e => e.IdChamCong);
            entity.ToTable("chamCong");

            entity.Property(e => e.IdChamCong).HasColumnName("idChamCong");
            entity.Property(e => e.IdNv).HasColumnName("idNV");
            entity.Property(e => e.Thang).HasColumnName("thang");
            entity.Property(e => e.Nam).HasColumnName("nam");
            entity.Property(e => e.SoNgayCong).HasColumnName("soNgayCong"); // Float
            entity.Property(e => e.GhiChu).HasMaxLength(255).HasColumnName("ghiChu");

            entity.HasOne(d => d.NhanVien)
                .WithMany(p => p.ChamCongs)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChamCong_NV");
        });

        modelBuilder.Entity<DonNghiPhep>(entity =>
        {
            entity.HasKey(e => e.IdDon);
            entity.ToTable("donNghiPhep");

            entity.Property(e => e.IdDon).HasColumnName("idDon");
            entity.Property(e => e.IdNv).HasColumnName("idNV");
            entity.Property(e => e.NgayBatDau).HasColumnType("date").HasColumnName("ngayBatDau");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date").HasColumnName("ngayKetThuc");
            entity.Property(e => e.SoNgay).HasColumnName("soNgay");
            entity.Property(e => e.LoaiNghi).HasMaxLength(50).HasColumnName("loaiNghi");
            entity.Property(e => e.LyDo).HasMaxLength(255).HasColumnName("lyDo");
            entity.Property(e => e.TrangThai).HasMaxLength(50).HasColumnName("trangThai");

            entity.HasOne(d => d.IdNvNavigation)
                .WithMany(p => p.DonNghiPheps)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DonNghiPhep_NV");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.IdLuong);
            entity.ToTable("luong");

            entity.Property(e => e.IdLuong).HasColumnName("idLuong");
            entity.Property(e => e.IdNv).HasColumnName("idNV");
            entity.Property(e => e.Thang).HasColumnName("thang");
            entity.Property(e => e.Nam).HasColumnName("nam");
            entity.Property(e => e.SoNgayCong).HasColumnName("soNgayCong");

            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 0)").HasColumnName("luongCoBan");
            entity.Property(e => e.PhuCap).HasColumnType("decimal(18, 0)").HasColumnName("phuCap");
            entity.Property(e => e.Thuong).HasColumnType("decimal(18, 0)").HasColumnName("thuong");
            entity.Property(e => e.KyLuat).HasColumnType("decimal(18, 0)").HasColumnName("kyLuat");
            entity.Property(e => e.TongLuong).HasColumnType("decimal(18, 0)").HasColumnName("tongLuong");
            entity.Property(e => e.GhiChu).HasMaxLength(255).HasColumnName("ghiChu");

            entity.HasOne(d => d.NhanVien)
                .WithMany(p => p.Luongs)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Luong_NV");
        });

        modelBuilder.Entity<Nv>(entity =>
        {
            entity.HasKey(e => e.IdNv);
            entity.ToTable("NV");

            entity.Property(e => e.IdNv).HasColumnName("idNV");
            entity.Property(e => e.NvTen).HasMaxLength(100).HasColumnName("nvTen");
            entity.Property(e => e.NgaySinh).HasColumnType("date").HasColumnName("ngaySinh");
            entity.Property(e => e.GioiTinh).HasMaxLength(10).HasColumnName("gioiTinh");
            entity.Property(e => e.DiaChi).HasMaxLength(200).HasColumnName("diaChi");
            entity.Property(e => e.SDt).HasMaxLength(15).HasColumnName("sDT");
            entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(e => e.Chucvu).HasMaxLength(50).HasColumnName("chucvu");
            entity.Property(e => e.PhongBan).HasMaxLength(50).HasColumnName("phongBan");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 0)").HasColumnName("luongCoBan");
        });

        modelBuilder.Entity<TK>(entity =>
        {
            entity.HasKey(e => e.TenTk);
            entity.ToTable("TK");

            entity.Property(e => e.TenTk).HasMaxLength(50).HasColumnName("tenTK");
            entity.Property(e => e.IdNv).HasColumnName("idNV");
            entity.Property(e => e.MKhauTk).HasMaxLength(255).HasColumnName("mKhauTK");
            entity.Property(e => e.VaiTro).HasMaxLength(50).HasColumnName("vaiTro");

            entity.HasOne(d => d.IdNvNavigation)
                .WithMany(p => p.Tks)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TK_NV");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}