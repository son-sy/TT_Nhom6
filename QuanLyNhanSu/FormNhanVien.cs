using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
    public partial class FormNhanVien : System.Windows.Forms.Form
    {
        QuanLyNhanSuContext db = new QuanLyNhanSuContext();

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
            PhanQuyenGiaoDien();
        }
        private void HienThiDuLieu()
        {
            try
            {
                db = new QuanLyNhanSuContext();
                var query = db.Nvs.AsQueryable();

                string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
                int myID = LuuTru.IdNhanVien ?? 0;

                if (quyen == "hr" || quyen == "admin")
                {
                    // HR Thấy toàn bộ nhân viên
                }
                else if (quyen == "pm")
                {
                    //PM chỉ thấy nhân viên thuộc Phòng ban mình quản lý
                    var pmInfo = db.Nvs.Find(myID);
                    if (pmInfo != null && !string.IsNullOrEmpty(pmInfo.PhongBan))
                    {
                        query = query.Where(nv => nv.PhongBan == pmInfo.PhongBan);
                    }
                    else
                    {
                        query = query.Where(nv => nv.IdNv == myID);
                    }
                }
                else
                {
                    // Nhân viên thường chỉ thấy bản thân
                    query = query.Where(nv => nv.IdNv == myID);
                }
                var danhSach = query.Select(nv => new
                {
                    MaNV = nv.IdNv,
                    HoTen = nv.NvTen,
                    GioiTinh = nv.GioiTinh,
                    NgaySinh = nv.NgaySinh,
                    DiaChi = nv.DiaChi,
                    SDT = nv.SDt,
                    Email = nv.Email,
                    PhongBan = nv.PhongBan,
                    ChucVu = nv.Chucvu,
                    LuongCoBan = nv.LuongCoBan
                }).ToList();
                dgvNhanVien.DataSource = danhSach;
                // Format hiển thị
                if (dgvNhanVien.Columns["LuongCoBan"] != null)
                {
                    dgvNhanVien.Columns["LuongCoBan"].DefaultCellStyle.Format = "N0";
                    dgvNhanVien.Columns["LuongCoBan"].HeaderText = "Lương CB";
                }
                if (dgvNhanVien.Columns["NgaySinh"] != null)
                    dgvNhanVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                if (dgvNhanVien.Columns["HoTen"] != null)
                    dgvNhanVien.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }
        void PhanQuyenGiaoDien()
        {
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
            // Mặc định ẩn các nút tác vụ
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            if (Controls.ContainsKey("btnXuatExcel")) Controls["btnXuatExcel"].Visible = false;
            MoKhoaNhapLieu(true);
            if (quyen == "hr" || quyen == "admin")
            {
                this.Text = "Quản lý Nhân sự";
                //Được thêm,sửa,xóa và nhìn thấy Lương
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
                if (Controls.ContainsKey("btnXuatExcel")) Controls["btnXuatExcel"].Visible = true;
                cboPhongBan.Enabled = true;
                cboChucVu.Enabled = true;
                txtLuongCoBan.Visible = true;
                if (Controls.ContainsKey("lblLuong")) Controls["lblLuong"].Visible = true;
            }
            else if (quyen == "pm")
            {
                this.Text = "Quản lý Team";
                // PM chỉ được Sửa thông tin cơ bản
                btnSua.Visible = true;
                if (Controls.ContainsKey("btnXuatExcel")) Controls["btnXuatExcel"].Visible = true;
                //Ẩn cột lương và ô nhập lương
                cboPhongBan.Enabled = false; // PM không được đổi phòng ban nhân viên
                cboChucVu.Enabled = false;   // PM không được thăng chức cho nhân viên (cần HR)
                txtLuongCoBan.Visible = false;
                if (Controls.ContainsKey("lblLuong")) Controls["lblLuong"].Visible = false;
                if (dgvNhanVien.Columns["LuongCoBan"] != null) dgvNhanVien.Columns["LuongCoBan"].Visible = false;
            }
            else
            {
                this.Text = "Hồ sơ cá nhân";
                btnSua.Visible = true; // Cho phép sửa thông tin liên hệ của chính mình

                cboPhongBan.Enabled = false;
                cboChucVu.Enabled = false;
                txtLuongCoBan.Visible = false;
                if (Controls.ContainsKey("lblLuong")) Controls["lblLuong"].Visible = false;
                if (dgvNhanVien.Columns["LuongCoBan"] != null) dgvNhanVien.Columns["LuongCoBan"].Visible = false;
            }
        }

        void MoKhoaNhapLieu(bool choPhep)
        {
            txtHoTen.ReadOnly = !choPhep;
            txtDiaChi.ReadOnly = !choPhep;
            txtSDT.ReadOnly = !choPhep;
            txtEmail.ReadOnly = !choPhep;
            dtpNgaySinh.Enabled = choPhep;
            rdoNam.Enabled = choPhep;
            rdoNu.Enabled = choPhep;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Chặn nếu không phải HR
            string quyen = LuuTru.Quyen.ToLower();
            if (quyen != "hr" && quyen != "admin") return;

            try
            {
                if (string.IsNullOrEmpty(txtHoTen.Text)) { MessageBox.Show("Vui lòng nhập họ tên!"); return; }

                Nv NhanVienMoi = new Nv();
                NhanVienMoi.NvTen = txtHoTen.Text;
                NhanVienMoi.DiaChi = txtDiaChi.Text;
                NhanVienMoi.SDt = txtSDT.Text;
                NhanVienMoi.Email = txtEmail.Text;
                NhanVienMoi.NgaySinh = dtpNgaySinh.Value;
                NhanVienMoi.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                NhanVienMoi.PhongBan = cboPhongBan.Text;
                NhanVienMoi.Chucvu = cboChucVu.Text;

                if (!string.IsNullOrEmpty(txtLuongCoBan.Text) && txtLuongCoBan.Visible)
                {
                    // Xử lý định dạng tiền tệ (bỏ dấu phẩy/chấm) trước khi lưu
                    string luongStr = txtLuongCoBan.Text.Replace(",", "").Replace(".", "").Trim();
                    if (decimal.TryParse(luongStr, out decimal luong)) NhanVienMoi.LuongCoBan = luong;
                }

                db.Nvs.Add(NhanVienMoi);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                HienThiDuLieu();
                ResetForm();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 0 && dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!"); return;
            }

            try
            {
                int idCanSua = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["MaNV"].Value);
                string quyen = LuuTru.Quyen.ToLower();

                //Nhân viên chỉ được sửa thông tin của chính mình
                if (quyen != "hr" && quyen != "admin" && quyen != "pm")
                {
                    if (idCanSua != LuuTru.IdNhanVien)
                    {
                        MessageBox.Show("Bạn chỉ được sửa thông tin của chính mình!"); return;
                    }
                }

                var nv = db.Nvs.Find(idCanSua);
                if (nv != null)
                {
                    // Cập nhật thông tin cơ bản
                    nv.NvTen = txtHoTen.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.SDt = txtSDT.Text;
                    nv.Email = txtEmail.Text;
                    nv.NgaySinh = dtpNgaySinh.Value;
                    nv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";

                    //Chỉ HR mới được quyền chỉnh sửa vào Lương và Chức vụ
                    if (quyen == "hr" || quyen == "admin")
                    {
                        nv.PhongBan = cboPhongBan.Text;
                        nv.Chucvu = cboChucVu.Text;
                        if (!string.IsNullOrEmpty(txtLuongCoBan.Text) && txtLuongCoBan.Visible)
                        {
                            string luongStr = txtLuongCoBan.Text.Replace(",", "").Replace(".", "").Trim();
                            if (decimal.TryParse(luongStr, out decimal luong)) nv.LuongCoBan = luong;
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    HienThiDuLieu();
                    ResetForm();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string quyen = LuuTru.Quyen.ToLower();
            if (quyen != "hr" && quyen != "admin") return;

            if (dgvNhanVien.SelectedRows.Count == 0 && dgvNhanVien.CurrentRow == null) return;
            try
            {
                int idCanXoa = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["MaNV"].Value);

                //Không cho xóa tài khoản HR
                var taiKhoanQuanTri = db.TKs.FirstOrDefault(t => t.IdNv == idCanXoa);
                if (taiKhoanQuanTri != null && (taiKhoanQuanTri.VaiTro.Trim().ToLower() == "hr" || taiKhoanQuanTri.VaiTro.Trim().ToLower() == "admin"))
                {
                    MessageBox.Show("Không thể xóa tài khoản Quản trị!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }

                if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var nv = db.Nvs.Find(idCanXoa);
                    if (nv != null)
                    {
                        //Xóa dữ liệu ở các bảng con trước để tránh lỗi ràng buộc khóa ngoại
                        var luong = db.Luongs.Where(l => l.IdNv == idCanXoa).ToList(); db.Luongs.RemoveRange(luong);
                        var cong = db.ChamCongs.Where(c => c.IdNv == idCanXoa).ToList(); db.ChamCongs.RemoveRange(cong);
                        var tk = db.TKs.Where(t => t.IdNv == idCanXoa).ToList(); db.TKs.RemoveRange(tk);

                        db.Nvs.Remove(nv);
                        db.SaveChanges();
                        MessageBox.Show("Đã xóa!"); HienThiDuLieu(); ResetForm();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dgvNhanVien.Rows[e.RowIndex];
                    txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                    txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                    txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                    txtEmail.Text = row.Cells["Email"].Value?.ToString();
                    string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                    if (gioiTinh == "Nam") rdoNam.Checked = true; else rdoNu.Checked = true;
                    if (row.Cells["NgaySinh"].Value != null) dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                    cboPhongBan.Text = row.Cells["PhongBan"].Value?.ToString();
                    cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString();
                    //Hiển thị lương lên TextBox nếu người dùng là HR
                    string quyen = LuuTru.Quyen.ToLower();
                    if ((quyen == "hr" || quyen == "admin") && row.Cells["LuongCoBan"].Value != null)
                    {
                        decimal luong = Convert.ToDecimal(row.Cells["LuongCoBan"].Value);
                        txtLuongCoBan.Text = luong.ToString("N0");
                    }
                }
                catch { }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count == 0) return;
            try
            {
                // Sử dụng thư viện Microsoft.Office.Interop.Excel để xuất báo cáo
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "DS_NhanVien";
                int colIndex = 1;
                for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
                {
                    if (dgvNhanVien.Columns[i].Visible)
                    {
                        worksheet.Cells[1, colIndex] = dgvNhanVien.Columns[i].HeaderText; colIndex++;
                    }
                }
                for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
                {
                    colIndex = 1;
                    for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
                    {
                        if (dgvNhanVien.Columns[j].Visible)
                        {
                            var value = dgvNhanVien.Rows[i].Cells[j].Value;
                            worksheet.Cells[i + 2, colIndex] = "'" + (value?.ToString() ?? ""); colIndex++;
                        }
                    }
                }
                worksheet.Columns.AutoFit();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Excel: " + ex.Message); }
        }
        private void ResetForm()
        {
            txtHoTen.Text = ""; txtDiaChi.Text = ""; txtSDT.Text = ""; txtEmail.Text = "";
            cboPhongBan.SelectedIndex = -1; cboChucVu.SelectedIndex = -1;
            if (txtLuongCoBan.Visible) txtLuongCoBan.Text = "";
            dtpNgaySinh.Value = DateTime.Now; rdoNam.Checked = true;
        }

        private void btnThoat_Click(object sender, EventArgs e) { this.Close(); }
    }
}