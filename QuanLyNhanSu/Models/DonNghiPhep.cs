using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanSu.Models
{
    [Table("DonNghiPhep")]
    public class DonNghiPhep
    {
        [Key]
        public int IdDon { get; set; }

        public int IdNv { get; set; }

        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string LyDo { get; set; }
        public string LoaiNghi { get; set; }
        public string TrangThai { get; set; }

        // --- SỬA LỖI 1: Thêm thuộc tính SoNgay ---
        // (Nếu DB lưu số ngày nghỉ là số nguyên thì dùng int, nếu có 0.5 ngày thì dùng double)
        public int? SoNgay { get; set; }

        // --- SỬA LỖI 2: Đổi tên thành IdNvNavigation để khớp với lỗi ---
        [ForeignKey("IdNv")]
        // Quan trọng: Chữ 'NhanVien' màu xanh bên dưới là Tên Class của bảng Nhân Viên. 
        // Nếu class đó tên là 'Nv' thì sửa lại thành 'public virtual Nv...'
        public virtual Nv IdNvNavigation { get; set; }
    }
}