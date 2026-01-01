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
            //Kiểm tra tính hợp lệ của dữ liệu đầu vào
            //Ngăn chặn việc gửi dữ liệu rỗng xuống Database.
            if (string.IsNullOrEmpty(txtMatKhauCu.Text) ||
                string.IsNullOrEmpty(txtMatKhauMoi.Text) ||
                string.IsNullOrEmpty(txtNhapLai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            // Đảm bảo người dùng không gõ nhầm mật khẩu mới.
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu mới và Nhập lại không khớp!");
                return;
            }

            try
            {
                using (var db = new QuanLyNhanSuContext())
                {
                    // Không cho phép nhập tên đăng nhập, mà hệ thống tự lấy ID từ phiên đăng nhập
                    if (LuuTru.IdNhanVien == null)
                    {
                        MessageBox.Show("Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại!");
                        return;
                    }

                    var user = db.TKs.FirstOrDefault(t => t.IdNv == LuuTru.IdNhanVien);

                    if (user != null)
                    {
                        // Bắt buộc người dùng phải chứng minh mình là chủ sở hữu tài khoản trước khi đổi mới.
                        if (user.MKhauTk != txtMatKhauCu.Text)
                        {
                            MessageBox.Show("Mật khẩu cũ không đúng!");
                            return;
                        }
                        user.MKhauTk = txtMatKhauMoi.Text;
                        db.SaveChanges();
                        MessageBox.Show("Đổi mật khẩu thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản trong hệ thống!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}