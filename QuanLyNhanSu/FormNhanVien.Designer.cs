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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			txtHoTen = new TextBox();
			txtChucVu = new TextBox();
			txtPhongBan = new TextBox();
			txtEmail = new TextBox();
			txtSDT = new TextBox();
			txtDiaChi = new TextBox();
			dtpNgaySinh = new DateTimePicker();
			dgvNhanVien = new DataGridView();
			btnThem = new Button();
			btnSua = new Button();
			btnXoa = new Button();
			grpGioiTinh = new GroupBox();
			rbNu = new RadioButton();
			rbNam = new RadioButton();
			((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
			grpGioiTinh.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(47, 45);
			label1.Name = "label1";
			label1.Size = new Size(56, 20);
			label1.TabIndex = 0;
			label1.Text = "Họ Tên";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(433, 341);
			label2.Name = "label2";
			label2.Size = new Size(63, 20);
			label2.TabIndex = 1;
			label2.Text = "Chức Vụ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(47, 101);
			label3.Name = "label3";
			label3.Size = new Size(55, 20);
			label3.TabIndex = 2;
			label3.Text = "Địa chỉ";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(47, 152);
			label4.Name = "label4";
			label4.Size = new Size(35, 20);
			label4.TabIndex = 3;
			label4.Text = "SDT";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(47, 200);
			label5.Name = "label5";
			label5.Size = new Size(46, 20);
			label5.TabIndex = 4;
			label5.Text = "Email";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(433, 285);
			label6.Name = "label6";
			label6.Size = new Size(80, 20);
			label6.TabIndex = 5;
			label6.Text = "Phòng Ban";
			label6.Click += label6_Click;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(47, 257);
			label7.Name = "label7";
			label7.Size = new Size(76, 20);
			label7.TabIndex = 6;
			label7.Text = "Ngày Sinh";
			// 
			// txtHoTen
			// 
			txtHoTen.Location = new Point(158, 41);
			txtHoTen.Margin = new Padding(3, 4, 3, 4);
			txtHoTen.Name = "txtHoTen";
			txtHoTen.Size = new Size(143, 27);
			txtHoTen.TabIndex = 7;
			// 
			// txtChucVu
			// 
			txtChucVu.Location = new Point(544, 337);
			txtChucVu.Margin = new Padding(3, 4, 3, 4);
			txtChucVu.Name = "txtChucVu";
			txtChucVu.Size = new Size(114, 27);
			txtChucVu.TabIndex = 8;
			// 
			// txtPhongBan
			// 
			txtPhongBan.Location = new Point(544, 281);
			txtPhongBan.Margin = new Padding(3, 4, 3, 4);
			txtPhongBan.Name = "txtPhongBan";
			txtPhongBan.Size = new Size(114, 27);
			txtPhongBan.TabIndex = 9;
			// 
			// txtEmail
			// 
			txtEmail.Location = new Point(158, 196);
			txtEmail.Margin = new Padding(3, 4, 3, 4);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new Size(143, 27);
			txtEmail.TabIndex = 10;
			// 
			// txtSDT
			// 
			txtSDT.Location = new Point(158, 148);
			txtSDT.Margin = new Padding(3, 4, 3, 4);
			txtSDT.Name = "txtSDT";
			txtSDT.Size = new Size(143, 27);
			txtSDT.TabIndex = 11;
			// 
			// txtDiaChi
			// 
			txtDiaChi.Location = new Point(158, 97);
			txtDiaChi.Margin = new Padding(3, 4, 3, 4);
			txtDiaChi.Name = "txtDiaChi";
			txtDiaChi.Size = new Size(143, 27);
			txtDiaChi.TabIndex = 12;
			txtDiaChi.TextChanged += txtDiaChi_TextChanged;
			// 
			// dtpNgaySinh
			// 
			dtpNgaySinh.Location = new Point(158, 249);
			dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
			dtpNgaySinh.Name = "dtpNgaySinh";
			dtpNgaySinh.Size = new Size(228, 27);
			dtpNgaySinh.TabIndex = 13;
			// 
			// dgvNhanVien
			// 
			dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvNhanVien.Location = new Point(364, 45);
			dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
			dgvNhanVien.Name = "dgvNhanVien";
			dgvNhanVien.RowHeadersWidth = 51;
			dgvNhanVien.Size = new Size(385, 200);
			dgvNhanVien.TabIndex = 14;
			// 
			// btnThem
			// 
			btnThem.Location = new Point(386, 432);
			btnThem.Margin = new Padding(3, 4, 3, 4);
			btnThem.Name = "btnThem";
			btnThem.Size = new Size(86, 31);
			btnThem.TabIndex = 15;
			btnThem.Text = "Thêm";
			btnThem.UseVisualStyleBackColor = true;
			// 
			// btnSua
			// 
			btnSua.Location = new Point(505, 432);
			btnSua.Margin = new Padding(3, 4, 3, 4);
			btnSua.Name = "btnSua";
			btnSua.Size = new Size(86, 31);
			btnSua.TabIndex = 16;
			btnSua.Text = "Sửa";
			btnSua.UseVisualStyleBackColor = true;
			// 
			// btnXoa
			// 
			btnXoa.Location = new Point(622, 432);
			btnXoa.Margin = new Padding(3, 4, 3, 4);
			btnXoa.Name = "btnXoa";
			btnXoa.Size = new Size(86, 31);
			btnXoa.TabIndex = 17;
			btnXoa.Text = "Xóa";
			btnXoa.UseVisualStyleBackColor = true;
			btnXoa.Click += btnXoa_Click;
			// 
			// grpGioiTinh
			// 
			grpGioiTinh.Controls.Add(rbNu);
			grpGioiTinh.Controls.Add(rbNam);
			grpGioiTinh.Location = new Point(47, 312);
			grpGioiTinh.Margin = new Padding(3, 4, 3, 4);
			grpGioiTinh.Name = "grpGioiTinh";
			grpGioiTinh.Padding = new Padding(3, 4, 3, 4);
			grpGioiTinh.Size = new Size(158, 121);
			grpGioiTinh.TabIndex = 19;
			grpGioiTinh.TabStop = false;
			grpGioiTinh.Text = "Giới tính";
			// 
			// rbNu
			// 
			rbNu.AutoSize = true;
			rbNu.Location = new Point(19, 79);
			rbNu.Margin = new Padding(3, 4, 3, 4);
			rbNu.Name = "rbNu";
			rbNu.Size = new Size(50, 24);
			rbNu.TabIndex = 1;
			rbNu.TabStop = true;
			rbNu.Text = "Nữ";
			rbNu.UseVisualStyleBackColor = true;
			// 
			// rbNam
			// 
			rbNam.AutoSize = true;
			rbNam.Location = new Point(19, 32);
			rbNam.Margin = new Padding(3, 4, 3, 4);
			rbNam.Name = "rbNam";
			rbNam.Size = new Size(62, 24);
			rbNam.TabIndex = 0;
			rbNam.TabStop = true;
			rbNam.Text = "Nam";
			rbNam.UseVisualStyleBackColor = true;
			// 
			// FormNhanVien
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(761, 480);
			Controls.Add(grpGioiTinh);
			Controls.Add(btnXoa);
			Controls.Add(btnSua);
			Controls.Add(btnThem);
			Controls.Add(dgvNhanVien);
			Controls.Add(dtpNgaySinh);
			Controls.Add(txtDiaChi);
			Controls.Add(txtSDT);
			Controls.Add(txtEmail);
			Controls.Add(txtPhongBan);
			Controls.Add(txtChucVu);
			Controls.Add(txtHoTen);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormNhanVien";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
			grpGioiTinh.ResumeLayout(false);
			grpGioiTinh.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtHoTen;
        private TextBox txtChucVu;
        private TextBox txtPhongBan;
        private TextBox txtEmail;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private DateTimePicker dtpNgaySinh;
        private DataGridView dgvNhanVien;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private GroupBox grpGioiTinh;
        private RadioButton rbNu;
        private RadioButton rbNam;
    }
}
