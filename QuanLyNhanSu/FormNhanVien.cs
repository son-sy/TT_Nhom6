using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
// Thư viện Excel
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
	public partial class FormNhanVien : System.Windows.Forms.Form
	{
		// Khai báo Context kết nối Database
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
		void PhanQuyenGiaoDien()
		{
			string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";

			// HR có đầy đủ tất cả quyền
			if (quyen == "hr" || quyen == "admin")
			{
				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;
				MoKhoaNhapLieu(true);
			}
			//PM chỉ được xem
			else if (quyen == "pm")
			{
				btnThem.Enabled = false;
				btnSua.Enabled = false;
				btnXoa.Enabled = false;
				MoKhoaNhapLieu(false);

				// Ẩn cột lương và ô lương trên giao diện
				if (dgvNhanVien.Columns["LuongCoBan"] != null)
				{
					dgvNhanVien.Columns["LuongCoBan"].Visible = false;
				}
				txtLuongCoBan.Text = "###";
				txtLuongCoBan.Visible = false;
			}
			//Nhân viên không được vào form
			else
			{
				MessageBox.Show("Bạn không có quyền truy cập quản lý hồ sơ nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.Close();
			}
		}
		void MoKhoaNhapLieu(bool choPhep)
		{
			txtHoTen.ReadOnly = !choPhep;
			txtDiaChi.ReadOnly = !choPhep;
			txtSDT.ReadOnly = !choPhep;
			txtEmail.ReadOnly = !choPhep;
			txtLuongCoBan.ReadOnly = !choPhep;

			dtpNgaySinh.Enabled = choPhep;
			cboPhongBan.Enabled = choPhep;
			cboChucVu.Enabled = choPhep;
			rdoNam.Enabled = choPhep;
			rdoNu.Enabled = choPhep;
		}
		private void HienThiDuLieu()
		{
			try
			{
				// Khởi tạo lại Context để đảm bảo lấy dữ liệu mới nhất
				db = new QuanLyNhanSuContext();
				// Sử dụng LINQ để chọn các trường cần thiết hiển thị lên lưới
				var danhSach = db.Nvs.Select(nv => new
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
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
			}
		}
		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (dgvNhanVien.SelectedRows.Count == 0 && dgvNhanVien.CurrentRow == null)
			{
				MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Kiểm tra quyền
			string quyen = LuuTru.Quyen.ToLower();
			if (quyen != "hr" && quyen != "admin")
			{
				MessageBox.Show("Bạn không có quyền xóa!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			try
			{
				int idCanXoa = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["MaNV"].Value);
				var taiKhoanQuanTri = db.TKs.FirstOrDefault(t => t.IdNv == idCanXoa);

				if (taiKhoanQuanTri != null)
				{
					string vaiTro = taiKhoanQuanTri.VaiTro != null ? taiKhoanQuanTri.VaiTro.Trim().ToLower() : "";

					if (vaiTro == "hr" || vaiTro == "admin")
					{
						MessageBox.Show($"KHÔNG THỂ XÓA!\nNhân viên này đang giữ quyền quản trị hệ thống ({taiKhoanQuanTri.VaiTro}).\n\nVui lòng sang mục 'Quản lý Tài khoản' để xóa tài khoản hoặc hạ quyền trước.",
										"Bảo vệ hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?\nCảnh báo: Dữ liệu Lương, Chấm công và Tài khoản liên quan sẽ bị xóa vĩnh viễn!",
									"Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					var nhanVienCanXoa = db.Nvs.Find(idCanXoa);

					if (nhanVienCanXoa != null)
					{
						//Xóa các bảng để tránh lỗi khóa ngoại
						var luongLienQuan = db.Luongs.Where(l => l.IdNv == idCanXoa).ToList();
						db.Luongs.RemoveRange(luongLienQuan);

						var congLienQuan = db.ChamCongs.Where(c => c.IdNv == idCanXoa).ToList();
						db.ChamCongs.RemoveRange(congLienQuan);
						var tkLienQuan = db.TKs.Where(t => t.IdNv == idCanXoa).ToList();
						db.TKs.RemoveRange(tkLienQuan);
						db.Nvs.Remove(nhanVienCanXoa);
						db.SaveChanges();
						MessageBox.Show("Đã xóa nhân viên thành công!");
						HienThiDuLieu();
						ResetForm();
					}
					else
					{
						MessageBox.Show("Nhân viên không tồn tại hoặc đã bị xóa!");
						HienThiDuLieu();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi xóa: " + ex.Message);
			}
		}
		private void btnThem_Click(object sender, EventArgs e)
		{
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
				// Loại bỏ dấu phẩy,chấm để đưa về số
				if (!string.IsNullOrEmpty(txtLuongCoBan.Text) && txtLuongCoBan.Visible)
				{
					string luongStr = txtLuongCoBan.Text.Replace(",", "").Replace(".", "").Trim();
					if (decimal.TryParse(luongStr, out decimal luong))
						NhanVienMoi.LuongCoBan = luong;
					else
						NhanVienMoi.LuongCoBan = 0;
				}
				else
				{
					NhanVienMoi.LuongCoBan = 0;
				}

				db.Nvs.Add(NhanVienMoi);
				db.SaveChanges();
				MessageBox.Show("Thêm nhân viên thành công!");
				HienThiDuLieu();
				ResetForm();
			}
			catch (Exception ex)
			{
				string loiChiTiet = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
				if (ex.InnerException != null && ex.InnerException.InnerException != null)
				{
					loiChiTiet = ex.InnerException.InnerException.Message;
				}
				MessageBox.Show("Lỗi chi tiết: " + loiChiTiet);
			}
		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			if (dgvNhanVien.SelectedRows.Count == 0 && dgvNhanVien.CurrentRow == null)
			{
				MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
				return;
			}

			string quyen = LuuTru.Quyen.ToLower();
			if (quyen != "hr" && quyen != "admin") return;

			try
			{
				int idCanSua = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["MaNV"].Value);
				var nv = db.Nvs.Find(idCanSua);

				if (nv != null)
				{
					nv.NvTen = txtHoTen.Text;
					nv.DiaChi = txtDiaChi.Text;
					nv.SDt = txtSDT.Text;
					nv.Email = txtEmail.Text;
					nv.NgaySinh = dtpNgaySinh.Value;
					nv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
					nv.PhongBan = cboPhongBan.Text;
					nv.Chucvu = cboChucVu.Text;

					// Xử lý cập nhật lương
					if (!string.IsNullOrEmpty(txtLuongCoBan.Text) && txtLuongCoBan.Visible)
					{
						string luongStr = txtLuongCoBan.Text.Replace(",", "").Replace(".", "").Trim();
						if (decimal.TryParse(luongStr, out decimal luong))
							nv.LuongCoBan = luong;
					}

					db.SaveChanges();
					MessageBox.Show("Cập nhật thông tin thành công!");
					HienThiDuLieu();
					ResetForm();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi cập nhật: " + ex.Message);
			}
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

					if (row.Cells["NgaySinh"].Value != null)
						dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

					cboPhongBan.Text = row.Cells["PhongBan"].Value?.ToString();
					cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString();
					string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower() : "";
					if ((quyen == "hr" || quyen == "admin") && row.Cells["LuongCoBan"].Value != null)
					{
						decimal luong = Convert.ToDecimal(row.Cells["LuongCoBan"].Value);
						txtLuongCoBan.Text = luong.ToString("N0");
					}
					else
					{
						txtLuongCoBan.Text = "###";
					}
				}
				catch { }
			}
		}
		private void btnXuatExcel_Click(object sender, EventArgs e)
		{
			if (dgvNhanVien.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu để xuất!");
				return;
			}

			try
			{
				Excel.Application excelApp = new Excel.Application();
				excelApp.Visible = true;
				Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
				worksheet.Name = "DanhSachNhanVien";
				// Tạo tiêu đề cột
				int colIndex = 1;
				for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
				{
					if (dgvNhanVien.Columns[i].Visible)
					{
						worksheet.Cells[1, colIndex] = dgvNhanVien.Columns[i].HeaderText;
						Excel.Range cell = worksheet.Cells[1, colIndex];
						cell.Font.Bold = true;
						cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
						colIndex++;
					}
				}
				// Đổ dữ liệu
				for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
				{
					colIndex = 1;
					for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
					{
						if (dgvNhanVien.Columns[j].Visible)
						{
							var value = dgvNhanVien.Rows[i].Cells[j].Value;
							string strValue = value != null ? value.ToString() : "";
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

		private void ResetForm()
		{
			// Xóa trắng các ô nhập liệu
			txtHoTen.Text = ""; txtDiaChi.Text = ""; txtSDT.Text = ""; txtEmail.Text = "";
			cboPhongBan.SelectedIndex = -1; cboChucVu.SelectedIndex = -1;
			if (txtLuongCoBan.Visible) txtLuongCoBan.Text = "";
			dtpNgaySinh.Value = DateTime.Now; rdoNam.Checked = true;
		}
		private void btnThoat_Click(object sender, EventArgs e)
		{
			DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn đóng form này?",
											 "Xác nhận",
											 MessageBoxButtons.YesNo,
											 MessageBoxIcon.Question);
			if (hoi == DialogResult.Yes)
			{
				this.Close();
			}
		}
	}
}