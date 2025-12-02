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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtIdNV = new TextBox();
            txtGioLam = new TextBox();
            txtLuongCB = new TextBox();
            txtNam = new TextBox();
            txtThang = new TextBox();
            label6 = new Label();
            lblTongLuong = new Label();
            dgvLuong = new DataGridView();
            btnTinhLuong = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLuong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 30);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 67);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 1;
            label2.Text = "Tháng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 103);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 2;
            label3.Text = "Năm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 139);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 3;
            label4.Text = "Lương cơ bản";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 178);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 4;
            label5.Text = "Số giờ làm";
            // 
            // txtIdNV
            // 
            txtIdNV.Location = new Point(126, 27);
            txtIdNV.Name = "txtIdNV";
            txtIdNV.Size = new Size(100, 23);
            txtIdNV.TabIndex = 5;
            // 
            // txtGioLam
            // 
            txtGioLam.Location = new Point(126, 175);
            txtGioLam.Name = "txtGioLam";
            txtGioLam.Size = new Size(100, 23);
            txtGioLam.TabIndex = 6;
            // 
            // txtLuongCB
            // 
            txtLuongCB.Location = new Point(126, 136);
            txtLuongCB.Name = "txtLuongCB";
            txtLuongCB.Size = new Size(100, 23);
            txtLuongCB.TabIndex = 7;
            // 
            // txtNam
            // 
            txtNam.Location = new Point(126, 100);
            txtNam.Name = "txtNam";
            txtNam.Size = new Size(100, 23);
            txtNam.TabIndex = 8;
            // 
            // txtThang
            // 
            txtThang.Location = new Point(126, 64);
            txtThang.Name = "txtThang";
            txtThang.Size = new Size(100, 23);
            txtThang.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(338, 30);
            label6.Name = "label6";
            label6.Size = new Size(123, 15);
            label6.TabIndex = 10;
            label6.Text = "TỔNG LƯƠNG NHẬN:";
            // 
            // lblTongLuong
            // 
            lblTongLuong.AutoSize = true;
            lblTongLuong.Location = new Point(499, 30);
            lblTongLuong.Name = "lblTongLuong";
            lblTongLuong.Size = new Size(38, 15);
            lblTongLuong.TabIndex = 11;
            lblTongLuong.Text = "label7";
            // 
            // dgvLuong
            // 
            dgvLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLuong.Location = new Point(338, 78);
            dgvLuong.Name = "dgvLuong";
            dgvLuong.Size = new Size(240, 150);
            dgvLuong.TabIndex = 12;
            dgvLuong.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnTinhLuong
            // 
            btnTinhLuong.Location = new Point(41, 218);
            btnTinhLuong.Name = "btnTinhLuong";
            btnTinhLuong.Size = new Size(75, 23);
            btnTinhLuong.TabIndex = 13;
            btnTinhLuong.Text = "Tính Lương";
            btnTinhLuong.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(135, 218);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(91, 23);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa Lương";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 276);
            Controls.Add(btnXoa);
            Controls.Add(btnTinhLuong);
            Controls.Add(dgvLuong);
            Controls.Add(lblTongLuong);
            Controls.Add(label6);
            Controls.Add(txtThang);
            Controls.Add(txtNam);
            Controls.Add(txtLuongCB);
            Controls.Add(txtGioLam);
            Controls.Add(txtIdNV);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)dgvLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtIdNV;
        private TextBox txtGioLam;
        private TextBox txtLuongCB;
        private TextBox txtNam;
        private TextBox txtThang;
        private Label label6;
        private Label lblTongLuong;
        private DataGridView dgvLuong;
        private Button btnTinhLuong;
        private Button btnXoa;
    }
}