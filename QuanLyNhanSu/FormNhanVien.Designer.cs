namespace QuanLyNhanSu
{
    partial class FormNhanVien
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
			lblHoten = new Label();
			lblChucvu = new Label();
			lblDiachi = new Label();
			lblSDT = new Label();
			lblEmail = new Label();
			lblNgaysinh = new Label();
			txtHoTen = new TextBox();
			txtEmail = new TextBox();
			txtSDT = new TextBox();
			txtDiaChi = new TextBox();
			dtpNgaySinh = new DateTimePicker();
			btnThem = new Button();
			btnSua = new Button();
			btnXoa = new Button();
			grpGioiTinh = new GroupBox();
			rdoNu = new RadioButton();
			rdoNam = new RadioButton();
			label1 = new Label();
			label2 = new Label();
			dgvNhanVien = new DataGridView();
			label3 = new Label();
			txtLuongCoBan = new TextBox();
			cboPhongBan = new ComboBox();
			cboChucVu = new ComboBox();
			btnXuatExcel = new Button();
			label4 = new Label();
			label5 = new Label();
			btnThoat = new Button();
			grpGioiTinh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
			SuspendLayout();
			// 
			// lblHoten
			// 
			lblHoten.AutoSize = true;
			lblHoten.BackColor = Color.PaleGreen;
			lblHoten.ForeColor = Color.Black;
			lblHoten.Location = new Point(12, 158);
			lblHoten.Name = "lblHoten";
			lblHoten.Size = new Size(56, 20);
			lblHoten.TabIndex = 0;
			lblHoten.Text = "Họ Tên";
			// 
			// lblChucvu
			// 
			lblChucvu.AutoSize = true;
			lblChucvu.BackColor = Color.PaleGreen;
			lblChucvu.Location = new Point(481, 270);
			lblChucvu.Name = "lblChucvu";
			lblChucvu.Size = new Size(63, 20);
			lblChucvu.TabIndex = 1;
			lblChucvu.Text = "Chức Vụ";
			// 
			// lblDiachi
			// 
			lblDiachi.AutoSize = true;
			lblDiachi.BackColor = Color.PaleGreen;
			lblDiachi.Location = new Point(481, 217);
			lblDiachi.Name = "lblDiachi";
			lblDiachi.Size = new Size(55, 20);
			lblDiachi.TabIndex = 2;
			lblDiachi.Text = "Địa chỉ";
			// 
			// lblSDT
			// 
			lblSDT.AutoSize = true;
			lblSDT.BackColor = Color.PaleGreen;
			lblSDT.Location = new Point(12, 277);
			lblSDT.Name = "lblSDT";
			lblSDT.Size = new Size(35, 20);
			lblSDT.TabIndex = 3;
			lblSDT.Text = "SDT";
			// 
			// lblEmail
			// 
			lblEmail.AutoSize = true;
			lblEmail.BackColor = Color.PaleGreen;
			lblEmail.Location = new Point(12, 330);
			lblEmail.Name = "lblEmail";
			lblEmail.Size = new Size(46, 20);
			lblEmail.TabIndex = 4;
			lblEmail.Text = "Email";
			// 
			// lblNgaysinh
			// 
			lblNgaysinh.AutoSize = true;
			lblNgaysinh.BackColor = Color.PaleGreen;
			lblNgaysinh.Location = new Point(481, 158);
			lblNgaysinh.Name = "lblNgaysinh";
			lblNgaysinh.Size = new Size(76, 20);
			lblNgaysinh.TabIndex = 6;
			lblNgaysinh.Text = "Ngày Sinh";
			// 
			// txtHoTen
			// 
			txtHoTen.Location = new Point(119, 151);
			txtHoTen.Margin = new Padding(3, 4, 3, 4);
			txtHoTen.Name = "txtHoTen";
			txtHoTen.Size = new Size(304, 27);
			txtHoTen.TabIndex = 7;
			// 
			// txtEmail
			// 
			txtEmail.Location = new Point(119, 323);
			txtEmail.Margin = new Padding(3, 4, 3, 4);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new Size(304, 27);
			txtEmail.TabIndex = 10;
			// 
			// txtSDT
			// 
			txtSDT.Location = new Point(119, 270);
			txtSDT.Margin = new Padding(3, 4, 3, 4);
			txtSDT.Name = "txtSDT";
			txtSDT.Size = new Size(304, 27);
			txtSDT.TabIndex = 11;
			// 
			// txtDiaChi
			// 
			txtDiaChi.Location = new Point(600, 209);
			txtDiaChi.Margin = new Padding(3, 4, 3, 4);
			txtDiaChi.Name = "txtDiaChi";
			txtDiaChi.Size = new Size(304, 27);
			txtDiaChi.TabIndex = 12;
			// 
			// dtpNgaySinh
			// 
			dtpNgaySinh.Location = new Point(600, 149);
			dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
			dtpNgaySinh.Name = "dtpNgaySinh";
			dtpNgaySinh.Size = new Size(304, 27);
			dtpNgaySinh.TabIndex = 13;
			// 
			// btnThem
			// 
			btnThem.BackColor = Color.Gainsboro;
			btnThem.ForeColor = Color.Black;
			btnThem.Location = new Point(1014, 149);
			btnThem.Margin = new Padding(3, 4, 3, 4);
			btnThem.Name = "btnThem";
			btnThem.Size = new Size(121, 54);
			btnThem.TabIndex = 15;
			btnThem.Text = "Thêm";
			btnThem.UseVisualStyleBackColor = false;
			btnThem.Click += btnThem_Click;
			// 
			// btnSua
			// 
			btnSua.BackColor = Color.Gainsboro;
			btnSua.ForeColor = Color.Black;
			btnSua.Location = new Point(1014, 228);
			btnSua.Margin = new Padding(3, 4, 3, 4);
			btnSua.Name = "btnSua";
			btnSua.Size = new Size(121, 55);
			btnSua.TabIndex = 16;
			btnSua.Text = "Sửa";
			btnSua.UseVisualStyleBackColor = false;
			btnSua.Click += btnSua_Click;
			// 
			// btnXoa
			// 
			btnXoa.BackColor = Color.Gainsboro;
			btnXoa.ForeColor = Color.Black;
			btnXoa.Location = new Point(1167, 149);
			btnXoa.Margin = new Padding(3, 4, 3, 4);
			btnXoa.Name = "btnXoa";
			btnXoa.Size = new Size(133, 54);
			btnXoa.TabIndex = 17;
			btnXoa.Text = "Xóa";
			btnXoa.UseVisualStyleBackColor = false;
			btnXoa.Click += btnXoa_Click;
			// 
			// grpGioiTinh
			// 
			grpGioiTinh.BackColor = Color.PaleGreen;
			grpGioiTinh.Controls.Add(rdoNu);
			grpGioiTinh.Controls.Add(rdoNam);
			grpGioiTinh.Location = new Point(910, 149);
			grpGioiTinh.Margin = new Padding(3, 4, 3, 4);
			grpGioiTinh.Name = "grpGioiTinh";
			grpGioiTinh.Padding = new Padding(3, 4, 3, 4);
			grpGioiTinh.Size = new Size(92, 121);
			grpGioiTinh.TabIndex = 19;
			grpGioiTinh.TabStop = false;
			grpGioiTinh.Text = "Giới tính";
			// 
			// rdoNu
			// 
			rdoNu.AutoSize = true;
			rdoNu.Location = new Point(19, 79);
			rdoNu.Margin = new Padding(3, 4, 3, 4);
			rdoNu.Name = "rdoNu";
			rdoNu.Size = new Size(50, 24);
			rdoNu.TabIndex = 1;
			rdoNu.TabStop = true;
			rdoNu.Text = "Nữ";
			rdoNu.UseVisualStyleBackColor = true;
			// 
			// rdoNam
			// 
			rdoNam.AutoSize = true;
			rdoNam.Location = new Point(19, 32);
			rdoNam.Margin = new Padding(3, 4, 3, 4);
			rdoNam.Name = "rdoNam";
			rdoNam.Size = new Size(62, 24);
			rdoNam.TabIndex = 0;
			rdoNam.TabStop = true;
			rdoNam.Text = "Nam";
			rdoNam.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(433, 284);
			label1.Name = "label1";
			label1.Size = new Size(0, 20);
			label1.TabIndex = 21;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.PaleGreen;
			label2.Location = new Point(12, 217);
			label2.Name = "label2";
			label2.Size = new Size(80, 20);
			label2.TabIndex = 22;
			label2.Text = "Phòng ban";
			// 
			// dgvNhanVien
			// 
			dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvNhanVien.Location = new Point(0, 403);
			dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
			dgvNhanVien.Name = "dgvNhanVien";
			dgvNhanVien.RowHeadersWidth = 51;
			dgvNhanVien.Size = new Size(1300, 348);
			dgvNhanVien.TabIndex = 14;
			dgvNhanVien.CellClick += dgvNhanVien_CellClick;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.PaleGreen;
			label3.Location = new Point(481, 330);
			label3.Name = "label3";
			label3.Size = new Size(104, 20);
			label3.TabIndex = 23;
			label3.Text = "Lương cơ bản ";
			// 
			// txtLuongCoBan
			// 
			txtLuongCoBan.Location = new Point(600, 323);
			txtLuongCoBan.Name = "txtLuongCoBan";
			txtLuongCoBan.Size = new Size(300, 27);
			txtLuongCoBan.TabIndex = 24;
			// 
			// cboPhongBan
			// 
			cboPhongBan.FormattingEnabled = true;
			cboPhongBan.Items.AddRange(new object[] { "Ban Giám Đốc", "Phòng Hành chính Nhân sự", "Phòng Kế toán", "Phòng Kinh doanh", "Phòng Kỹ thuật" });
			cboPhongBan.Location = new Point(123, 209);
			cboPhongBan.Name = "cboPhongBan";
			cboPhongBan.Size = new Size(300, 28);
			cboPhongBan.TabIndex = 25;
			// 
			// cboChucVu
			// 
			cboChucVu.FormattingEnabled = true;
			cboChucVu.Items.AddRange(new object[] { "HR", "PM", "Nhân Viên" });
			cboChucVu.Location = new Point(600, 262);
			cboChucVu.Name = "cboChucVu";
			cboChucVu.Size = new Size(300, 28);
			cboChucVu.TabIndex = 26;
			// 
			// btnXuatExcel
			// 
			btnXuatExcel.BackColor = Color.Gainsboro;
			btnXuatExcel.ForeColor = Color.Black;
			btnXuatExcel.Location = new Point(1167, 228);
			btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
			btnXuatExcel.Name = "btnXuatExcel";
			btnXuatExcel.Size = new Size(133, 54);
			btnXuatExcel.TabIndex = 27;
			btnXuatExcel.Text = "Xuất báo cáo";
			btnXuatExcel.UseVisualStyleBackColor = false;
			btnXuatExcel.Click += btnXuatExcel_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.Gainsboro;
			label4.ForeColor = Color.DeepPink;
			label4.Location = new Point(12, 379);
			label4.Name = "label4";
			label4.Size = new Size(242, 20);
			label4.TabIndex = 28;
			label4.Text = "DANH SÁCH NHÂN VIÊN CÔNG TY";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.Gainsboro;
			label5.ForeColor = Color.DeepPink;
			label5.Location = new Point(578, 30);
			label5.Name = "label5";
			label5.Size = new Size(234, 20);
			label5.TabIndex = 29;
			label5.Text = "QUẢN LÝ THÔNG TIN NHÂN VIÊN";
			// 
			// btnThoat
			// 
			btnThoat.BackColor = Color.Gainsboro;
			btnThoat.ForeColor = Color.Black;
			btnThoat.Location = new Point(1179, 13);
			btnThoat.Margin = new Padding(3, 4, 3, 4);
			btnThoat.Name = "btnThoat";
			btnThoat.Size = new Size(121, 54);
			btnThoat.TabIndex = 30;
			btnThoat.Text = "Thoát";
			btnThoat.UseVisualStyleBackColor = false;
			btnThoat.Click += btnThoat_Click;
			// 
			// FormNhanVien
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			ClientSize = new Size(1301, 753);
			Controls.Add(btnThoat);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(btnXuatExcel);
			Controls.Add(cboChucVu);
			Controls.Add(cboPhongBan);
			Controls.Add(txtLuongCoBan);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(grpGioiTinh);
			Controls.Add(btnXoa);
			Controls.Add(btnSua);
			Controls.Add(btnThem);
			Controls.Add(dgvNhanVien);
			Controls.Add(dtpNgaySinh);
			Controls.Add(txtDiaChi);
			Controls.Add(txtSDT);
			Controls.Add(txtEmail);
			Controls.Add(txtHoTen);
			Controls.Add(lblNgaysinh);
			Controls.Add(lblEmail);
			Controls.Add(lblSDT);
			Controls.Add(lblDiachi);
			Controls.Add(lblChucvu);
			Controls.Add(lblHoten);
			ForeColor = Color.Black;
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormNhanVien";
			Text = "FormNhanVien";
			Load += FormNhanVien_Load;
			grpGioiTinh.ResumeLayout(false);
			grpGioiTinh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblHoten;
        private Label lblChucvu;
        private Label lblDiachi;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblNgaysinh;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private DateTimePicker dtpNgaySinh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private GroupBox grpGioiTinh;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private Label label1;
        private Label label2;
        private DataGridView dgvNhanVien;
        private Label label3;
        private TextBox txtLuongCoBan;
        private ComboBox cboPhongBan;
        private ComboBox cboChucVu;
		private Button btnXuatExcel;
		private Label label4;
		private Label label5;
		private Button btnThoat;
	}
}
