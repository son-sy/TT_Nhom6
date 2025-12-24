using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanSu.Models
{
    [Table("ChamCong")]
    public partial class ChamCong
    {
        [Key]
        public int IdChamCong { get; set; }

        public int? IdNv { get; set; }

        // --- THÊM DẤU ? VÀO CÁC CỘT SỐ ĐỂ KHÁNG LỖI NULL ---
        public int? Ngay { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }
        public double? SoNgayCong { get; set; }
        // ----------------------------------------------------

        public string GhiChu { get; set; }

        [Column("checkin")]
        public string Checkin { get; set; }

        [Column("checkout")]
        public string Checkout { get; set; }

        [Column("trangThai")]
        public string TrangThai { get; set; }

        [ForeignKey("IdNv")]
        public virtual Nv NhanVien { get; set; }
    }
}