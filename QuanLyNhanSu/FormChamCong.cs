using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu
{
	public partial class FormChamCong : System.Windows.Forms.Form
	{
		QuanLyNhanSuContext db = new QuanLyNhanSuContext();

		public FormChamCong()
		{
			InitializeComponent();
		}

		private void FormChamCong_Load(object sender, EventArgs e)
		{
			dtpThangNam.Format = DateTimePickerFormat.Custom;
			dtpThangNam.CustomFormat = "MM/yyyy";
			dtpThangNam.ShowUpDown = true;

			LoadCboNhanVien();
			LoadDataChamCong();
			PhanQuyenGiaoDien();
		}

		void LoadCboNhanVien()
		{
			try
			{
				using (var context = new QuanLyNhanSuContext())
				{
					var listNV = context.Nvs.Select(x => new
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

		void PhanQuyenGiaoDien()
		{
			string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";

			if (Controls.ContainsKey("btnDiemDanh"))
				Controls["btnDiemDanh"].Visible = true;

			if (quyen == "hr" || quyen == "admin" || quyen == "quanly")
			{
				btnLuu.Visible = true;
				btnXoa.Visible = true;
				if (Controls.ContainsKey("btnSua")) Controls["btnSua"].Visible = true;

				cboNhanVien.Enabled = true;

				txtSoNgayCong.ReadOnly = false;
				txtGhiChu.ReadOnly = false;
			}
			else
			{
				btnLuu.Visible = false;
				btnXoa.Visible = false;
				if (Controls.ContainsKey("btnSua")) Controls["btnSua"].Visible = false;

				cboNhanVien.Enabled = false;

				txtSoNgayCong.ReadOnly = true;
				txtGhiChu.ReadOnly = true;

				if (LuuTru.IdNhanVien != null)
				{
					cboNhanVien.SelectedValue = LuuTru.IdNhanVien;
				}
			}
		}

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
					if (quyen != "hr" && quyen != "admin" && quyen != "quanly")
					{
						if (LuuTru.IdNhanVien != null)
						{
							int myID = LuuTru.IdNhanVien.Value;
							query = query.Where(cc => cc.IdNv == myID);
						}
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
					})
					.OrderByDescending(x => x.SortDay)
					.ToList();

					dgvChamCong.DataSource = listHienThi;
					FormatBangChamCong();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi hiển thị: " + ex.Message);
			}
		}

		void FormatBangChamCong()
		{
			if (dgvChamCong.Columns.Count == 0) return;

			if (dgvChamCong.Columns["ID"] != null) dgvChamCong.Columns["ID"].Visible = false;
			if (dgvChamCong.Columns["SortDay"] != null) dgvChamCong.Columns["SortDay"].Visible = false;

			if (dgvChamCong.Columns["MaNV"] != null) dgvChamCong.Columns["MaNV"].HeaderText = "Mã NV";
			if (dgvChamCong.Columns["TenNV"] != null) dgvChamCong.Columns["TenNV"].HeaderText = "Họ Tên";
			if (dgvChamCong.Columns["Ngay"] != null) dgvChamCong.Columns["Ngay"].HeaderText = "Ngày";
			if (dgvChamCong.Columns["GioVao"] != null) dgvChamCong.Columns["GioVao"].HeaderText = "Giờ Vào";
			if (dgvChamCong.Columns["GioRa"] != null) dgvChamCong.Columns["GioRa"].HeaderText = "Giờ Ra";
			if (dgvChamCong.Columns["TrangThai"] != null) dgvChamCong.Columns["TrangThai"].HeaderText = "Trạng Thái";
			if (dgvChamCong.Columns["NgayCong"] != null) dgvChamCong.Columns["NgayCong"].HeaderText = "Công";
			if (dgvChamCong.Columns["GhiChu"] != null) dgvChamCong.Columns["GhiChu"].HeaderText = "Ghi Chú";

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
					if (cboNhanVien.Enabled)
					{
						cboNhanVien.SelectedValue = maNV;
					}
				}

				txtSoNgayCong.Text = row.Cells["NgayCong"].Value?.ToString() ?? "0";
				txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
			}
			catch { }
		}

		private void btnDiemDanh_Click(object sender, EventArgs e)
		{
			if (LuuTru.IdNhanVien == null)
			{
				MessageBox.Show("Lỗi: Không tìm thấy ID nhân viên trong phiên đăng nhập!");
				return;
			}

			int idNv = LuuTru.IdNhanVien.Value;
			DateTime now = DateTime.Now;

			try
			{
				using (var context = new QuanLyNhanSuContext())
				{
					var congHomNay = context.ChamCongs.FirstOrDefault(cc =>
						cc.IdNv == idNv &&
						cc.Ngay == now.Day &&
						cc.Thang == now.Month &&
						cc.Nam == now.Year);

					if (congHomNay == null)
					{
						ChamCong moi = new ChamCong();
						moi.IdNv = idNv;
						moi.Ngay = now.Day;
						moi.Thang = now.Month;
						moi.Nam = now.Year;
						moi.Checkin = now.ToString("HH:mm");
						moi.Checkout = "";
						moi.TrangThai = "Đang làm việc";
						moi.SoNgayCong = 0.5;
						moi.GhiChu = "";

						context.ChamCongs.Add(moi);
						context.SaveChanges();
						MessageBox.Show($"Check-in thành công: {moi.Checkin}");
					}
					else
					{
						if (string.IsNullOrEmpty(congHomNay.Checkout))
						{
							congHomNay.Checkout = now.ToString("HH:mm");
							congHomNay.TrangThai = "Hoàn thành";
							congHomNay.SoNgayCong = 1.0;
							context.SaveChanges();
							MessageBox.Show($"Check-out thành công: {congHomNay.Checkout}");
						}
						else
						{
							MessageBox.Show("Hôm nay bạn đã hoàn thành chấm công rồi!");
						}
					}
				}
				LoadDataChamCong();
			}
			catch (Exception ex) { MessageBox.Show("Lỗi chấm công: " + ex.Message); }
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
						if (double.TryParse(txtSoNgayCong.Text, out double nc))
							item.SoNgayCong = nc;

						item.GhiChu = txtGhiChu.Text;

						if (cboNhanVien.Enabled && cboNhanVien.SelectedValue != null)
							item.IdNv = (int)cboNhanVien.SelectedValue;

						context.SaveChanges();
						MessageBox.Show("Đã cập nhật!");
						LoadDataChamCong();
					}
				}
			}
			catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (dgvChamCong.CurrentRow == null) return;

			if (MessageBox.Show("Xóa dòng chấm công này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					int id = Convert.ToInt32(dgvChamCong.CurrentRow.Cells["ID"].Value);
					using (var context = new QuanLyNhanSuContext())
					{
						var item = context.ChamCongs.Find(id);
						if (item != null)
						{
							context.ChamCongs.Remove(item);
							context.SaveChanges();
							LoadDataChamCong();
						}
					}
				}
				catch { }
			}
		}

		private void btnThoat_Click(object sender, EventArgs e) { this.Close(); }
		private void dtpThangNam_ValueChanged(object sender, EventArgs e) { LoadDataChamCong(); }
	}
}