using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu
{
    public partial class FormTK : Form
    {
        public FormTK()
        {
            InitializeComponent();
        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            //Kiểm tra quyền chỉ HR được truy cập form
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
            if (quyen != "hr" && quyen != "admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập trang này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            LoadComboBoxVaiTro();
            LoadComboBoxNhanVien();
            LoadDataTaiKhoan();
        }

        //Load danh sách nhân viên vào ComboBox để chọn
        void LoadComboBoxNhanVien()
        {
            try
            {
                using (var db = new QuanLyNhanSuContext())
                {
                    var listNV = db.Nvs.Select(x => new
                    {
                        x.IdNv,
                        HienThi = "[" + x.IdNv + "] - " + x.NvTen
                    }).ToList();

                    cboNhanVien.DataSource = listNV;
                    cboNhanVien.DisplayMember = "HienThi";
                    cboNhanVien.ValueMember = "IdNv";
                    cboNhanVien.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhân viên: " + ex.Message);
            }
        }

        void LoadComboBoxVaiTro()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("HR");
            cboVaiTro.Items.Add("PM");
            cboVaiTro.Items.Add("NhanVien");
            cboVaiTro.SelectedIndex = 2; //Mặc định vai trò luôn luôn là nhân viên
        }

        //Load dữ liệu lên GridView sử dụng LINQ Join 2 bảng (Tài khoản & Nhân viên)
        void LoadDataTaiKhoan()
        {
            try
            {
                using (var db = new QuanLyNhanSuContext())
                {
                    var query = from t in db.TKs
                                join n in db.Nvs on t.IdNv equals n.IdNv
                                select new
                                {
                                    TenTK = t.TenTk,
                                    MatKhau = t.MKhauTk,
                                    VaiTro = t.VaiTro,
                                    MaNV = t.IdNv,
                                    TenNV = n.NvTen
                                };

                    dgvTaiKhoan.DataSource = query.ToList();

                    if (dgvTaiKhoan.Columns.Count > 0)
                    {
                        dgvTaiKhoan.Columns["TenTK"].HeaderText = "Tên Đăng Nhập";
                        dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật Khẩu";
                        dgvTaiKhoan.Columns["VaiTro"].HeaderText = "Quyền Hạn";
                        dgvTaiKhoan.Columns["MaNV"].Visible = true;
                        dgvTaiKhoan.Columns["MaNV"].HeaderText = "ID Gốc";
                        dgvTaiKhoan.Columns["TenNV"].HeaderText = "Chủ Tài Khoản";
                        dgvTaiKhoan.Columns["TenNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtTenTK.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!"); return;
            }
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn nhân viên!"); return;
            }

            int idNvChon = Convert.ToInt32(cboNhanVien.SelectedValue);
            string tenHienThi = cboNhanVien.Text;

            //Xác nhận lại trước khi tạo tài khoản quan trọng
            DialogResult check = MessageBox.Show(
                $"Bạn đang chọn: {tenHienThi}\nID: {idNvChon}\nXác nhận tạo tài khoản?",
                "XÁC NHẬN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (check == DialogResult.Cancel) return;

            using (var db = new QuanLyNhanSuContext())
            {
                //Kiểm tra trùng khóa chính (Username)
                if (db.TKs.Find(txtTenTK.Text.Trim()) != null)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại!"); return;
                }

                //1 Nhân viên chỉ có 1 Tài khoản
                var existingAcc = db.TKs.FirstOrDefault(x => x.IdNv == idNvChon);
                if (existingAcc != null)
                {
                    MessageBox.Show($"Nhân viên này đã có tài khoản: {existingAcc.TenTk}");
                    return;
                }

                try
                {
                    TK newItem = new TK();
                    newItem.TenTk = txtTenTK.Text.Trim();
                    newItem.MKhauTk = txtMatKhau.Text.Trim();
                    newItem.VaiTro = cboVaiTro.Text;
                    newItem.IdNv = idNvChon;

                    db.TKs.Add(newItem);
                    db.SaveChanges();

                    MessageBox.Show($"Đã thêm tài khoản thành công!");
                    LoadDataTaiKhoan();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!"); return;
            }

            using (var db = new QuanLyNhanSuContext())
            {
                var tk = db.TKs.Find(txtTenTK.Text);
                if (tk == null) { MessageBox.Show("Tài khoản không tồn tại!"); return; }

                //Ngăn chặn xoá tài khoản HR
                if (tk.VaiTro.Trim().ToUpper() == "HR" || tk.VaiTro.Trim().ToUpper() == "ADMIN")
                {
                    MessageBox.Show("Không thể xóa tài khoản Quản trị (HR/Admin)!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Xóa tài khoản [{tk.TenTk}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.TKs.Remove(tk);
                    db.SaveChanges();
                    MessageBox.Show("Đã xóa thành công!");
                    LoadDataTaiKhoan();
                    ResetForm();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!"); return;
            }

            using (var db = new QuanLyNhanSuContext())
            {
                var tk = db.TKs.Find(txtTenTK.Text);
                if (tk != null)
                {
                    tk.MKhauTk = txtMatKhau.Text;
                    tk.VaiTro = cboVaiTro.Text;
                    //Không cho sửa ID Nhân viên

                    db.SaveChanges();
                    MessageBox.Show("Đã cập nhật Mật khẩu & Quyền hạn!");
                    LoadDataTaiKhoan();
                    ResetForm();
                }
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dgvTaiKhoan.Rows[e.RowIndex];
                    txtTenTK.Text = row.Cells["TenTK"].Value?.ToString();
                    txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
                    cboVaiTro.Text = row.Cells["VaiTro"].Value?.ToString();

                    if (row.Cells["MaNV"].Value != null)
                        cboNhanVien.SelectedValue = Convert.ToInt32(row.Cells["MaNV"].Value);

                    // [UX] Khóa các trường định danh (Username, ID NV) khi đang ở chế độ xem/sửa
                    txtTenTK.Enabled = false;
                    cboNhanVien.Enabled = false;
                }
                catch { }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // [Tối ưu code] Hàm Reset trạng thái form về mặc định để chuẩn bị nhập mới
        void ResetForm()
        {
            txtTenTK.Text = ""; txtMatKhau.Text = "";
            txtTenTK.Enabled = true; // Mở lại để nhập mới
            cboNhanVien.Enabled = true; // Mở lại để chọn nhân viên khác
            if (cboNhanVien.Items.Count > 0) cboNhanVien.SelectedIndex = -1;
            cboVaiTro.SelectedIndex = 2;
        }
    }
}