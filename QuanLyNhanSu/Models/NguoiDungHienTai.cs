using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public static class NguoiDungHienTai
    {
        public static int IdNV { get; set; }
        public static string TenTK { get; set; }
        public static string VaiTro { get; set; } // Ví dụ: "Admin" hoặc "NhanVien"

        // Hàm reset khi đăng xuất
        public static void DangXuat()
        {
            IdNV = 0;
            TenTK = "";
            VaiTro = "";
        }
    }
}
