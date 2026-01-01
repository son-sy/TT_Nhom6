using QuanLyNhanSu.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class FormDangNhap : System.Windows.Forms.Form
    {
        //Khởi tạo Context để kết nối CSDL qua Entity Framework
        QuanLyNhanSuContext db = new QuanLyNhanSuContext();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            //ẩn ký tự mật khẩu thành dấu chấm tròn
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;

            //Truy vấn cơ sở dữ liệu để tìm tài khoản khớp trả về null nếu không tìm thấy.
            var user = db.TKs.FirstOrDefault(u => u.TenTk == tk && u.MKhauTk == mk);

            if (user != null)
            {
                // Lưu Session
                LuuTru.Quyen = user.VaiTro;     // Lưu quyền 
                LuuTru.IdNhanVien = user.IdNv;  // Lưu ID để truy xuất dữ liệu cá nhân

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ẩn form đăng nhập đi để chuyển sang Form chính
                this.Hide();
                FormTrangChu main = new FormTrangChu();

                // Dùng ShowDialog để chương trình dừng tại đây chờ Form chính xử lý
                DialogResult ketQua = main.ShowDialog();

                //Xử lý kết quả trả về từ FormTrangChu
                if (ketQua == DialogResult.OK)
                {
                    // Nếu bấm Đăng xuất: Hiện lại form này và xóa mật khẩu
                    this.Show();
                    txtMatKhau.Text = "";
                    txtTaiKhoan.Focus();
                }
                else
                {
                    // Nếu bấm dấu X (Thoát) ở form chính: Đóng toàn bộ ứng dụng
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
            //Cho phép người dùng xem mật khẩu khi cần
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false; // Hiện chữ thường
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;  // Hiện ký tự mật khẩu
            }
        }
    }
}