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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtIdNV = new TextBox();
            txtTrangThai = new TextBox();
            dtpBatDau = new DateTimePicker();
            dtpKetThuc = new DateTimePicker();
            x = new Button();
            btnXoa = new Button();
            dgvNghiPhep = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNghiPhep).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 28);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 66);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 1;
            label2.Text = "Từ ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(356, 66);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Đến ngày";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(356, 28);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 3;
            label4.Text = "Lý do";
            // 
            // txtIdNV
            // 
            txtIdNV.Location = new Point(132, 25);
            txtIdNV.Name = "txtIdNV";
            txtIdNV.Size = new Size(100, 23);
            txtIdNV.TabIndex = 4;
            // 
            // txtTrangThai
            // 
            txtTrangThai.Location = new Point(447, 25);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.Size = new Size(100, 23);
            txtTrangThai.TabIndex = 5;
            // 
            // dtpBatDau
            // 
            dtpBatDau.Location = new Point(132, 60);
            dtpBatDau.Name = "dtpBatDau";
            dtpBatDau.Size = new Size(200, 23);
            dtpBatDau.TabIndex = 6;
            // 
            // dtpKetThuc
            // 
            dtpKetThuc.Location = new Point(447, 60);
            dtpKetThuc.Name = "dtpKetThuc";
            dtpKetThuc.Size = new Size(200, 23);
            dtpKetThuc.TabIndex = 7;
            // 
            // x
            // 
            x.Location = new Point(544, 221);
            x.Name = "x";
            x.Size = new Size(75, 23);
            x.TabIndex = 8;
            x.Text = "Nộp đơn";
            x.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(544, 275);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Hủy đơn";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // dgvNghiPhep
            // 
            dgvNghiPhep.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNghiPhep.Location = new Point(41, 118);
            dgvNghiPhep.Name = "dgvNghiPhep";
            dgvNghiPhep.Size = new Size(291, 180);
            dgvNghiPhep.TabIndex = 10;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 329);
            Controls.Add(dgvNghiPhep);
            Controls.Add(btnXoa);
            Controls.Add(x);
            Controls.Add(dtpKetThuc);
            Controls.Add(dtpBatDau);
            Controls.Add(txtTrangThai);
            Controls.Add(txtIdNV);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)dgvNghiPhep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtIdNV;
        private TextBox txtTrangThai;
        private DateTimePicker dtpBatDau;
        private DateTimePicker dtpKetThuc;
        private Button x;
        private Button btnXoa;
        private DataGridView dgvNghiPhep;
    }
}