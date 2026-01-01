using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Models;
using System.Globalization;

namespace QuanLyNhanSu
{
    public partial class FormChamCong : System.Windows.Forms.Form
    {
        QuanLyNhanSuContext db = new QuanLyNhanSuContext();

        //chọn ngày chấm công cụ thể
        DateTimePicker dtpNgayCham = new DateTimePicker();

        public FormChamCong()
        {
            InitializeComponent();
        }

        private void FormChamCong_Load(object sender, EventArgs e)
        {
            dtpThangNam.Format = DateTimePickerFormat.Custom;
            dtpThangNam.CustomFormat = "MM/yyyy";
            dtpThangNam.ShowUpDown = true;
            // Cấu hình và thêm control chọn ngày vào giao diện lúc chạy
            dtpNgayCham.Format = DateTimePickerFormat.Custom;
            dtpNgayCham.CustomFormat = "dd/MM/yyyy";
            dtpNgayCham.Width = 110;
            dtpNgayCham.Top = dtpThangNam.Top;
            dtpNgayCham.Left = dtpThangNam.Right + 20;
            this.Controls.Add(dtpNgayCham);
            LoadCboNhanVien();
            LoadDataChamCong();
            PhanQuyenGiaoDien();

            cboNhanVien.SelectedIndexChanged += cboNhanVien_SelectedIndexChanged;
        }

