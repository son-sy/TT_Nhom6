using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
    public partial class FormLuong : Form
    {
        QuanLyNhanSuContext db = new QuanLyNhanSuContext();
        // Biến dùng để nhận diện ngữ cảnh sử dụng Form
        // Nếu biến này có giá trị, Đang xem lương cá nhân.
        // Nếu null,Đang quản lý lương tổng
        private int? _idNhanVienCaNhan = null;

        public FormLuong()
        {
            InitializeComponent();
        }
        public FormLuong(int idNhanVien)
        {
            InitializeComponent();
            this._idNhanVienCaNhan = idNhanVien;
        }

        private void FormLuong_Load(object sender, EventArgs e)
        {
            dtpThangNam.Format = DateTimePickerFormat.Custom;
            dtpThangNam.CustomFormat = "MM/yyyy";
            dtpThangNam.ShowUpDown = true;

            PhanQuyenGiaoDien();
            LoadDataLuong();
        }
        // Ẩn/Hiện nút tính năng dựa trên vai trò người dùng để bảo vệ dữ liệu
        void PhanQuyenGiaoDien()
        {
            //Xem lương cá nhân
            if (_idNhanVienCaNhan != null)
            {
                //Nhân viên không được tự tính lương hay sửa lương của mình
                btnTinhLuong.Visible = false;
                btnDieuChinh.Visible = false;
                if (Controls.ContainsKey("btnXoa")) Controls["btnXoa"].Visible = false;
                // Khóa toàn bộ ô nhập liệu
                txtPhuCap.Enabled = false;
                txtThuong.Enabled = false;
                txtKyLuat.Enabled = false;
                txtGhiChu.Enabled = false;
                // Cho phép nhân viên xuất phiếu lương ra Excel
                if (Controls.ContainsKey("btnXuatExcel")) Controls["btnXuatExcel"].Visible = true;
                return;
            }
            //Quản lý lương
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";

            if (quyen == "hr" || quyen == "admin")
            {
                btnTinhLuong.Visible = true;
                btnDieuChinh.Visible = true;
                txtPhuCap.Enabled = true;
                txtThuong.Enabled = true;
                txtKyLuat.Enabled = true;
                txtGhiChu.Enabled = true;
            }
            else
            {
                //Pm không được vào tính lương tổng
                btnTinhLuong.Visible = false;
                btnDieuChinh.Visible = false;
                txtPhuCap.Enabled = false;
                txtThuong.Enabled = false;
                txtKyLuat.Enabled = false;
                txtGhiChu.Enabled = false;
            }
            if (Controls.ContainsKey("btnXuatExcel")) Controls["btnXuatExcel"].Visible = true;
        }

        //Tải dữ liệu có điều kiện lọc
        void LoadDataLuong()
        {
            int thang = dtpThangNam.Value.Month;
            int nam = dtpThangNam.Value.Year;

            try
            {
                db = new QuanLyNhanSuContext(); // Reset context để lấy data mới nhất
                dgvLuong.AutoGenerateColumns = true;

                //lấy thông tin Nhân viên kèm theo Bảng lương
                var query = db.Luongs
                    .Include(l => l.NhanVien)
                    .Where(l => l.Thang == thang && l.Nam == nam);
                if (_idNhanVienCaNhan != null)
                {
                    // Chỉ lấy đúng dòng lương của người đang đăng nhập
                    query = query.Where(l => l.IdNv == _idNhanVienCaNhan.Value);
                }
                else
                {
                    string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
                    if (quyen != "hr" && quyen != "admin")
                    {
                        int idCuaToi = LuuTru.IdNhanVien ?? -1;
                        query = query.Where(l => l.IdNv == idCuaToi);
                    }
                }

                var list = query.Select(l => new
                {
                    ID = l.IdLuong,
                    MaNV = l.IdNv,
                    TenNV = (l.NhanVien != null) ? l.NhanVien.NvTen : "NV (" + l.IdNv + ")",
                    LuongCung = l.LuongCoBan ?? 0,
                    NgayCong = l.SoNgayCong ?? 0,
                    PhuCap = l.PhuCap ?? 0,
                    Thuong = l.Thuong ?? 0,
                    Phat = l.KyLuat ?? 0,
                    ThucLinh = l.TongLuong ?? 0,
                    GhiChu = l.GhiChu
                }).ToList();

                dgvLuong.DataSource = list;
                FormatBangLuong();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi hiển thị: " + ex.Message); }
        }

        void FormatBangLuong()
        {
            if (dgvLuong.Columns.Count == 0) return;
            if (dgvLuong.Columns["ID"] != null) dgvLuong.Columns["ID"].Visible = false;

            dgvLuong.Columns["MaNV"].HeaderText = "Mã NV";
            dgvLuong.Columns["TenNV"].HeaderText = "Họ Tên";
            dgvLuong.Columns["LuongCung"].HeaderText = "Lương CB";
            dgvLuong.Columns["NgayCong"].HeaderText = "Công";
            dgvLuong.Columns["PhuCap"].HeaderText = "Phụ Cấp";
            dgvLuong.Columns["Thuong"].HeaderText = "Thưởng";
            dgvLuong.Columns["Phat"].HeaderText = "Kỷ Luật";
            dgvLuong.Columns["ThucLinh"].HeaderText = "Thực Lĩnh";
            dgvLuong.Columns["GhiChu"].HeaderText = "Ghi Chú";
            // Định dạng số tiền có dấu phẩy
            foreach (DataGridViewColumn col in dgvLuong.Columns)
            {
                if (col.Name == "LuongCung" || col.Name == "PhuCap" ||
                    col.Name == "Thuong" || col.Name == "Phat" || col.Name == "ThucLinh")
                {
                    col.DefaultCellStyle.Format = "N0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            if (dgvLuong.Columns["TenNV"] != null) dgvLuong.Columns["TenNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dgvLuong.Rows[e.RowIndex];
                    txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                    txtTenNV.Text = row.Cells["TenNV"].Value?.ToString();
                    //Format lại hiển thị trên TextBox khi click
                    txtLuongCoBan.Text = string.Format("{0:N0}", row.Cells["LuongCung"].Value);
                    txtNgayCong.Text = row.Cells["NgayCong"].Value?.ToString();
                    txtPhuCap.Text = string.Format("{0:N0}", row.Cells["PhuCap"].Value);
                    txtThuong.Text = string.Format("{0:N0}", row.Cells["Thuong"].Value);
                    txtKyLuat.Text = string.Format("{0:N0}", row.Cells["Phat"].Value);
                    txtTongLuong.Text = string.Format("{0:N0}", row.Cells["ThucLinh"].Value);
                    txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
                }
                catch { }
            }
        }

        //Tính Lương Tự động
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
            if (quyen != "hr" && quyen != "admin")
            {
                MessageBox.Show("Bạn không có quyền tính lương!"); return;
            }

            int thang = dtpThangNam.Value.Month;
            int nam = dtpThangNam.Value.Year;

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn tính lương cho tháng {thang}/{nam}?\nLưu ý: Dữ liệu cũ sẽ được cập nhật lại theo chấm công mới.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            try
            {
                var dsNhanVien = db.Nvs.ToList();
                int count = 0;

                foreach (var nv in dsNhanVien)
                {
                    // Tổng hợp công: Dùng hàm SUM để cộng dồn tất cả các ngày công trong tháng
                    double soNgayCong = db.ChamCongs
                        .Where(cc => cc.IdNv == nv.IdNv && cc.Thang == thang && cc.Nam == nam)
                        .Sum(cc => (double?)cc.SoNgayCong) ?? 0;

                    decimal luongCB = nv.LuongCoBan ?? 0;

                    // Kiểm tra xem đã có dòng lương tháng
                    var bangLuong = db.Luongs.FirstOrDefault(l => l.IdNv == nv.IdNv && l.Thang == thang && l.Nam == nam);

                    if (bangLuong == null)
                    {
                        bangLuong = new Luong();
                        bangLuong.IdNv = nv.IdNv;
                        bangLuong.Thang = thang;
                        bangLuong.Nam = nam;
                        // Khởi tạo các khoản phụ mặc định
                        bangLuong.PhuCap = 0;
                        bangLuong.Thuong = 0;
                        bangLuong.KyLuat = 0;
                        db.Luongs.Add(bangLuong);
                    }
                    bangLuong.LuongCoBan = luongCB;
                    bangLuong.SoNgayCong = soNgayCong;
                    //Công thức tính lương cơ bản: (Lương cứng / 26 ngày chuẩn) * Số ngày làm thực tế
                    decimal luongTheoNgay = 0;
                    if (luongCB > 0)
                        luongTheoNgay = (luongCB / 26) * (decimal)soNgayCong;
                    // Công thức lương thực lĩnh (NET)
                    bangLuong.TongLuong = Math.Round(
                        luongTheoNgay + (bangLuong.PhuCap ?? 0) + (bangLuong.Thuong ?? 0) - (bangLuong.KyLuat ?? 0), 0);

                    count++;
                }

                db.SaveChanges();
                MessageBox.Show($"Đã tính xong lương cho {count} nhân viên!", "Thành công");
                LoadDataLuong();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        // Điều chỉnh lương thủ công
        // Dùng cho các trường hợp thưởng nóng, phạt vi phạm nội quy
        private void btnDieuChinh_Click(object sender, EventArgs e)
        {
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
            if (quyen != "hr" && quyen != "admin") return;

            if (string.IsNullOrEmpty(txtMaNV.Text)) return;
            if (!int.TryParse(txtMaNV.Text, out int idNv)) return;

            int thang = dtpThangNam.Value.Month;
            int nam = dtpThangNam.Value.Year;

            try
            {
                var item = db.Luongs.FirstOrDefault(l => l.IdNv == idNv && l.Thang == thang && l.Nam == nam);
                if (item != null)
                {
                    // Hàm local function để parse tiền tệ an toàn (loại bỏ ký tự lạ)
                    decimal ParseTien(string s)
                    {
                        if (string.IsNullOrEmpty(s)) return 0;
                        string clean = new string(s.Where(c => char.IsDigit(c) || c == '-').ToArray());
                        return decimal.TryParse(clean, out decimal res) ? res : 0;
                    }

                    item.PhuCap = ParseTien(txtPhuCap.Text);
                    item.Thuong = ParseTien(txtThuong.Text);
                    item.KyLuat = ParseTien(txtKyLuat.Text);
                    item.GhiChu = txtGhiChu.Text;

                    // Tính lại tổng lương sau khi điều chỉnh
                    decimal luongCB = item.LuongCoBan ?? 0;
                    double ngayCong = item.SoNgayCong ?? 0;
                    decimal luongTheoNgay = (luongCB / 26) * (decimal)ngayCong;

                    item.TongLuong = Math.Round(
                        luongTheoNgay + (item.PhuCap ?? 0) + (item.Thuong ?? 0) - (item.KyLuat ?? 0), 0);

                    db.SaveChanges();
                    MessageBox.Show("Đã cập nhật!");
                    LoadDataLuong();
                }
                else
                {
                    MessageBox.Show("Nhân viên chưa có bảng lương. Hãy bấm 'Tính Lương' trước.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        //Xuất báo cáo ra Excel
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvLuong.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                int thang = dtpThangNam.Value.Month;
                int nam = dtpThangNam.Value.Year;
                worksheet.Name = $"Luong_T{thang}_{nam}";

                int colIndex = 1;
                // Header
                for (int i = 0; i < dgvLuong.Columns.Count; i++)
                {
                    if (dgvLuong.Columns[i].Visible)
                    {
                        worksheet.Cells[1, colIndex] = dgvLuong.Columns[i].HeaderText;
                        Excel.Range cell = worksheet.Cells[1, colIndex];
                        cell.Font.Bold = true;
                        cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        colIndex++;
                    }
                }
                // Data
                for (int i = 0; i < dgvLuong.Rows.Count; i++)
                {
                    colIndex = 1;
                    for (int j = 0; j < dgvLuong.Columns.Count; j++)
                    {
                        if (dgvLuong.Columns[j].Visible)
                        {
                            var value = dgvLuong.Rows[i].Cells[j].Value;
                            // Thêm dấu nháy đơn (') để Excel hiểu là Text, tránh lỗi định dạng số học
                            worksheet.Cells[i + 2, colIndex] = "'" + (value?.ToString() ?? "");
                            colIndex++;
                        }
                    }
                }
                worksheet.Columns.AutoFit();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }

        private void dtpThangNam_ValueChanged(object sender, EventArgs e) { LoadDataLuong(); }
        private void btnThoat_Click(object sender, EventArgs e) { this.Close(); }
    }
}