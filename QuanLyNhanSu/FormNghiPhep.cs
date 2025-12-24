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
		// Khởi tạo Context để kết nối CSDL
		QuanLyNhanSuContext db = new QuanLyNhanSuContext();
		public FormNghiPhep()
		{
			InitializeComponent();
		}
		private void FormNghiPhep_Load(object sender, EventArgs e)
		{
			// Hiển thị ngày tháng (dd/MM/yyyy)
			dtpTuNgay.Format = DateTimePickerFormat.Custom;
			dtpTuNgay.CustomFormat = "dd/MM/yyyy";
			dtpDenNgay.Format = DateTimePickerFormat.Custom;
			dtpDenNgay.CustomFormat = "dd/MM/yyyy";

			//Tự động điền Mã NV của người đang đăng nhập
			if (LuuTru.IdNhanVien != null)
			{
				txtMaNV.Text = LuuTru.IdNhanVien.ToString();
			}

			//Phân quyền và tải dữ liệu ngay khi mở
			PhanQuyenGiaoDien();
			LoadDataNghiPhep();
		}
		void PhanQuyenGiaoDien()
		{
			string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
			bool isQuanLy = (quyen == "hr" || quyen == "pm" || quyen == "admin");
			if (isQuanLy)
			{
				// Được thấy nút Duyệt,Từ chối
				if (Controls.ContainsKey("btnDuyet")) Controls["btnDuyet"].Visible = true;
				if (Controls.ContainsKey("btnTuChoi")) Controls["btnTuChoi"].Visible = true;
				// Được sửa ô Mã NV để tìm kiếm đơn của nhân viên khác
				txtMaNV.ReadOnly = false;
			}
			else
			{
				if (Controls.ContainsKey("btnDuyet")) Controls["btnDuyet"].Visible = false;
				if (Controls.ContainsKey("btnTuChoi")) Controls["btnTuChoi"].Visible = false;
				// Khóa ô Mã NV
				txtMaNV.ReadOnly = true;
			}
			btnNopDon.Visible = true;
			btnHuyDon.Visible = true;
		}
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
									TuNgay = d.NgayBatDau,
									DenNgay = d.NgayKetThuc,
									SoNgay = d.SoNgay,
									LyDo = d.LyDo,
									TrangThai = d.TrangThai
								};
					// Nếu không phải quản lý chỉ được thấy đơn của chính mình
					string quyen = LuuTru.Quyen != null ? LuuTru.Quyen.ToLower().Trim() : "";
					if (quyen != "hr" && quyen != "pm" && quyen != "admin")
					{
						int idCuaToi = LuuTru.IdNhanVien ?? 0;
						query = query.Where(x => x.MaNV == idCuaToi);
					}

					// Sắp xếp đơn mới nhất lên đầu
					var list = query.OrderByDescending(x => x.ID).ToList();
					dgvNghiPhep.DataSource = list;
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
			// Kiểm tra nhập liệu
			if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtLyDo.Text))
			{
				MessageBox.Show("Vui lòng nhập đủ thông tin!"); return;
			}

			DateTime tuNgay = dtpTuNgay.Value.Date;
			DateTime denNgay = dtpDenNgay.Value.Date;

			// Kiểm tra Logic thời gian
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
					don.SoNgay = (int)(denNgay - tuNgay).TotalDays + 1; // Tính số ngày nghỉ
					don.LoaiNghi = "Nghỉ phép";
					don.LyDo = txtLyDo.Text;
					don.TrangThai = "Chờ duyệt"; // Mặc định trạng thái ban đầu

					context.DonNghiPheps.Add(don);
					context.SaveChanges();

					MessageBox.Show("Nộp đơn thành công!");
					LoadDataNghiPhep(); // Tải lại bảng
					txtLyDo.Text = ""; // Xóa ô lý do
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
						// Chỉ được hủy khi đơn đang "Chờ duyệt"
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

		void XuLyDon(string trangThaiMoi)
		{
			if (dgvNghiPhep.CurrentRow == null)
			{
				MessageBox.Show("Vui lòng chọn đơn cần xử lý!"); return;
			}

			try
			{
				// Lấy thông tin người đang thực hiện hành động
				string quyenCuaToi = LuuTru.Quyen.ToLower().Trim();
				int? idCuaToi = LuuTru.IdNhanVien;

				//Chặn ngay nếu là nhân viên
				if (quyenCuaToi != "hr" && quyenCuaToi != "pm" && quyenCuaToi != "admin")
				{
					MessageBox.Show("Bạn không có quyền duyệt đơn!"); return;
				}

				// 2. Lấy thông tin người nộp đơn (Người Xin)
				int idDon = Convert.ToInt32(dgvNghiPhep.CurrentRow.Cells["ID"].Value);
				int idNguoiXin = Convert.ToInt32(dgvNghiPhep.CurrentRow.Cells["MaNV"].Value);

				using (var context = new QuanLyNhanSuContext())
				{
					// Truy vấn DB để xem Người Xin đang giữ chức vụ gì
					var tkNguoiXin = context.TKs.FirstOrDefault(x => x.IdNv == idNguoiXin);
					string quyenNguoiXin = "nhanvien"; // Mặc định coi là nhân viên nếu chưa có TK

					if (tkNguoiXin != null && tkNguoiXin.VaiTro != null)
					{
						quyenNguoiXin = tkNguoiXin.VaiTro.ToLower().Trim();
					}

					if (quyenCuaToi == "pm")
					{
						//PM không được tự duyệt đơn của chính mình
						if (idCuaToi == idNguoiXin)
						{
							MessageBox.Show("Bạn không thể tự duyệt đơn của mình!\nVui lòng nhờ HR phê duyệt.",
											"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}

						// PM không được duyệt cho cấp ngang hàng
						if (quyenNguoiXin == "pm" || quyenNguoiXin == "hr" || quyenNguoiXin == "admin")
						{
							MessageBox.Show($"Bạn là PM, bạn chỉ được duyệt đơn cho Nhân viên thường.\n\nNgười xin này có quyền: {quyenNguoiXin.ToUpper()}.\n-> Phải do HR xử lý.",
											"Vượt thẩm quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
							return;
						}
					}

					if (quyenCuaToi == "hr" || quyenCuaToi == "admin")
					{
						// Nhắc nhở HR không nên tự duyệt
						if (idCuaToi == idNguoiXin)
						{
							MessageBox.Show("Lưu ý: HR/Admin không nên tự duyệt đơn của mình để khách quan.",
											"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}

					var don = context.DonNghiPheps.Find(idDon);
					if (don != null)
					{
						// Kiểm tra nếu đơn đã bị người khác duyệt trước đó
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
						MessageBox.Show("Không tìm thấy đơn này (có thể đã bị hủy)!");
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
			// Hỏi xác nhận trước khi đóng để tránh bấm nhầm
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