using QuanLyNhanSu.Models;
using System;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class FormTrangChu : Form
    {
        public FormTrangChu()
        {
            InitializeComponent();
            // hiển thị đúng quyền người dùng truy cập
            PhanQuyenGiaoDien();
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
        }
        void PhanQuyenGiaoDien()
        {
            //Lưu secsion biến lưu trữ 
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.Trim().ToLower() : "";
            //Ẩn các chức năng chỉ hiển thị khi xác thực đối tượng là HR,PM hay nhân viên
            btnTaiKhoan.Visible = false;
            btnNhanVien.Visible = false;
            btnLuong.Visible = false;
            btnChamCong.Visible = false;

            // Các chức năng đối tượng nào cũng có quyền dùng
            btnXemLuongCaNhan.Visible = true;
            btnNghiPhep.Visible = true;
            btnDangXuat.Visible = true;
            btnDoiMatKhau.Visible = true;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            //HR có toàn quyền sử dụng
            if (quyen == "hr" || quyen == "admin")
            {
                btnTaiKhoan.Visible = true;
                btnNhanVien.Visible = true;
                btnLuong.Visible = true;
                btnChamCong.Visible = true;
                btnNhanVien.Text = "Quản lý Nhân viên";
                btnChamCong.Text = "Quản lý Chấm công";
                btnLuong.Text = "Quản lý Lương";
                btnNghiPhep.Text = "Quản lý Nghỉ phép";
                btnTaiKhoan.Text = "Quản lý Tài khoản";
                btnXemLuongCaNhan.Text = "Xem Lương Cá Nhân";
            }
            //PM chỉ có quyền trong phạm vi team
            else if (quyen == "pm")
            {
                btnNhanVien.Visible = true;
                btnChamCong.Visible = true;
                btnNhanVien.Text = "Nhân viên Team";
                btnChamCong.Text = "Chấm công Team";
                btnNghiPhep.Text = "Duyệt Phép Team";
                btnXemLuongCaNhan.Text = "Lương của tôi";
                btnDoiMatKhau.Text = "Đổi mật khẩu";
            }
            //Nhân viên chỉ có quyền trong phạm vi cá nhân 
            else
            {
                btnNhanVien.Visible = true;
                btnNhanVien.Text = "Hồ sơ cá nhân";
                btnChamCong.Visible = true;
                btnChamCong.Text = "Chấm công (Check-in)";
                btnNghiPhep.Text = "Xin nghỉ phép";
                btnXemLuongCaNhan.Text = "Phiếu lương của tôi";
                btnDoiMatKhau.Text = "Đổi mật khẩu";
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien frm = new FormNhanVien();
            this.Hide(); frm.ShowDialog(); this.Show();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            FormChamCong f = new FormChamCong();
            this.Hide(); f.ShowDialog(); this.Show();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            //Kiểm tra quyền lại lần 2 để tránh người dùng cố tình truy cập vào tính lương tổng
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.Trim().ToLower() : "";
            if (quyen == "pm" || quyen == "nhanvien" || quyen == "user")
            {
                MessageBox.Show("Bạn không có quyền truy cập bảng lương tổng!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormLuong f = new FormLuong();
            this.Hide(); f.ShowDialog(); this.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            //Ngăn chặn đối tượng PM,nhân viên không được truy cập vào quản lý tài khoản
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.Trim().ToLower() : "";
            if (quyen != "hr" && quyen != "admin")
            {
                MessageBox.Show("Chỉ HR/Admin mới được quản lý tài khoản hệ thống!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormTK frm = new FormTK();
            this.Hide(); frm.ShowDialog(); this.Show();
        }

        private void btnNghiPhep_Click(object sender, EventArgs e)
        {
            FormNghiPhep frm = new FormNghiPhep();
            this.Hide(); frm.ShowDialog(); this.Show();
        }

        private void btnXemLuongCaNhan_Click(object sender, EventArgs e)
        {
            if (LuuTru.IdNhanVien == null)
            {
                MessageBox.Show("Lỗi phiên làm việc: Không tìm thấy ID nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Truyền ID cá nhân để xem lương của mình
            FormLuong f = new FormLuong(LuuTru.IdNhanVien.Value);
            this.Hide(); f.ShowDialog(); this.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                //Xóa Session khi đăng xuất.
                LuuTru.Quyen = "";
                LuuTru.IdNhanVien = null;
                this.DialogResult = DialogResult.OK;
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