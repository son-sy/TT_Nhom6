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
			// Chặn người dùng nhân viên và pm nếu chọn form tài khoản
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
		void LoadComboBoxNhanVien()
		{
			try
			{
				using (var db = new QuanLyNhanSuContext())
				{
					//Lấy và hiển thị dl
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
			cboVaiTro.SelectedIndex = 2; // Mặc định chọn NhanVien
		}
		void LoadDataTaiKhoan()
		{
			try
			{
				using (var db = new QuanLyNhanSuContext())
				{
					// Lấy dữ liệu mới nhất từ DB
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

						dgvTaiKhoan.Columns["MaNV"].Visible = true; // Hiện ID để đối chiếu
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

			DialogResult check = MessageBox.Show(
				$"Bạn đang chọn: {tenHienThi}\n" +
				$"ID hệ thống nhận được là: {idNvChon}\n\n" +
				"Xác nhận tạo tài khoản cho nhân viên này?",
				"XÁC NHẬN ID", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (check == DialogResult.Cancel) return;
			using (var db = new QuanLyNhanSuContext())
			{
				// Kiểm tra trùng Tên đăng nhập
				if (db.TKs.Find(txtTenTK.Text.Trim()) != null)
				{
					MessageBox.Show("Tên đăng nhập này đã tồn tại!"); return;
				}

				// Kiểm tra nhân viên này đã có tài khoản chưa
				var existingAcc = db.TKs.FirstOrDefault(x => x.IdNv == idNvChon);
				if (existingAcc != null)
				{
					MessageBox.Show($"Nhân viên này (ID {idNvChon}) đã có tài khoản là: {existingAcc.TenTk}");
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

					MessageBox.Show($"Đã thêm tài khoản thành công cho ID {idNvChon}!");
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

				//Không cho xóa hr ra khỏi hệ thống
				if (tk.VaiTro.Trim().ToUpper() == "HR" || tk.VaiTro.Trim().ToUpper() == "ADMIN")
				{
					MessageBox.Show("Không thể xóa tài khoản Quản trị (HR/Admin)!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản [{tk.TenTk}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

					txtTenTK.Enabled = false; // Khóa tên đăng nhập không được sửa khóa chính
					cboNhanVien.Enabled = false; // Khóa chọn nhân viên khi sửa
				}
				catch { }
			}
		}

		private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); }
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

		void ResetForm()
		{
			txtTenTK.Text = ""; txtMatKhau.Text = "";
			txtTenTK.Enabled = true;
			cboNhanVien.Enabled = true;
			if (cboNhanVien.Items.Count > 0) cboNhanVien.SelectedIndex = -1;
			cboVaiTro.SelectedIndex = 2;
		}
	}
}