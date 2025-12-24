using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanSu.Models
{
    [Table("Luong")]
    public partial class Luong
    {
        [Key]
        public int IdLuong { get; set; }

        public int IdNv { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal? LuongCoBan { get; set; }
        public double? SoNgayCong { get; set; }
        public decimal? PhuCap { get; set; }
        public decimal? Thuong { get; set; }
        public decimal? KyLuat { get; set; }
        public decimal? TongLuong { get; set; }

        // SỬA LẠI DÒNG NÀY:
        public string? GhiChu { get; set; }

        [ForeignKey("IdNv")]
        public virtual Nv NhanVien { get; set; }
    }
}