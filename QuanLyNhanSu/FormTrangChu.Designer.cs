namespace QuanLyNhanSu
{
    partial class FormTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrangChu));
			label1 = new Label();
			btnNhanVien = new Button();
			btnChamCong = new Button();
			btnLuong = new Button();
			btnDangXuat = new Button();
			btnThoat = new Button();
			btnNghiPhep = new Button();
			btnTaiKhoan = new Button();
			btnXemLuongCaNhan = new Button();
			btnDoiMatKhau = new Button();
			label2 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = Color.Black;
			label1.Location = new Point(386, 25);
			label1.Name = "label1";
			label1.Size = new Size(217, 20);
			label1.TabIndex = 0;
			label1.Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ";
			// 
			// btnNhanVien
			// 
			btnNhanVien.ForeColor = Color.Black;
			btnNhanVien.Location = new Point(105, 121);
			btnNhanVien.Name = "btnNhanVien";
			btnNhanVien.Size = new Size(152, 55);
			btnNhanVien.TabIndex = 1;
			btnNhanVien.Text = "Quản lý nhân viên";
			btnNhanVien.UseVisualStyleBackColor = true;
			btnNhanVien.Click += btnNhanVien_Click;
			// 
			// btnChamCong
			// 
			btnChamCong.Location = new Point(12, 197);
			btnChamCong.Name = "btnChamCong";
			btnChamCong.Size = new Size(152, 55);
			btnChamCong.TabIndex = 2;
			btnChamCong.Text = "Quản Lý Chấm Công";
			btnChamCong.UseVisualStyleBackColor = true;
			btnChamCong.Click += btnChamCong_Click;
			// 
			// btnLuong
			// 
			btnLuong.Location = new Point(12, 275);
			btnLuong.Name = "btnLuong";
			btnLuong.Size = new Size(152, 55);
			btnLuong.TabIndex = 3;
			btnLuong.Text = "Quản Lý Tính Lương";
			btnLuong.UseVisualStyleBackColor = true;
			btnLuong.Click += btnLuong_Click;
			// 
			// btnDangXuat
			// 
			btnDangXuat.Location = new Point(202, 430);
			btnDangXuat.Name = "btnDangXuat";
			btnDangXuat.Size = new Size(152, 55);
			btnDangXuat.TabIndex = 4;
			btnDangXuat.Text = "Đăng Xuất";
			btnDangXuat.UseVisualStyleBackColor = true;
			btnDangXuat.Click += btnDangXuat_Click;
			// 
			// btnThoat
			// 
			btnThoat.Location = new Point(202, 350);
			btnThoat.Name = "btnThoat";
			btnThoat.Size = new Size(152, 55);
			btnThoat.TabIndex = 5;
			btnThoat.Text = "Thoát Chương Trình";
			btnThoat.UseVisualStyleBackColor = true;
			btnThoat.Click += btnThoat_Click;
			// 
			// btnNghiPhep
			// 
			btnNghiPhep.Location = new Point(12, 350);
			btnNghiPhep.Name = "btnNghiPhep";
			btnNghiPhep.Size = new Size(152, 55);
			btnNghiPhep.TabIndex = 6;
			btnNghiPhep.Text = "Quản Lý Nghỉ phép";
			btnNghiPhep.UseVisualStyleBackColor = true;
			btnNghiPhep.Click += btnNghiPhep_Click;
			// 
			// btnTaiKhoan
			// 
			btnTaiKhoan.Location = new Point(12, 430);
			btnTaiKhoan.Name = "btnTaiKhoan";
			btnTaiKhoan.Size = new Size(152, 55);
			btnTaiKhoan.TabIndex = 7;
			btnTaiKhoan.Text = "Quản Lý Tài khoản";
			btnTaiKhoan.UseVisualStyleBackColor = true;
			btnTaiKhoan.Click += btnTaiKhoan_Click;
			// 
			// btnXemLuongCaNhan
			// 
			btnXemLuongCaNhan.Location = new Point(202, 275);
			btnXemLuongCaNhan.Name = "btnXemLuongCaNhan";
			btnXemLuongCaNhan.Size = new Size(152, 55);
			btnXemLuongCaNhan.TabIndex = 9;
			btnXemLuongCaNhan.Text = "Quản Lý Lương Cá Nhân\r\n\r\n";
			btnXemLuongCaNhan.UseVisualStyleBackColor = true;
			btnXemLuongCaNhan.Click += btnXemLuongCaNhan_Click;
			// 
			// btnDoiMatKhau
			// 
			btnDoiMatKhau.Location = new Point(202, 197);
			btnDoiMatKhau.Name = "btnDoiMatKhau";
			btnDoiMatKhau.Size = new Size(152, 55);
			btnDoiMatKhau.TabIndex = 15;
			btnDoiMatKhau.Text = " Quản Lý Đổi Mật Khẩu";
			btnDoiMatKhau.UseVisualStyleBackColor = true;
			btnDoiMatKhau.Click += btnDoiMatKhau_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = Color.Black;
			label2.Location = new Point(116, 75);
			label2.Name = "label2";
			label2.Size = new Size(141, 20);
			label2.TabIndex = 16;
			label2.Text = "MENU CHỨC NĂNG";
			// 
			// FormTrangChu
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.PaleGreen;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			ClientSize = new Size(958, 497);
			Controls.Add(label2);
			Controls.Add(btnDoiMatKhau);
			Controls.Add(btnXemLuongCaNhan);
			Controls.Add(btnTaiKhoan);
			Controls.Add(btnNghiPhep);
			Controls.Add(btnThoat);
			Controls.Add(btnDangXuat);
			Controls.Add(btnLuong);
			Controls.Add(btnChamCong);
			Controls.Add(btnNhanVien);
			Controls.Add(label1);
			ForeColor = Color.Black;
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormTrangChu";
			Text = "FormTrangChu";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Button btnNhanVien;
        private Button btnChamCong;
        private Button btnLuong;
        private Button btnDangXuat;
        private Button btnThoat;
        private Button btnNghiPhep;
        private Button btnTaiKhoan;
        private Button btnXemLuongCaNhan;
		private Button btnDoiMatKhau;
		private Label label2;
	}
}