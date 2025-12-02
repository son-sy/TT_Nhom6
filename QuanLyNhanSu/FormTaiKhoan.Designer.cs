namespace QuanLyNhanSu
{
    partial class FormTaiKhoan
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtIdNV = new TextBox();
            txtPass = new TextBox();
            txtUser = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dgvTaiKhoan = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 34);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 79);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên Đăng Nhập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 128);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Mật Khẩu";
            // 
            // txtIdNV
            // 
            txtIdNV.Location = new Point(145, 31);
            txtIdNV.Name = "txtIdNV";
            txtIdNV.Size = new Size(100, 23);
            txtIdNV.TabIndex = 3;
            txtIdNV.TextChanged += textBox1_TextChanged;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(145, 125);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(100, 23);
            txtPass.TabIndex = 4;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(145, 79);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(100, 23);
            txtUser.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(268, 218);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(70, 24);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm TK";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(366, 218);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(70, 24);
            btnSua.TabIndex = 7;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(458, 218);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(70, 24);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Location = new Point(298, 31);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.Size = new Size(240, 150);
            dgvTaiKhoan.TabIndex = 9;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 271);
            Controls.Add(dgvTaiKhoan);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtUser);
            Controls.Add(txtPass);
            Controls.Add(txtIdNV);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtIdNV;
        private TextBox txtPass;
        private TextBox txtUser;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dgvTaiKhoan;
    }
}