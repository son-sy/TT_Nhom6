using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Models;
// QUAN TRỌNG: Thư viện Excel để xuất báo cáo
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
	public partial class FormLuong : System.Windows.Forms.Form
	{
		QuanLyNhanSuContext db = new QuanLyNhanSuContext();

		public FormLuong()
		{
			InitializeComponent();
		}

		private void FormLuong_Load(object sender, EventArgs e)
		{
			// định dạng ngày tháng chỉ hiện Tháng/Năm (MM/yyyy)
			dtpThangNam.Format = DateTimePickerFormat.Custom;
			dtpThangNam.CustomFormat = "MM/yyyy";
			dtpThangNam.ShowUpDown = true;
			PhanQuyenGiaoDien();
			// 3. Tải dữ liệu lương của tháng hiện tại
			LoadDataLuong();
		}
		void PhanQuyenGiaoDien()
		{
			string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";

			if (quyen == "hr" || quyen == "admin")
			{
				// Được phép bấm nút Tính toán và Điều chỉnh
				btnTinhLuong.Visible = true;
				btnDieuChinh.Visible = true;

				// Được phép nhập liệu các ô Phụ cấp, Thưởng, Phạt
				txtPhuCap.Enabled = true;
				txtThuong.Enabled = true;
				txtKyLuat.Enabled = true;
				txtGhiChu.Enabled = true;
			}
			else
			{
				// Chỉ được xem, ẩn hết các nút tác động dữ liệu
				btnTinhLuong.Visible = false;
				btnDieuChinh.Visible = false;

				// Ẩn nút Xóa (nếu có) để tránh xóa nhầm
				if (Controls.Find("btnXoa", true).Length > 0) Controls["btnXoa"].Visible = false;

				// Khóa toàn bộ các ô nhập liệu (Chế độ Read-only)
				txtPhuCap.Enabled = false;
				txtThuong.Enabled = false;
				txtKyLuat.Enabled = false;
				txtGhiChu.Enabled = false;
				txtMaNV.Enabled = false;
				txtTenNV.Enabled = false;
			}

			// Nút Xuất Excel luôn hiện với tất cả mọi người
			// HR xuất báo cáo tổng, Nhân viên xuất phiếu lương cá nhân
			if (Controls.Find("btnXuatExcel", true).Length > 0) Controls["btnXuatExcel"].Visible = true;
		}
		void LoadDataLuong()
		{
			int thang = dtpThangNam.Value.Month;
			int nam = dtpThangNam.Value.Year;

			try
			{
				db = new QuanLyNhanSuContext(); // Reset context để lấy dữ liệu mới nhất
				dgvLuong.AutoGenerateColumns = true;

				//Lấy lương theo Tháng/Năm đang chọn
				var query = db.Luongs
					.Include(l => l.NhanVien)
					.Where(l => l.Thang == thang && l.Nam == nam);
				string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
				if (quyen != "hr" && quyen != "admin")
				{
					int idCuaToi = LuuTru.IdNhanVien ?? -1;
					query = query.Where(l => l.IdNv == idCuaToi);
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
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi hiển thị: " + ex.Message);
			}
		}
		void FormatBangLuong()
		{
			if (dgvLuong.Columns.Count == 0) return;

			// Ẩn cột ID
			dgvLuong.Columns["ID"].Visible = false;
			dgvLuong.Columns["MaNV"].HeaderText = "Mã NV";
			dgvLuong.Columns["TenNV"].HeaderText = "Họ Tên";
			dgvLuong.Columns["LuongCung"].HeaderText = "Lương CB";
			dgvLuong.Columns["NgayCong"].HeaderText = "Công";
			dgvLuong.Columns["PhuCap"].HeaderText = "Phụ Cấp";
			dgvLuong.Columns["Thuong"].HeaderText = "Thưởng";
			dgvLuong.Columns["Phat"].HeaderText = "Kỷ Luật";
			dgvLuong.Columns["ThucLinh"].HeaderText = "Thực Lĩnh";
			dgvLuong.Columns["GhiChu"].HeaderText = "Ghi Chú";
			foreach (DataGridViewColumn col in dgvLuong.Columns)
			{
				if (col.Name == "LuongCung" || col.Name == "PhuCap" ||
					col.Name == "Thuong" || col.Name == "Phat" || col.Name == "ThucLinh")
				{
					col.DefaultCellStyle.Format = "N0"; 
					col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}
			}
			if (dgvLuong.Columns["TenNV"] != null)
				dgvLuong.Columns["TenNV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
					// Lấy dữ liệu chấm công từ bảng ChamCong
					var chamCong = db.ChamCongs.FirstOrDefault(cc => cc.IdNv == nv.IdNv && cc.Thang == thang && cc.Nam == nam);
					double soNgayCong = (chamCong != null) ? (double)(chamCong.SoNgayCong ?? 0) : 0;

					decimal luongCB = nv.LuongCoBan ?? 0;

					//Kiểm tra xem nhân viên đã có dòng lương tháng này chưa
					var bangLuong = db.Luongs.FirstOrDefault(l => l.IdNv == nv.IdNv && l.Thang == thang && l.Nam == nam);

					if (bangLuong == null)
					{
						bangLuong = new Luong();
						bangLuong.IdNv = nv.IdNv;
						bangLuong.Thang = thang;
						bangLuong.Nam = nam;
						bangLuong.PhuCap = 0;
						bangLuong.Thuong = 0;
						bangLuong.KyLuat = 0;
						db.Luongs.Add(bangLuong);
					}

					// Cập nhật thông tin
					bangLuong.LuongCoBan = luongCB;
					bangLuong.SoNgayCong = soNgayCong;
					// Lương ngày = Lương cơ bản / 26 ngày công chuẩn
					decimal luongTheoNgay = 0;
					if (luongCB > 0)
						luongTheoNgay = (luongCB / 26) * (decimal)soNgayCong;
					//Tổng thực lĩnh = Lương ngày + Phụ cấp + Thưởng - Phạt
					bangLuong.TongLuong = Math.Round(
						luongTheoNgay + (bangLuong.PhuCap ?? 0) + (bangLuong.Thuong ?? 0) - (bangLuong.KyLuat ?? 0), 0);

					count++;
				}

				db.SaveChanges();
				MessageBox.Show($"Đã tính xong lương cho {count} nhân viên!", "Thành công");
				LoadDataLuong();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}
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
					// Hàm cục bộ: Giúp loại bỏ các ký tự không phải số (như dấu phẩy, chữ)
					decimal ParseTien(string s)
					{
						if (string.IsNullOrEmpty(s)) return 0;
						string clean = new string(s.Where(c => char.IsDigit(c) || c == '-').ToArray());
						return decimal.TryParse(clean, out decimal res) ? res : 0;
					}

					// Cập nhật các khoản phụ
					item.PhuCap = ParseTien(txtPhuCap.Text);
					item.Thuong = ParseTien(txtThuong.Text);
					item.KyLuat = ParseTien(txtKyLuat.Text);
					item.GhiChu = txtGhiChu.Text;

					// Tính lại tổng lương ngay lập tức sau khi điều chỉnh
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

		private void btnXuatExcel_Click(object sender, EventArgs e)
		{
			if (dgvLuong.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu để xuất!");
				return;
			}

			try
			{
				// Khởi tạo Excel Application
				Excel.Application excelApp = new Excel.Application();
				excelApp.Visible = true; // Mở Excel lên cho người dùng thấy
				Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

				// Đặt tên Sheet theo tháng báo cáo
				int thang = dtpThangNam.Value.Month;
				int nam = dtpThangNam.Value.Year;
				worksheet.Name = $"Luong_T{thang}_{nam}";

				//Tạo tiêu đề cột
				int colIndex = 1;
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

				//Điền dữ liệu từng dòng
				for (int i = 0; i < dgvLuong.Rows.Count; i++)
				{
					colIndex = 1;
					for (int j = 0; j < dgvLuong.Columns.Count; j++)
					{
						if (dgvLuong.Columns[j].Visible)
						{
							var value = dgvLuong.Rows[i].Cells[j].Value;
							string strValue = value != null ? value.ToString() : "";

							// Thêm dấu nháy đơn để Excel hiểu là Text, tránh lỗi định dạng số
							worksheet.Cells[i + 2, colIndex] = "'" + strValue;
							colIndex++;
						}
					}
				}
				worksheet.Columns.AutoFit();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
			}
		}

		private void dtpThangNam_ValueChanged(object sender, EventArgs e)
		{
			LoadDataLuong(); // Tải lại dữ liệu khi đổi tháng
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}