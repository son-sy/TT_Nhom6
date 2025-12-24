namespace QuanLyNhanSu
{
    partial class FormLuong
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLuong));
			dtpThangNam = new DateTimePicker();
			btnTinhLuong = new Button();
			dgvLuong = new DataGridView();
			label1 = new Label();
			txtMaNV = new TextBox();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			txtTenNV = new TextBox();
			txtLuongCoBan = new TextBox();
			txtNgayCong = new TextBox();
			txtTongLuong = new TextBox();
			txtPhuCap = new TextBox();
			txtThuong = new TextBox();
			txtKyLuat = new TextBox();
			txtGhiChu = new TextBox();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			btnDieuChinh = new Button();
			btnThoat = new Button();
			label11 = new Label();
			label12 = new Label();
			btnXuatExcel = new Button();
			label13 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvLuong).BeginInit();
			SuspendLayout();
			// 
			// dtpThangNam
			// 
			dtpThangNam.CustomFormat = "MM/yyyy";
			dtpThangNam.Format = DateTimePickerFormat.Custom;
			dtpThangNam.Location = new Point(118, 122);
			dtpThangNam.Name = "dtpThangNam";
			dtpThangNam.Size = new Size(250, 27);
			dtpThangNam.TabIndex = 0;
			dtpThangNam.ValueChanged += dtpThangNam_ValueChanged;
			// 
			// btnTinhLuong
			// 
			btnTinhLuong.BackColor = Color.LightGray;
			btnTinhLuong.ForeColor = Color.Black;
			btnTinhLuong.Location = new Point(512, 357);
			btnTinhLuong.Name = "btnTinhLuong";
			btnTinhLuong.Size = new Size(110, 53);
			btnTinhLuong.TabIndex = 1;
			btnTinhLuong.Text = "Tính Lương Tự Động";
			btnTinhLuong.UseVisualStyleBackColor = false;
			btnTinhLuong.Click += btnTinhLuong_Click;
			// 
			// dgvLuong
			// 
			dgvLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvLuong.Location = new Point(1, 419);
			dgvLuong.Name = "dgvLuong";
			dgvLuong.RowHeadersWidth = 51;
			dgvLuong.Size = new Size(1056, 294);
			dgvLuong.TabIndex = 2;
			dgvLuong.CellClick += dgvLuong_CellClick;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.PaleGreen;
			label1.Location = new Point(12, 168);
			label1.Name = "label1";
			label1.Size = new Size(97, 20);
			label1.TabIndex = 3;
			label1.Text = "Mã nhân viên";
			// 
			// txtMaNV
			// 
			txtMaNV.BackColor = SystemColors.HighlightText;
			txtMaNV.Enabled = false;
			txtMaNV.Location = new Point(124, 168);
			txtMaNV.Name = "txtMaNV";
			txtMaNV.ReadOnly = true;
			txtMaNV.Size = new Size(250, 27);
			txtMaNV.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.Gainsboro;
			label2.ForeColor = Color.DeepPink;
			label2.Location = new Point(460, 23);
			label2.Name = "label2";
			label2.Size = new Size(123, 20);
			label2.TabIndex = 5;
			label2.Text = "QUẢN LÝ LƯƠNG";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.PaleGreen;
			label3.Location = new Point(8, 229);
			label3.Name = "label3";
			label3.Size = new Size(99, 20);
			label3.TabIndex = 6;
			label3.Text = "Tên nhân viên";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.PaleGreen;
			label4.Location = new Point(12, 287);
			label4.Name = "label4";
			label4.Size = new Size(100, 20);
			label4.TabIndex = 7;
			label4.Text = "Lương cơ bản";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.PaleGreen;
			label5.Location = new Point(12, 339);
			label5.Name = "label5";
			label5.Size = new Size(81, 20);
			label5.TabIndex = 8;
			label5.Text = "Ngày công";
			// 
			// txtTenNV
			// 
			txtTenNV.BackColor = SystemColors.ButtonHighlight;
			txtTenNV.Enabled = false;
			txtTenNV.Location = new Point(118, 222);
			txtTenNV.Name = "txtTenNV";
			txtTenNV.ReadOnly = true;
			txtTenNV.Size = new Size(250, 27);
			txtTenNV.TabIndex = 9;
			// 
			// txtLuongCoBan
			// 
			txtLuongCoBan.BackColor = SystemColors.ButtonHighlight;
			txtLuongCoBan.Enabled = false;
			txtLuongCoBan.Location = new Point(118, 280);
			txtLuongCoBan.Name = "txtLuongCoBan";
			txtLuongCoBan.ReadOnly = true;
			txtLuongCoBan.Size = new Size(250, 27);
			txtLuongCoBan.TabIndex = 10;
			// 
			// txtNgayCong
			// 
			txtNgayCong.BackColor = SystemColors.ButtonHighlight;
			txtNgayCong.Enabled = false;
			txtNgayCong.Location = new Point(118, 332);
			txtNgayCong.Name = "txtNgayCong";
			txtNgayCong.ReadOnly = true;
			txtNgayCong.Size = new Size(250, 27);
			txtNgayCong.TabIndex = 11;
			// 
			// txtTongLuong
			// 
			txtTongLuong.BackColor = SystemColors.ButtonHighlight;
			txtTongLuong.Enabled = false;
			txtTongLuong.Location = new Point(118, 386);
			txtTongLuong.Name = "txtTongLuong";
			txtTongLuong.ReadOnly = true;
			txtTongLuong.Size = new Size(250, 27);
			txtTongLuong.TabIndex = 12;
			// 
			// txtPhuCap
			// 
			txtPhuCap.Location = new Point(663, 120);
			txtPhuCap.Name = "txtPhuCap";
			txtPhuCap.Size = new Size(250, 27);
			txtPhuCap.TabIndex = 13;
			// 
			// txtThuong
			// 
			txtThuong.Location = new Point(663, 165);
			txtThuong.Name = "txtThuong";
			txtThuong.Size = new Size(250, 27);
			txtThuong.TabIndex = 14;
			// 
			// txtKyLuat
			// 
			txtKyLuat.Location = new Point(663, 222);
			txtKyLuat.Name = "txtKyLuat";
			txtKyLuat.Size = new Size(250, 27);
			txtKyLuat.TabIndex = 15;
			// 
			// txtGhiChu
			// 
			txtGhiChu.Location = new Point(663, 276);
			txtGhiChu.Name = "txtGhiChu";
			txtGhiChu.Size = new Size(250, 27);
			txtGhiChu.TabIndex = 16;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.BackColor = Color.PaleGreen;
			label6.Location = new Point(12, 393);
			label6.Name = "label6";
			label6.Size = new Size(86, 20);
			label6.TabIndex = 17;
			label6.Text = "Tổng lương";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.BackColor = Color.PaleGreen;
			label7.Location = new Point(512, 123);
			label7.Name = "label7";
			label7.Size = new Size(94, 20);
			label7.TabIndex = 18;
			label7.Text = "Tiền phụ cấp";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.BackColor = Color.PaleGreen;
			label8.Location = new Point(512, 175);
			label8.Name = "label8";
			label8.Size = new Size(89, 20);
			label8.TabIndex = 19;
			label8.Text = "Tiền thưởng";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.BackColor = Color.PaleGreen;
			label9.Location = new Point(512, 222);
			label9.Name = "label9";
			label9.Size = new Size(71, 20);
			label9.TabIndex = 20;
			label9.Text = "Tiền phạt";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.BackColor = Color.PaleGreen;
			label10.Location = new Point(512, 279);
			label10.Name = "label10";
			label10.Size = new Size(58, 20);
			label10.TabIndex = 21;
			label10.Text = "Ghi chú";
			// 
			// btnDieuChinh
			// 
			btnDieuChinh.BackColor = Color.Gainsboro;
			btnDieuChinh.ForeColor = Color.Black;
			btnDieuChinh.Location = new Point(659, 360);
			btnDieuChinh.Name = "btnDieuChinh";
			btnDieuChinh.Size = new Size(119, 50);
			btnDieuChinh.TabIndex = 22;
			btnDieuChinh.Text = "Cập nhật";
			btnDieuChinh.UseVisualStyleBackColor = false;
			btnDieuChinh.Click += btnDieuChinh_Click;
			// 
			// btnThoat
			// 
			btnThoat.BackColor = Color.Gainsboro;
			btnThoat.ForeColor = Color.Black;
			btnThoat.Location = new Point(934, 32);
			btnThoat.Name = "btnThoat";
			btnThoat.Size = new Size(110, 50);
			btnThoat.TabIndex = 23;
			btnThoat.Text = "Thoát";
			btnThoat.UseVisualStyleBackColor = false;
			btnThoat.Click += btnThoat_Click;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.BackColor = Color.PaleGreen;
			label11.Location = new Point(12, 127);
			label11.Name = "label11";
			label11.Size = new Size(85, 20);
			label11.TabIndex = 24;
			label11.Text = "Chọn tháng";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.BackColor = Color.Gainsboro;
			label12.ForeColor = Color.DeepPink;
			label12.Location = new Point(663, 71);
			label12.Name = "label12";
			label12.Size = new Size(146, 20);
			label12.TabIndex = 25;
			label12.Text = "ĐIỀU CHỈNH LƯƠNG";
			// 
			// btnXuatExcel
			// 
			btnXuatExcel.BackColor = Color.Gainsboro;
			btnXuatExcel.ForeColor = Color.Black;
			btnXuatExcel.Location = new Point(794, 360);
			btnXuatExcel.Name = "btnXuatExcel";
			btnXuatExcel.Size = new Size(119, 50);
			btnXuatExcel.TabIndex = 26;
			btnXuatExcel.Text = "In Bảng Lương";
			btnXuatExcel.UseVisualStyleBackColor = false;
			btnXuatExcel.Click += btnXuatExcel_Click;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.BackColor = Color.Gainsboro;
			label13.ForeColor = Color.DeepPink;
			label13.Location = new Point(103, 71);
			label13.Name = "label13";
			label13.Size = new Size(192, 20);
			label13.TabIndex = 27;
			label13.Text = " THÔNG TIN NHẬN LƯƠNG";
			// 
			// FormLuong
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			ClientSize = new Size(1056, 713);
			Controls.Add(label13);
			Controls.Add(btnXuatExcel);
			Controls.Add(label12);
			Controls.Add(label11);
			Controls.Add(btnThoat);
			Controls.Add(btnDieuChinh);
			Controls.Add(label10);
			Controls.Add(label9);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(txtGhiChu);
			Controls.Add(txtKyLuat);
			Controls.Add(txtThuong);
			Controls.Add(txtPhuCap);
			Controls.Add(txtTongLuong);
			Controls.Add(txtNgayCong);
			Controls.Add(txtLuongCoBan);
			Controls.Add(txtTenNV);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(txtMaNV);
			Controls.Add(label1);
			Controls.Add(dgvLuong);
			Controls.Add(btnTinhLuong);
			Controls.Add(dtpThangNam);
			ForeColor = Color.Black;
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormLuong";
			Text = "FormLuong";
			Load += FormLuong_Load;
			Click += FormLuong_Load;
			((System.ComponentModel.ISupportInitialize)dgvLuong).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DateTimePicker dtpThangNam;
        private Button btnTinhLuong;
        private DataGridView dgvLuong;
        private Label label1;
        private TextBox txtMaNV;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTenNV;
        private TextBox txtLuongCoBan;
        private TextBox txtNgayCong;
        private TextBox txtTongLuong;
        private TextBox txtPhuCap;
        private TextBox txtThuong;
        private TextBox txtKyLuat;
        private TextBox txtGhiChu;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnDieuChinh;
        private Button btnThoat;
        private Label label11;
        private Label label12;
		private Button btnXuatExcel;
		private Label label13;
	}
}