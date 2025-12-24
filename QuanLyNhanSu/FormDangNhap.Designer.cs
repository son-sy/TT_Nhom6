namespace QuanLyNhanSu
{
	partial class FormDangNhap
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			chkHienMatKhau = new CheckBox();
			btnDangNhap = new Button();
			txtTaiKhoan = new TextBox();
			txtMatKhau = new TextBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.Gainsboro;
			label1.Font = new Font("Segoe UI", 18F);
			label1.ForeColor = Color.DeepPink;
			label1.Location = new Point(369, 48);
			label1.Name = "label1";
			label1.Size = new Size(188, 41);
			label1.TabIndex = 0;
			label1.Text = "ĐĂNG NHẬP";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.PaleGreen;
			label2.ForeColor = Color.Black;
			label2.Location = new Point(135, 165);
			label2.Name = "label2";
			label2.Size = new Size(107, 20);
			label2.TabIndex = 1;
			label2.Text = "Tên đăng nhập";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.PaleGreen;
			label3.ForeColor = Color.Black;
			label3.Location = new Point(135, 233);
			label3.Name = "label3";
			label3.Size = new Size(70, 20);
			label3.TabIndex = 2;
			label3.Text = "Mật khẩu";
			// 
			// chkHienMatKhau
			// 
			chkHienMatKhau.AutoSize = true;
			chkHienMatKhau.BackColor = Color.White;
			chkHienMatKhau.ForeColor = Color.DodgerBlue;
			chkHienMatKhau.Location = new Point(276, 272);
			chkHienMatKhau.Name = "chkHienMatKhau";
			chkHienMatKhau.Size = new Size(127, 24);
			chkHienMatKhau.TabIndex = 3;
			chkHienMatKhau.Text = "Hiện mật khẩu";
			chkHienMatKhau.UseVisualStyleBackColor = false;
			chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
			// 
			// btnDangNhap
			// 
			btnDangNhap.BackColor = Color.Gainsboro;
			btnDangNhap.ForeColor = Color.DeepPink;
			btnDangNhap.Location = new Point(298, 337);
			btnDangNhap.Name = "btnDangNhap";
			btnDangNhap.Size = new Size(315, 74);
			btnDangNhap.TabIndex = 4;
			btnDangNhap.Text = "Đăng nhập";
			btnDangNhap.UseVisualStyleBackColor = false;
			btnDangNhap.Click += btnDangNhap_Click;
			// 
			// txtTaiKhoan
			// 
			txtTaiKhoan.Location = new Point(276, 158);
			txtTaiKhoan.Name = "txtTaiKhoan";
			txtTaiKhoan.Size = new Size(374, 27);
			txtTaiKhoan.TabIndex = 5;
			// 
			// txtMatKhau
			// 
			txtMatKhau.Location = new Point(276, 226);
			txtMatKhau.Name = "txtMatKhau";
			txtMatKhau.Size = new Size(374, 27);
			txtMatKhau.TabIndex = 6;
			// 
			// FormDangNhap
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.PaleGreen;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			ClientSize = new Size(905, 450);
			Controls.Add(txtMatKhau);
			Controls.Add(txtTaiKhoan);
			Controls.Add(btnDangNhap);
			Controls.Add(chkHienMatKhau);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			ForeColor = Color.Black;
			Name = "FormDangNhap";
			Text = "FormDangNhap";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private CheckBox chkHienMatKhau;
		private Button btnDangNhap;
		private TextBox txtTaiKhoan;
		private TextBox txtMatKhau;
	}
}