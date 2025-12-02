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
            label1 = new Label();
            txtIdNV = new TextBox();
            btnCheckIn = new Button();
            btnCheckOut = new Button();
            dgvChamCong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 36);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã Nhân Viên";
            // 
            // txtIdNV
            // 
            txtIdNV.Location = new Point(162, 33);
            txtIdNV.Name = "txtIdNV";
            txtIdNV.Size = new Size(100, 23);
            txtIdNV.TabIndex = 1;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(45, 101);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(104, 50);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "Check In";
            btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(45, 176);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(104, 50);
            btnCheckOut.TabIndex = 3;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // dgvChamCong
            // 
            dgvChamCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChamCong.Location = new Point(315, 33);
            dgvChamCong.Name = "dgvChamCong";
            dgvChamCong.Size = new Size(272, 212);
            dgvChamCong.TabIndex = 4;
            dgvChamCong.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 258);
            Controls.Add(dgvChamCong);
            Controls.Add(btnCheckOut);
            Controls.Add(btnCheckIn);
            Controls.Add(txtIdNV);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdNV;
        private Button btnCheckIn;
        private Button btnCheckOut;
        private DataGridView dgvChamCong;
    }
}