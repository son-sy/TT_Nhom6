using QuanLyNhanSu.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
	public partial class FormDangNhap : System.Windows.Forms.Form
	{
		// Khởi tạo kết nối cơ sở dữ liệu
		QuanLyNhanSuContext db = new QuanLyNhanSuContext();

		public FormDangNhap()
		{
			InitializeComponent();
		}

		private void FormTrangChu_Load(object sender, EventArgs e)
		{
			//Ẩn ký tự mật khẩu khi mở form
			txtMatKhau.UseSystemPasswordChar = true;
		}

		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			string tk = txtTaiKhoan.Text;
			string mk = txtMatKhau.Text;

			// Kiểm tra trong DB xem có tài khoản nào khớp user và pass không
			var user = db.TKs.FirstOrDefault(u => u.TenTk == tk && u.MKhauTk == mk);

			if (user != null)
			{
				// 1. Lưu thông tin phiên đăng nhập (Session) để dùng cho các Form khác
				LuuTru.Quyen = user.VaiTro;
				LuuTru.IdNhanVien = user.IdNv;

				MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// 2. Ẩn form đăng nhập và mở form Trang chủ
				this.Hide();
				FormTrangChu main = new FormTrangChu();

				// ShowDialog để đợi kết quả trả về khi user đóng form Trang chủ
				DialogResult ketQua = main.ShowDialog();

				// 3. Xử lý khi đóng Form Trang chủ
				if (ketQua == DialogResult.OK)
				{
					// Nếu user bấm đăng xuất quay lại form đăng nhập, xóa mật khẩu cũ
					this.Show();
					txtMatKhau.Text = "";
					txtTaiKhoan.Focus();
				}
				else
				{
					// Nếu user thoát chương trình thì đóng form
					this.Close();
				}
			}
			else
			{
				MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
		{
			if (chkHienMatKhau.Checked)
			{
				txtMatKhau.UseSystemPasswordChar = false; // Hiện chữ
			}
			else
			{
				txtMatKhau.UseSystemPasswordChar = true;  // Hiện dấu chấm
			}
		}
	}
}