using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu
{
    public partial class FormNghiPhep : Form
    {
        QuanLyNhanSuContext db = new QuanLyNhanSuContext();
        public FormNghiPhep()
        {
            InitializeComponent();
        }
        private void FormNghiPhep_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            //Tự động điền mã nhân viên nếu người đó muốn nghỉ phép
            if (LuuTru.IdNhanVien != null)
            {
                txtMaNV.Text = LuuTru.IdNhanVien.ToString();
            }

            PhanQuyenGiaoDien();
            LoadDataNghiPhep();
        }

        void PhanQuyenGiaoDien()
        {
            string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
            bool isQuanLy = (quyen == "hr" || quyen == "pm" || quyen == "admin");

            //Chỉ có HR và PM mới có nút duyệt phép
            if (isQuanLy)
            {
                if (Controls.ContainsKey("btnDuyet")) Controls["btnDuyet"].Visible = true;
                if (Controls.ContainsKey("btnTuChoi")) Controls["btnTuChoi"].Visible = true;
                txtMaNV.ReadOnly = false; //PM,HR có thể lọc đơn của nhân viên
            }
            else
            {
                if (Controls.ContainsKey("btnDuyet")) Controls["btnDuyet"].Visible = false;
                if (Controls.ContainsKey("btnTuChoi")) Controls["btnTuChoi"].Visible = false;
                txtMaNV.ReadOnly = true; // Nhân viên chỉ xem được của mình
            }
            btnNopDon.Visible = true;
            btnHuyDon.Visible = true;
        }

        //Load dữ liệu có lọc theo quyền
        void LoadDataNghiPhep()
        {
            try
            {
                using (var context = new QuanLyNhanSuContext())
                {
                    dgvNghiPhep.DataSource = null;
                    var query = from d in context.DonNghiPheps
                                join n in context.Nvs on d.IdNv equals n.IdNv
                                select new
                                {
                                    ID = d.IdDon,
                                    MaNV = d.IdNv,
                                    TenNV = n.NvTen,
                                    PhongBan = n.PhongBan, // Lấy phòng ban để PM lọc
                                    TuNgay = d.NgayBatDau,
                                    DenNgay = d.NgayKetThuc,
                                    SoNgay = d.SoNgay,
                                    LyDo = d.LyDo,
                                    TrangThai = d.TrangThai
                                };

                    string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
                    int myID = LuuTru.IdNhanVien ?? 0;

                    if (quyen == "hr" || quyen == "admin")
                    {
                        //HR Thấy toàn bộ đơn
                    }
                    else if (quyen == "pm")
                    {
                        //Pm Chỉ thấy đơn của nhân viên CÙNG PHÒNG BAN
                        var pmInfo = context.Nvs.Find(myID);
                        if (pmInfo != null && !string.IsNullOrEmpty(pmInfo.PhongBan))
                        {
                            query = query.Where(x => x.PhongBan == pmInfo.PhongBan);
                        }
                        else
                        {
                            query = query.Where(x => x.MaNV == myID);
                        }
                    }
                    else
                    {
                        //Nhân viên chỉ thấy đơn của chính mình
                        query = query.Where(x => x.MaNV == myID);
                    }
                    var list = query.OrderByDescending(x => x.ID).ToList();
                    var displayList = list.Select(x => new
                    {
                        x.ID,
                        x.MaNV,
                        x.TenNV,
                        x.TuNgay,
                        x.DenNgay,
                        x.SoNgay,
                        x.LyDo,
                        x.TrangThai
                    }).ToList();
                    dgvNghiPhep.DataSource = displayList;
                    FormatLuoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        void FormatLuoi()
        {
            if (dgvNghiPhep.Columns.Count == 0) return;
            if (dgvNghiPhep.Columns["ID"] != null) dgvNghiPhep.Columns["ID"].Visible = false;

            dgvNghiPhep.Columns["MaNV"].HeaderText = "Mã NV";
            dgvNghiPhep.Columns["TenNV"].HeaderText = "Họ Tên";
            dgvNghiPhep.Columns["TuNgay"].HeaderText = "Từ Ngày";
            dgvNghiPhep.Columns["DenNgay"].HeaderText = "Đến Ngày";
            dgvNghiPhep.Columns["SoNgay"].HeaderText = "Số Ngày";
            dgvNghiPhep.Columns["LyDo"].HeaderText = "Lý Do";
            dgvNghiPhep.Columns["TrangThai"].HeaderText = "Trạng Thái";

            try { dgvNghiPhep.Columns["TenNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } catch { }
        }

        private void dgvNghiPhep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dgvNghiPhep.Rows[e.RowIndex];
                    btnHuyDon.Tag = row.Cells["ID"].Value;

                    txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                    txtLyDo.Text = row.Cells["LyDo"].Value?.ToString();

                    if (row.Cells["TuNgay"].Value != null)
                        dtpTuNgay.Value = Convert.ToDateTime(row.Cells["TuNgay"].Value);
                    if (row.Cells["DenNgay"].Value != null)
                        dtpDenNgay.Value = Convert.ToDateTime(row.Cells["DenNgay"].Value);
                    // Không cho hủy đơn đã được xử lý
                    string trangThai = row.Cells["TrangThai"].Value?.ToString();
                    if (trangThai == "Đã duyệt" || trangThai == "Từ chối")
                        btnHuyDon.Enabled = false;
                    else
                        btnHuyDon.Enabled = true;
                }
                catch { }
            }
        }

        private void btnNopDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!"); return;
            }

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            //Kiểm tra logic ngày tháng hợp lệ
            if (denNgay < tuNgay)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!"); return;
            }

            try
            {
                using (var context = new QuanLyNhanSuContext())
                {
                    DonNghiPhep don = new DonNghiPhep();
                    don.IdNv = int.Parse(txtMaNV.Text);
                    don.NgayBatDau = tuNgay;
                    don.NgayKetThuc = denNgay;
                    don.SoNgay = (int)(denNgay - tuNgay).TotalDays + 1;
                    don.LoaiNghi = "Nghỉ phép";
                    don.LyDo = txtLyDo.Text;
                    don.TrangThai = "Chờ duyệt"; // Mặc định trạng thái ban đầu

                    context.DonNghiPheps.Add(don);
                    context.SaveChanges();

                    MessageBox.Show("Nộp đơn thành công!");
                    LoadDataNghiPhep();
                    txtLyDo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nộp đơn: " + ex.Message);
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (btnHuyDon.Tag == null && dgvNghiPhep.CurrentRow == null) return;
            int idDon = 0;
            if (btnHuyDon.Tag != null) idDon = Convert.ToInt32(btnHuyDon.Tag);
            else idDon = Convert.ToInt32(dgvNghiPhep.CurrentRow.Cells["ID"].Value);

            try
            {
                using (var context = new QuanLyNhanSuContext())
                {
                    var don = context.DonNghiPheps.Find(idDon);
                    if (don != null)
                    {
                        //Không cho xóa đơn đã có kết quả xử lý
                        if (don.TrangThai != "Chờ duyệt")
                        {
                            MessageBox.Show("Không thể hủy đơn đã được xử lý (Đã duyệt hoặc Từ chối)!"); return;
                        }
                        if (MessageBox.Show("Bạn muốn hủy đơn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            context.DonNghiPheps.Remove(don);
                            context.SaveChanges();
                            MessageBox.Show("Đã hủy đơn!");
                            LoadDataNghiPhep();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi hủy: " + ex.Message); }
        }
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            XuLyDon("Đã duyệt");
        }
        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            XuLyDon("Từ chối");
        }

        //Xử lý duyệt đơn phức tạp kiểm tra quyền hạn
        void XuLyDon(string trangThaiMoi)
        {
            if (dgvNghiPhep.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn cần xử lý!"); return;
            }

            try
            {
                string quyenCuaToi = LuuTru.Quyen.ToLower().Trim();
                int? idCuaToi = LuuTru.IdNhanVien;

                if (quyenCuaToi != "hr" && quyenCuaToi != "pm" && quyenCuaToi != "admin")
                {
                    MessageBox.Show("Bạn không có quyền duyệt đơn!"); return;
                }

                int idDon = Convert.ToInt32(dgvNghiPhep.CurrentRow.Cells["ID"].Value);
                int idNguoiXin = Convert.ToInt32(dgvNghiPhep.CurrentRow.Cells["MaNV"].Value);

                using (var context = new QuanLyNhanSuContext())
                {
                    var nguoiXin = context.Nvs.Find(idNguoiXin);
                    var toi = context.Nvs.Find(idCuaToi);
                    var tkNguoiXin = context.TKs.FirstOrDefault(x => x.IdNv == idNguoiXin);

                    string phongBanNguoiXin = (nguoiXin != null) ? nguoiXin.PhongBan : "";
                    string phongBanCuaToi = (toi != null) ? toi.PhongBan : "";
                    string quyenNguoiXin = (tkNguoiXin != null) ? tkNguoiXin.VaiTro.ToLower().Trim() : "nhanvien";
                    if (quyenCuaToi == "pm")
                    {
                        //PM không thể tự duyệt đơn của chính mình
                        if (idCuaToi == idNguoiXin)
                        {
                            MessageBox.Show("Bạn không thể tự duyệt đơn của mình!\nVui lòng nhờ HR phê duyệt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //Pm không thể duyệt đơn cho HR
                        if (quyenNguoiXin == "pm" || quyenNguoiXin == "hr" || quyenNguoiXin == "admin")
                        {
                            MessageBox.Show($"Vượt thẩm quyền! Bạn không thể duyệt đơn cho chức vụ: {quyenNguoiXin.ToUpper()}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        //Không cho Pm duyệt đơn của phòng ban khác
                        if (phongBanCuaToi != phongBanNguoiXin)
                        {
                            MessageBox.Show($"Bạn thuộc phòng '{phongBanCuaToi}' nhưng nhân viên này thuộc phòng '{phongBanNguoiXin}'.\nBạn không có quyền duyệt đơn này!", "Sai phòng ban", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    if (quyenCuaToi == "hr" || quyenCuaToi == "admin")
                    {
                        if (idCuaToi == idNguoiXin)
                        {
                            MessageBox.Show("Lưu ý: HR/Admin không nên tự duyệt đơn của mình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    var don = context.DonNghiPheps.Find(idDon);
                    if (don != null)
                    {
                        if (don.TrangThai == "Đã duyệt" || don.TrangThai == "Từ chối")
                        {
                            MessageBox.Show("Đơn này đã được xử lý rồi!"); return;
                        }

                        don.TrangThai = trangThaiMoi;
                        context.SaveChanges();

                        MessageBox.Show("Đã xử lý thành công: " + trangThaiMoi);
                        LoadDataNghiPhep();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đơn này!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}