        void LoadCboNhanVien()
        {
            try
            {
                using (var context = new QuanLyNhanSuContext())
                {
                    var query = context.Nvs.AsQueryable();
                    string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
                    int myID = LuuTru.IdNhanVien ?? 0;

                    //PM chỉ thấy nhân viên thuộc phòng mình quản lý trong ComboBox
                    if (quyen == "pm")
                    {
                        var pmInfo = context.Nvs.Find(myID);
                        if (pmInfo != null && !string.IsNullOrEmpty(pmInfo.PhongBan))
                            query = query.Where(x => x.PhongBan == pmInfo.PhongBan);
                        else
                            query = query.Where(x => x.IdNv == myID);
                    }

                    var listNV = query.Select(x => new
                    {
                        x.IdNv,
                        HoTenHienThi = "[" + x.IdNv + "] - " + x.NvTen
                    }).ToList();

                    cboNhanVien.DataSource = listNV;
                    cboNhanVien.DisplayMember = "HoTenHienThi";
                    cboNhanVien.ValueMember = "IdNv";
                    cboNhanVien.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Tự động fill dữ liệu vào ô nhập khi chọn nhân viên
            if (cboNhanVien.SelectedValue == null || !cboNhanVien.Focused) return;
            try
            {
                int idNv = Convert.ToInt32(cboNhanVien.SelectedValue);
                foreach (DataGridViewRow row in dgvChamCong.Rows)
                {
                    if (row.Cells["MaNV"].Value != null && Convert.ToInt32(row.Cells["MaNV"].Value) == idNv)
                    {
                        row.Selected = true;
                        dgvChamCong.CurrentCell = row.Cells[0];
                        txtSoNgayCong.Text = row.Cells["NgayCong"].Value?.ToString();
                        txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
                        return;
                    }
                }
                txtSoNgayCong.Text = "";
                txtGhiChu.Text = "";
            }
            catch { }
        }

        //Phân quyền chức năng
        void PhanQuyenGiaoDien()
        {
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";

            if (Controls.ContainsKey("btnDiemDanh")) Controls["btnDiemDanh"].Visible = true;

            if (quyen == "hr" || quyen == "admin" || quyen == "pm")
            {
                // HR được phép sửa, xóa công và chọn ngày quá khứ để chấm bù
                btnLuu.Visible = true;
                btnXoa.Visible = true;
                cboNhanVien.Enabled = true;
                txtSoNgayCong.ReadOnly = false;
                txtGhiChu.ReadOnly = false;
                dtpNgayCham.Enabled = true;

                if (quyen == "pm") this.Text = "Quản lý công Team";
                else this.Text = "Quản lý Chấm công";

                if (Controls.ContainsKey("btnDiemDanh")) Controls["btnDiemDanh"].Text = "Điểm danh";
            }
            else
            {
                //Nhân viên bị khóa toàn bộ chức năng chỉnh sửa.
                // Chỉ được phép xem và bấm nút điêm danh cho ngày hiện tại.
                btnLuu.Visible = false;
                btnXoa.Visible = false;
                cboNhanVien.Enabled = false;
                txtSoNgayCong.ReadOnly = true;
                txtGhiChu.ReadOnly = true;
                dtpNgayCham.Enabled = false; // Khóa chọn ngày
                dtpNgayCham.Value = DateTime.Now;

                if (LuuTru.IdNhanVien != null) cboNhanVien.SelectedValue = LuuTru.IdNhanVien;
                this.Text = "Bảng công cá nhân";
                if (Controls.ContainsKey("btnDiemDanh")) Controls["btnDiemDanh"].Text = "Điểm danh";
            }
        }

        //Lọc dữ liệu hiển thị theo vai trò
        void LoadDataChamCong()
        {
            int thang = dtpThangNam.Value.Month;
            int nam = dtpThangNam.Value.Year;
            try
            {
                using (var context = new QuanLyNhanSuContext())
                {
                    dgvChamCong.AutoGenerateColumns = true;
                    dgvChamCong.DataSource = null;
                    var query = context.ChamCongs.AsQueryable();
                    query = query.Where(cc => cc.Thang == thang && cc.Nam == nam);

                    string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
                    int myID = LuuTru.IdNhanVien ?? 0;

                    if (quyen == "pm")
                    {
                        // PM chỉ thấy công của nhân viên phòng mình
                        var pmInfo = context.Nvs.Find(myID);
                        if (pmInfo != null && !string.IsNullOrEmpty(pmInfo.PhongBan))
                            query = query.Where(cc => cc.NhanVien.PhongBan == pmInfo.PhongBan);
                        else
                            query = query.Where(cc => cc.IdNv == myID);
                    }
                    else if (quyen != "hr" && quyen != "admin")
                    {
                        //Nhân viên thường chỉ thấy công của chính mình
                        query = query.Where(cc => cc.IdNv == myID);
                    }

                    var rawData = query.Select(cc => new
                    {
                        ID = cc.IdChamCong,
                        MaNV = cc.IdNv,
                        TenNV = cc.NhanVien.NvTen,
                        Ngay = (int?)cc.Ngay,
                        Thang = (int?)cc.Thang,
                        Nam = (int?)cc.Nam,
                        Checkin = cc.Checkin,
                        Checkout = cc.Checkout,
                        TrangThai = cc.TrangThai,
                        SoNgayCong = (double?)cc.SoNgayCong,
                        GhiChu = cc.GhiChu
                    }).ToList();

                    var listHienThi = rawData.Select(cc => new
                    {
                        ID = cc.ID,
                        MaNV = cc.MaNV,
                        TenNV = cc.TenNV ?? "NV (" + cc.MaNV + ")",
                        Ngay = (cc.Ngay.HasValue) ? (cc.Ngay + "/" + thang + "/" + nam) : ("?/" + thang + "/" + nam),
                        GioVao = cc.Checkin ?? "",
                        GioRa = cc.Checkout ?? "",
                        TrangThai = cc.TrangThai ?? "Chưa rõ",
                        NgayCong = cc.SoNgayCong ?? 0,
                        GhiChu = cc.GhiChu ?? "",
                        SortDay = cc.Ngay ?? 0
                    }).OrderByDescending(x => x.SortDay).ToList();

                    dgvChamCong.DataSource = listHienThi;
                    FormatBangChamCong();
                }
            }
            catch { }
        }

        void FormatBangChamCong()
        {
            if (dgvChamCong.Columns.Count == 0) return;
            if (dgvChamCong.Columns["ID"] != null) dgvChamCong.Columns["ID"].Visible = false;
            if (dgvChamCong.Columns["SortDay"] != null) dgvChamCong.Columns["SortDay"].Visible = false;

            dgvChamCong.Columns["MaNV"].HeaderText = "Mã NV";
            dgvChamCong.Columns["TenNV"].HeaderText = "Họ Tên";
            dgvChamCong.Columns["Ngay"].HeaderText = "Ngày";
            dgvChamCong.Columns["GioVao"].HeaderText = "Giờ Vào";
            dgvChamCong.Columns["GioRa"].HeaderText = "Giờ Ra";
            dgvChamCong.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvChamCong.Columns["NgayCong"].HeaderText = "Công";
            dgvChamCong.Columns["GhiChu"].HeaderText = "Ghi Chú";

            try { dgvChamCong.Columns["TenNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } catch { }
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = dgvChamCong.Rows[e.RowIndex];
                if (row.Cells["MaNV"].Value != null)
                {
                    int maNV = Convert.ToInt32(row.Cells["MaNV"].Value);
                    cboNhanVien.SelectedIndexChanged -= cboNhanVien_SelectedIndexChanged;
                    cboNhanVien.SelectedValue = maNV;
                    cboNhanVien.SelectedIndexChanged += cboNhanVien_SelectedIndexChanged;
                }
                txtSoNgayCong.Text = row.Cells["NgayCong"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
            catch { }
        }

        // xử lý Chấm công và Chấm bù
        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            int idCanCham = 0;
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";

            //Xác định đối tượng cần chấm công
            if (quyen == "hr" || quyen == "admin" || quyen == "pm")
            {
                //HR,PM được chấm công dùm nhân viên 
                if (cboNhanVien.SelectedValue != null) idCanCham = Convert.ToInt32(cboNhanVien.SelectedValue);
                else if (LuuTru.IdNhanVien != null) idCanCham = LuuTru.IdNhanVien.Value;
            }
            else
            {
                // Nhân viên chỉ được chấm cho chính mình
                if (LuuTru.IdNhanVien != null) idCanCham = LuuTru.IdNhanVien.Value;
            }

            if (idCanCham == 0) { MessageBox.Show("Chưa chọn nhân viên!"); return; }

            //Lấy ngày cần chấm
            DateTime ngayChon = dtpNgayCham.Value.Date;
            DateTime homNay = DateTime.Now.Date;

            //Ngăn chặn nhân viên tự chấm cho quá khứ/tương lai
            if ((quyen != "hr" && quyen != "pm" && quyen != "admin") && ngayChon != homNay)
            {
                MessageBox.Show("Nhân viên chỉ được phép điểm danh cho ngày hôm nay!\nNếu quên, vui lòng liên hệ PM/HR.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayCham.Value = DateTime.Now;
                return;
            }

            try
            {
                using (var context = new QuanLyNhanSuContext())
                {
                    // Kiểm tra xem ngày đó đã có dữ liệu chưa
                    var congTonTai = context.ChamCongs.FirstOrDefault(cc =>
                        cc.IdNv == idCanCham &&
                        cc.Ngay == ngayChon.Day &&
                        cc.Thang == ngayChon.Month &&
                        cc.Nam == ngayChon.Year);

                    var nvInfo = context.Nvs.Find(idCanCham);
                    string tenNV = nvInfo != null ? nvInfo.NvTen : "NV";

                    //Ghi lại ai là người thực hiện hành động
                    string tenNguoiCham = LuuTru.Quyen != null ? LuuTru.Quyen.ToUpper() : "QL";
                    bool isChamHo = (LuuTru.IdNhanVien != null && idCanCham != LuuTru.IdNhanVien.Value);
                    if (ngayChon < homNay)
                    {
                        if (congTonTai != null)
                        {
                            MessageBox.Show($"Ngày {ngayChon:dd/MM} của nhân viên {tenNV} đã có dữ liệu!\nNếu muốn sửa, hãy dùng nút 'Lưu'.", "Đã tồn tại");
                            return;
                        }

                        // Tự động điền giờ hành chính
                        ChamCong moi = new ChamCong();
                        moi.IdNv = idCanCham;
                        moi.Ngay = ngayChon.Day;
                        moi.Thang = ngayChon.Month;
                        moi.Nam = ngayChon.Year;
                        moi.Checkin = "08:00";
                        moi.Checkout = "17:00";
                        moi.TrangThai = "Bổ sung";
                        moi.SoNgayCong = 1.0;
                        moi.GhiChu = $"[Bổ sung bởi {tenNguoiCham}]"; // Ghi chú

                        context.ChamCongs.Add(moi);
                        context.SaveChanges();
                        MessageBox.Show($"Đã bổ sung công ngày {ngayChon:dd/MM} cho {tenNV}!");
                    }
                    // CHẤM THỜI GIAN THỰC
                    else if (ngayChon == homNay)
                    {
                        string gioHienTai = DateTime.Now.ToString("HH:mm");

                        if (congTonTai == null)
                        {
                            //Lần đầu trong ngày
                            ChamCong moi = new ChamCong();
                            moi.IdNv = idCanCham;
                            moi.Ngay = ngayChon.Day;
                            moi.Thang = ngayChon.Month;
                            moi.Nam = ngayChon.Year;
                            moi.Checkin = gioHienTai;
                            moi.Checkout = "";
                            moi.TrangThai = "Đang làm việc";
                            moi.SoNgayCong = 0.5; // Tạm tính nửa công
                            if (isChamHo) moi.GhiChu = $"[Check-in hộ bởi {tenNguoiCham}]";

                            context.ChamCongs.Add(moi);
                            context.SaveChanges();
                            MessageBox.Show($"Đã Check-in cho {tenNV} lúc {gioHienTai}!");
                        }
                        else
                        {
                            // Lần hai trong ngày
                            if (string.IsNullOrEmpty(congTonTai.Checkout))
                            {
                                congTonTai.Checkout = gioHienTai;
                                congTonTai.TrangThai = "Hoàn thành";
                                congTonTai.SoNgayCong = (congTonTai.SoNgayCong ?? 0) + 0.5; // Cộng dồn thành 1 công
                                if (isChamHo) congTonTai.GhiChu += $" | [Check-out hộ bởi {tenNguoiCham}]";

                                context.SaveChanges();
                                MessageBox.Show($"Đã Check-out cho {tenNV} lúc {gioHienTai}!");
                            }
                            else
                            {
                                MessageBox.Show($"Nhân viên {tenNV} đã hoàn thành đủ Check-in/out hôm nay rồi!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể chấm công cho tương lai!", "Lỗi");
                    }
                }
                LoadDataChamCong();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvChamCong.CurrentRow == null) { MessageBox.Show("Chưa chọn dòng nào!"); return; }
            try
            {
                int id = Convert.ToInt32(dgvChamCong.CurrentRow.Cells["ID"].Value);
                using (var context = new QuanLyNhanSuContext())
                {
                    var item = context.ChamCongs.Find(id);
                    if (item != null)
                    {
                        //Kiểm tra tính hợp lệ của số ngày công
                        string inputString = txtSoNgayCong.Text.Replace(',', '.');
                        if (double.TryParse(inputString, NumberStyles.Any, CultureInfo.InvariantCulture, out double nc))
                        {
                            if (nc > 1.0) { MessageBox.Show("Ngày công không được quá 1!"); return; }
                            if (nc <= 0) { MessageBox.Show("Ngày công phải lớn hơn 0!"); return; }
                            item.SoNgayCong = nc;
                        }
                        else { MessageBox.Show("Số ngày công không hợp lệ!"); return; }

                        item.GhiChu = txtGhiChu.Text;
                        if (cboNhanVien.Enabled && cboNhanVien.SelectedValue != null)
                            item.IdNv = (int)cboNhanVien.SelectedValue;

                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!");
                        LoadDataChamCong();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChamCong.CurrentRow == null) return;
            if (MessageBox.Show("Xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvChamCong.CurrentRow.Cells["ID"].Value);
                    using (var context = new QuanLyNhanSuContext())
                    {
                        var item = context.ChamCongs.Find(id);
                        if (item != null) { context.ChamCongs.Remove(item); context.SaveChanges(); LoadDataChamCong(); }
                    }
                }
                catch { }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) { this.Close(); }
        private void dtpThangNam_ValueChanged(object sender, EventArgs e) { LoadDataChamCong(); }
    }
}