namespace QuanLyNhanSu
{
    partial class FormTK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTK));
            cboNhanVien = new ComboBox();
            txtTenTK = new TextBox();
            txtMatKhau = new TextBox();
            cboVaiTro = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dgvTaiKhoan = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Matkhau = new Label();
            label4 = new Label();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();
            // 
            // cboNhanVien
            // 
            cboNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(157, 104);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(233, 28);
            cboNhanVien.Sorted = true;
            cboNhanVien.TabIndex = 0;
            // 
            // txtTenTK
            // 
            txtTenTK.Location = new Point(157, 189);
            txtTenTK.Name = "txtTenTK";
            txtTenTK.Size = new Size(233, 27);
            txtTenTK.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(547, 189);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(270, 27);
            txtMatKhau.TabIndex = 2;
            // 
            // cboVaiTro
            // 
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Items.AddRange(new object[] { "Admin", "Quản lý", "Nhân viên" });
            cboVaiTro.Location = new Point(547, 102);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(270, 28);
            cboVaiTro.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Gainsboro;
            btnThem.ForeColor = Color.Black;
            btnThem.Location = new Point(44, 247);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(129, 56);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm tài khoản";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Gainsboro;
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(547, 247);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(129, 56);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa tài khoản";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Gainsboro;
            btnXoa.ForeColor = Color.Black;
            btnXoa.Location = new Point(261, 247);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(129, 56);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa tài khoản";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Location = new Point(2, 318);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.Size = new Size(899, 309);
            dgvTaiKhoan.TabIndex = 8;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PaleGreen;
            label1.Location = new Point(26, 112);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 9;
            label1.Text = "Tên nhân viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.PaleGreen;
            label2.Location = new Point(26, 192);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 10;
            label2.Text = "Tên TK:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.PaleGreen;
            label3.Location = new Point(442, 102);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 11;
            label3.Text = "Vai trò";
            // 
            // Matkhau
            // 
            Matkhau.AutoSize = true;
            Matkhau.BackColor = Color.PaleGreen;
            Matkhau.Location = new Point(442, 196);
            Matkhau.Name = "Matkhau";
            Matkhau.Size = new Size(73, 20);
            Matkhau.TabIndex = 12;
            Matkhau.Text = "Mật khẩu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Gainsboro;
            label4.ForeColor = Color.DeepPink;
            label4.Location = new Point(386, 27);
            label4.Name = "label4";
            label4.Size = new Size(150, 20);
            label4.TabIndex = 13;
            label4.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Gainsboro;
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(739, 247);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(129, 56);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // FormTK
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(902, 628);
            Controls.Add(btnThoat);
            Controls.Add(label4);
            Controls.Add(Matkhau);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvTaiKhoan);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboVaiTro);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenTK);
            Controls.Add(cboNhanVien);
            ForeColor = Color.Black;
            Name = "FormTK";
            Text = "FormTK";
            Load += FormTaiKhoan_Load;
            Click += btnThoat_Click;
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboNhanVien;
        private TextBox txtTenTK;
        private TextBox txtMatKhau;
        private ComboBox cboVaiTro;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dgvTaiKhoan;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label Matkhau;
		private Label label4;
		private Button btnThoat;
	}
}