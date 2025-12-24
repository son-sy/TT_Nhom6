namespace QuanLyNhanSu
{
	partial class FormDoiMatKhau
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoiMatKhau));
			txtMatKhauCu = new TextBox();
			txtNhapLai = new TextBox();
			txtMatKhauMoi = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			btnLuu = new Button();
			btnThoat = new Button();
			label4 = new Label();
			SuspendLayout();
			// 
			// txtMatKhauCu
			// 
			txtMatKhauCu.Location = new Point(252, 88);
			txtMatKhauCu.Name = "txtMatKhauCu";
			txtMatKhauCu.PasswordChar = '*';
			txtMatKhauCu.Size = new Size(437, 27);
			txtMatKhauCu.TabIndex = 0;
			// 
			// txtNhapLai
			// 
			txtNhapLai.Location = new Point(252, 204);
			txtNhapLai.Name = "txtNhapLai";
			txtNhapLai.PasswordChar = '*';
			txtNhapLai.Size = new Size(437, 27);
			txtNhapLai.TabIndex = 3;
			// 
			// txtMatKhauMoi
			// 
			txtMatKhauMoi.Location = new Point(252, 136);
			txtMatKhauMoi.Name = "txtMatKhauMoi";
			txtMatKhauMoi.PasswordChar = '*';
			txtMatKhauMoi.Size = new Size(437, 27);
			txtMatKhauMoi.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.PaleGreen;
			label1.Location = new Point(53, 91);
			label1.Name = "label1";
			label1.Size = new Size(96, 20);
			label1.TabIndex = 5;
			label1.Text = "Mật Khẩu Cũ:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.PaleGreen;
			label2.Location = new Point(53, 143);
			label2.Name = "label2";
			label2.Size = new Size(105, 20);
			label2.TabIndex = 6;
			label2.Text = "Mật Khẩu Mới:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.PaleGreen;
			label3.Location = new Point(53, 207);
			label3.Name = "label3";
			label3.Size = new Size(168, 20);
			label3.TabIndex = 7;
			label3.Text = "Nhập Lại Mật Khẩu Mới:";
			// 
			// btnLuu
			// 
			btnLuu.ForeColor = Color.Black;
			btnLuu.Location = new Point(289, 274);
			btnLuu.Name = "btnLuu";
			btnLuu.Size = new Size(116, 51);
			btnLuu.TabIndex = 8;
			btnLuu.Text = "Lưu thay đổi";
			btnLuu.UseVisualStyleBackColor = true;
			btnLuu.Click += btnLuu_Click;
			// 
			// btnThoat
			// 
			btnThoat.ForeColor = Color.Black;
			btnThoat.Location = new Point(508, 274);
			btnThoat.Name = "btnThoat";
			btnThoat.Size = new Size(119, 51);
			btnThoat.TabIndex = 9;
			btnThoat.Text = "Thoát";
			btnThoat.UseVisualStyleBackColor = true;
			btnThoat.Click += btnThoat_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.Gainsboro;
			label4.ForeColor = Color.DeepPink;
			label4.Location = new Point(385, 23);
			label4.Name = "label4";
			label4.Size = new Size(195, 20);
			label4.TabIndex = 10;
			label4.Text = "ĐỔI MẬT KHẨU TÀI KHOẢN";
			// 
			// FormDoiMatKhau
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Gainsboro;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			ClientSize = new Size(905, 450);
			Controls.Add(label4);
			Controls.Add(btnThoat);
			Controls.Add(btnLuu);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(txtMatKhauMoi);
			Controls.Add(txtNhapLai);
			Controls.Add(txtMatKhauCu);
			ForeColor = Color.Black;
			Name = "FormDoiMatKhau";
			Text = "FormDoiMatKhau";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtMatKhauCu;
		private TextBox txtNhapLai;
		private TextBox txtMatKhauMoi;
		private Label label1;
		private Label label2;
		private Label label3;
		private Button btnLuu;
		private Button btnThoat;
		private Label label4;
	}
}