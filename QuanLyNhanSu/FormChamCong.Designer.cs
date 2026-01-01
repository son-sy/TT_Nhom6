namespace QuanLyNhanSu
{
    partial class FormChamCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChamCong));
            dgvChamCong = new DataGridView();
            label2 = new Label();
            dtpThangNam = new DateTimePicker();
            txtSoNgayCong = new TextBox();
            txtGhiChu = new TextBox();
            btnLuu = new Button();
            btnXoa = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnThoat = new Button();
            btnDiemDanh = new Button();
            cboNhanVien = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();
            // 
            // dgvChamCong
            // 
            dgvChamCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChamCong.Location = new Point(0, 341);
            dgvChamCong.Margin = new Padding(3, 4, 3, 4);
            dgvChamCong.Name = "dgvChamCong";
            dgvChamCong.RowHeadersWidth = 51;
            dgvChamCong.Size = new Size(1199, 394);
            dgvChamCong.TabIndex = 4;
            dgvChamCong.CellClick += dgvChamCong_CellClick;
            dgvChamCong.CellContentClick += dgvChamCong_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PaleGreen;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(521, 9);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 5;
            label2.Text = "QUẢN LÝ CHẤM CÔNG";
            // 
            // dtpThangNam
            // 
            dtpThangNam.CustomFormat = "MM/yyyy";
            dtpThangNam.Format = DateTimePickerFormat.Custom;
            dtpThangNam.Location = new Point(157, 138);
            dtpThangNam.Name = "dtpThangNam";
            dtpThangNam.Size = new Size(413, 27);
            dtpThangNam.TabIndex = 7;
            // 
            // txtSoNgayCong
            // 
            txtSoNgayCong.Location = new Point(157, 200);
            txtSoNgayCong.Name = "txtSoNgayCong";
            txtSoNgayCong.Size = new Size(413, 27);
            txtSoNgayCong.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(157, 263);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(413, 27);
            txtGhiChu.TabIndex = 9;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Gainsboro;
            btnLuu.Location = new Point(596, 184);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(143, 59);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Gainsboro;
            btnXoa.Location = new Point(765, 184);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(144, 59);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PaleGreen;
            label1.Location = new Point(18, 71);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 12;
            label1.Text = "Mã nhân viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PaleGreen;
            label3.Location = new Point(21, 143);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 13;
            label3.Text = "Chọn tháng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.PaleGreen;
            label4.Location = new Point(21, 207);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 14;
            label4.Text = "Số ngày công";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.PaleGreen;
            label5.Location = new Point(21, 266);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 15;
            label5.Text = "Ghi chú";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Gainsboro;
            btnThoat.Location = new Point(765, 263);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(144, 58);
            btnThoat.TabIndex = 16;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.TextChanged += btnThoat_Click;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDiemDanh
            // 
            btnDiemDanh.BackColor = Color.Gainsboro;
            btnDiemDanh.Location = new Point(596, 263);
            btnDiemDanh.Name = "btnDiemDanh";
            btnDiemDanh.Size = new Size(136, 56);
            btnDiemDanh.TabIndex = 21;
            btnDiemDanh.Text = "Điểm danh";
            btnDiemDanh.UseVisualStyleBackColor = false;
            btnDiemDanh.Click += btnDiemDanh_Click;
            // 
            // cboNhanVien
            // 
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(157, 63);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(413, 28);
            cboNhanVien.TabIndex = 22;
            // 
            // FormChamCong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1200, 738);
            Controls.Add(cboNhanVien);
            Controls.Add(btnDiemDanh);
            Controls.Add(btnThoat);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnXoa);
            Controls.Add(btnLuu);
            Controls.Add(txtGhiChu);
            Controls.Add(txtSoNgayCong);
            Controls.Add(dtpThangNam);
            Controls.Add(label2);
            Controls.Add(dgvChamCong);
            ForeColor = Color.Black;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormChamCong";
            Load += FormChamCong_Load;
            Click += btnXoa_Click;
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvChamCong;
        private Label label2;
        private DateTimePicker dtpThangNam;
        private TextBox txtSoNgayCong;
        private TextBox txtGhiChu;
        private Button btnLuu;
        private Button btnXoa;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnThoat;
        private Button btnDiemDanh;
		private ComboBox cboNhanVien;
	}
}