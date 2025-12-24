namespace QuanLyNhanSu
{
    partial class FormNghiPhep
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNghiPhep));
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			txtMaNV = new TextBox();
			txtLyDo = new TextBox();
			dtpTuNgay = new DateTimePicker();
			dtpDenNgay = new DateTimePicker();
			btnNopDon = new Button();
			btnHuyDon = new Button();
			dgvNghiPhep = new DataGridView();
			cboLoaiNghi = new ComboBox();
			label5 = new Label();
			btnDuyet = new Button();
			btnTuChoi = new Button();
			label6 = new Label();
			btnThoat = new Button();
			((System.ComponentModel.ISupportInitialize)dgvNghiPhep).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.PaleGreen;
			label1.Location = new Point(12, 94);
			label1.Name = "label1";
			label1.Size = new Size(102, 20);
			label1.TabIndex = 0;
			label1.Text = "Mã Nhân Viên";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.PaleGreen;
			label2.Location = new Point(12, 151);
			label2.Name = "label2";
			label2.Size = new Size(62, 20);
			label2.TabIndex = 1;
			label2.Text = "Từ ngày";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.PaleGreen;
			label3.Location = new Point(416, 151);
			label3.Name = "label3";
			label3.Size = new Size(72, 20);
			label3.TabIndex = 2;
			label3.Text = "Đến ngày";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.PaleGreen;
			label4.Location = new Point(416, 94);
			label4.Name = "label4";
			label4.Size = new Size(44, 20);
			label4.TabIndex = 3;
			label4.Text = "Lý do";
			// 
			// txtMaNV
			// 
			txtMaNV.Location = new Point(128, 87);
			txtMaNV.Margin = new Padding(3, 4, 3, 4);
			txtMaNV.Name = "txtMaNV";
			txtMaNV.Size = new Size(228, 27);
			txtMaNV.TabIndex = 4;
			// 
			// txtLyDo
			// 
			txtLyDo.Location = new Point(522, 87);
			txtLyDo.Margin = new Padding(3, 4, 3, 4);
			txtLyDo.Name = "txtLyDo";
			txtLyDo.Size = new Size(221, 27);
			txtLyDo.TabIndex = 5;
			// 
			// dtpTuNgay
			// 
			dtpTuNgay.Location = new Point(128, 144);
			dtpTuNgay.Margin = new Padding(3, 4, 3, 4);
			dtpTuNgay.Name = "dtpTuNgay";
			dtpTuNgay.Size = new Size(228, 27);
			dtpTuNgay.TabIndex = 6;
			// 
			// dtpDenNgay
			// 
			dtpDenNgay.Location = new Point(522, 144);
			dtpDenNgay.Margin = new Padding(3, 4, 3, 4);
			dtpDenNgay.Name = "dtpDenNgay";
			dtpDenNgay.Size = new Size(228, 27);
			dtpDenNgay.TabIndex = 7;
			// 
			// btnNopDon
			// 
			btnNopDon.BackColor = Color.Gainsboro;
			btnNopDon.Location = new Point(1063, 219);
			btnNopDon.Margin = new Padding(3, 4, 3, 4);
			btnNopDon.Name = "btnNopDon";
			btnNopDon.Size = new Size(133, 58);
			btnNopDon.TabIndex = 8;
			btnNopDon.Text = "Nộp đơn";
			btnNopDon.UseVisualStyleBackColor = false;
			btnNopDon.Click += btnNopDon_Click;
			// 
			// btnHuyDon
			// 
			btnHuyDon.BackColor = Color.Gainsboro;
			btnHuyDon.Location = new Point(1063, 297);
			btnHuyDon.Margin = new Padding(3, 4, 3, 4);
			btnHuyDon.Name = "btnHuyDon";
			btnHuyDon.Size = new Size(138, 58);
			btnHuyDon.TabIndex = 9;
			btnHuyDon.Text = "Hủy đơn";
			btnHuyDon.UseVisualStyleBackColor = false;
			btnHuyDon.Click += btnHuyDon_Click;
			// 
			// dgvNghiPhep
			// 
			dgvNghiPhep.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvNghiPhep.Location = new Point(1, 219);
			dgvNghiPhep.Margin = new Padding(3, 4, 3, 4);
			dgvNghiPhep.Name = "dgvNghiPhep";
			dgvNghiPhep.RowHeadersWidth = 51;
			dgvNghiPhep.Size = new Size(1056, 294);
			dgvNghiPhep.TabIndex = 10;
			dgvNghiPhep.CellClick += dgvNghiPhep_CellClick;
			// 
			// cboLoaiNghi
			// 
			cboLoaiNghi.FormattingEnabled = true;
			cboLoaiNghi.Items.AddRange(new object[] { "Nghỉ phép năm", "Nghỉ ốm", "Việc riêng" });
			cboLoaiNghi.Location = new Point(880, 86);
			cboLoaiNghi.Name = "cboLoaiNghi";
			cboLoaiNghi.Size = new Size(151, 28);
			cboLoaiNghi.TabIndex = 11;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.PaleGreen;
			label5.Location = new Point(788, 94);
			label5.Name = "label5";
			label5.Size = new Size(70, 20);
			label5.TabIndex = 12;
			label5.Text = "Loại nghỉ";
			// 
			// btnDuyet
			// 
			btnDuyet.BackColor = Color.Gainsboro;
			btnDuyet.Location = new Point(1063, 372);
			btnDuyet.Margin = new Padding(3, 4, 3, 4);
			btnDuyet.Name = "btnDuyet";
			btnDuyet.Size = new Size(138, 58);
			btnDuyet.TabIndex = 13;
			btnDuyet.Text = "Duyệt Phép";
			btnDuyet.UseVisualStyleBackColor = false;
			btnDuyet.Click += btnDuyet_Click;
			// 
			// btnTuChoi
			// 
			btnTuChoi.BackColor = Color.Gainsboro;
			btnTuChoi.Location = new Point(1063, 455);
			btnTuChoi.Margin = new Padding(3, 4, 3, 4);
			btnTuChoi.Name = "btnTuChoi";
			btnTuChoi.Size = new Size(138, 58);
			btnTuChoi.TabIndex = 14;
			btnTuChoi.Text = "Từ Chối";
			btnTuChoi.UseVisualStyleBackColor = false;
			btnTuChoi.Click += btnTuChoi_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.BackColor = Color.Gainsboro;
			label6.ForeColor = Color.DeepPink;
			label6.Location = new Point(539, 20);
			label6.Name = "label6";
			label6.Size = new Size(152, 20);
			label6.TabIndex = 15;
			label6.Text = "QUẢN LÝ NGHỈ PHÉP ";
			// 
			// btnThoat
			// 
			btnThoat.BackColor = Color.Gainsboro;
			btnThoat.Location = new Point(1068, 13);
			btnThoat.Margin = new Padding(3, 4, 3, 4);
			btnThoat.Name = "btnThoat";
			btnThoat.Size = new Size(133, 58);
			btnThoat.TabIndex = 16;
			btnThoat.Text = "Thoát";
			btnThoat.UseVisualStyleBackColor = false;
			btnThoat.Click += btnThoat_Click;
			// 
			// FormNghiPhep
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			ClientSize = new Size(1202, 516);
			Controls.Add(btnThoat);
			Controls.Add(label6);
			Controls.Add(btnTuChoi);
			Controls.Add(btnDuyet);
			Controls.Add(label5);
			Controls.Add(cboLoaiNghi);
			Controls.Add(dgvNghiPhep);
			Controls.Add(btnHuyDon);
			Controls.Add(btnNopDon);
			Controls.Add(dtpDenNgay);
			Controls.Add(dtpTuNgay);
			Controls.Add(txtLyDo);
			Controls.Add(txtMaNV);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			ForeColor = Color.Black;
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormNghiPhep";
			Text = "FormNghiPhep";
			Load += FormNghiPhep_Load;
			((System.ComponentModel.ISupportInitialize)dgvNghiPhep).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtMaNV;
        private TextBox txtLyDo;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnNopDon;
        private Button btnHuyDon;
        private DataGridView dgvNghiPhep;
        private ComboBox cboLoaiNghi;
        private Label label5;
		private Button btnDuyet;
		private Button btnTuChoi;
		private Label label6;
		private Button btnThoat;
	}
}