using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu
{
	public partial class FormDoiMatKhau : Form
	{
		public FormDoiMatKhau()
		{
			InitializeComponent();
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			//Kiểm tra nhập liệu
			if (string.IsNullOrEmpty(txtMatKhauCu.Text) ||
				string.IsNullOrEmpty(txtMatKhauMoi.Text) ||
				string.IsNullOrEmpty(txtNhapLai.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
				return;
			}

			if (txtMatKhauMoi.Text != txtNhapLai.Text)
			{
				MessageBox.Show("Mật khẩu mới và Nhập lại không khớp!");
				return;
			}

			try
			{
				using (var db = new QuanLyNhanSuContext())
				{
					// 2. Tìm tài khoản đang đăng nhập

					var user = db.TKs.FirstOrDefault(t => t.IdNv == LuuTru.IdNhanVien);

					if (user != null)
					{
						// Kiểm tra mật khẩu cũ
						if (user.MKhauTk != txtMatKhauCu.Text)
						{
							MessageBox.Show("Mật khẩu cũ không đúng!");
							return;
						}

						//Cập nhật mật khẩu mới
						user.MKhauTk = txtMatKhauMoi.Text;
						db.SaveChanges();

						MessageBox.Show("Đổi mật khẩu thành công!");
						this.Close();
					}
					else
					{
						MessageBox.Show("Không tìm thấy tài khoản!");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}