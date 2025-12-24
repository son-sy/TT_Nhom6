using QuanLyNhanSu.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
	public partial class FormTrangChu : System.Windows.Forms.Form
	{
		public FormTrangChu()
		{
			InitializeComponent();
		}
		private void FormTrangChu_Load(object sender, EventArgs e)
		{
			// Ngay khi mở form, hệ thống sẽ kiểm tra quyền để ẩn,hiện nút
			PhanQuyenGiaoDien();
		}
		void PhanQuyenGiaoDien()
		{
			// Lấy quyền từ biến
			string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.Trim().ToLower() : "";
			btnTaiKhoan.Visible = false;
			btnNhanVien.Visible = false;
			btnLuong.Visible = false;
			btnChamCong.Visible = false;
			btnXemLuongCaNhan.Visible = true;
			btnNghiPhep.Visible = true;
			//Mở khóa chức năng theo từng vai trò cụ thể
			switch (quyen)
			{
				case "hr":
					// HR thấy toàn bộ các nút
					btnTaiKhoan.Visible = true;
					btnNhanVien.Visible = true;
					btnLuong.Visible = true;
					btnChamCong.Visible = true;
					break;

				case "pm":
					// PM: Chỉ quản lý nhân sự và chấm công. 
					// Không được thấy nút Lương tổng và Tài khoản hệ thống.
					btnNhanVien.Visible = true;
					btnChamCong.Visible = true;
					break;

				case "nhanvien":
				case "user":
					break;
			}
		}
		private void btnNhanVien_Click(object sender, EventArgs e)
		{
			// Khi đóng form thì hiện lại trang chủ
			FormNhanVien frm = new FormNhanVien();
			this.Hide();
			frm.ShowDialog();
			this.Show();
		}
		private void btnChamCong_Click(object sender, EventArgs e)
		{
			FormChamCong f = new FormChamCong();
			this.Hide(); f.ShowDialog(); this.Show();
		}
		private void btnLuong_Click(object sender, EventArgs e)
		{
			//Kiểm tra lại quyền
			string quyen = LuuTru.Quyen.ToLower();
			if (quyen == "pm" || quyen == "nhanvien")
			{
				MessageBox.Show("Bạn không có quyền truy cập bảng lương tổng!");
				return;
			}
			FormLuong f = new FormLuong();
			this.Hide(); f.ShowDialog(); this.Show();
		}
		private void btnTaiKhoan_Click(object sender, EventArgs e)
		{
			if (LuuTru.Quyen.ToLower() != "hr" && LuuTru.Quyen.ToLower() != "admin")
			{
				MessageBox.Show("Chỉ HR/Admin mới được quản lý tài khoản hệ thống!");
				return;
			}
			FormTK frm = new FormTK();
			this.Hide(); frm.ShowDialog(); this.Show();
		}
		//Ẩn nút Duyệt nếu là Nhân viên.
		//Hiện nút Duyệt nếu là PM/HR.
		private void btnNghiPhep_Click(object sender, EventArgs e)
		{
			FormNghiPhep frm = new FormNghiPhep();
			this.Hide();
			frm.ShowDialog();
			this.Show();
		}
		private void btnXemLuongCaNhan_Click(object sender, EventArgs e)
		{
			FormLuong f = new FormLuong();
			this.Hide(); f.ShowDialog(); this.Show();
		}
		private void btnDangXuat_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}

		private void btnDoiMatKhau_Click(object sender, EventArgs e)
		{
			FormDoiMatKhau f = new FormDoiMatKhau();
			f.ShowDialog();
		}
	}
}