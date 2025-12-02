namespace QuanLyNhanSu
{
	partial class FormTrangChu
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
			checkBox1 = new CheckBox();
			button1 = new Button();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			linkLabel1 = new LinkLabel();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 18F);
			label1.Location = new Point(326, 45);
			label1.Name = "label1";
			label1.Size = new Size(92, 41);
			label1.TabIndex = 0;
			label1.Text = "Login";
			label1.Click += label1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(213, 143);
			label2.Name = "label2";
			label2.Size = new Size(107, 20);
			label2.TabIndex = 1;
			label2.Text = "Tên đăng nhập";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(213, 205);
			label3.Name = "label3";
			label3.Size = new Size(70, 20);
			label3.TabIndex = 2;
			label3.Text = "Mật khẩu";
			label3.Click += label3_Click;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(213, 245);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(127, 24);
			checkBox1.TabIndex = 3;
			checkBox1.Text = "Hiện mật khẩu";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// button1
			// 
			button1.Location = new Point(271, 307);
			button1.Name = "button1";
			button1.Size = new Size(207, 29);
			button1.TabIndex = 4;
			button1.Text = "Đăng nhập";
			button1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(326, 136);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(202, 27);
			textBox1.TabIndex = 5;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(326, 198);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(202, 27);
			textBox2.TabIndex = 6;
			// 
			// linkLabel1
			// 
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(408, 249);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(120, 20);
			linkLabel1.TabIndex = 7;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Quên mật khẩu ?";
			// 
			// FormTrangChu
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(linkLabel1);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(button1);
			Controls.Add(checkBox1);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "FormTrangChu";
			Text = "FormLogin";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private CheckBox checkBox1;
		private Button button1;
		private TextBox textBox1;
		private TextBox textBox2;
		private LinkLabel linkLabel1;
	}
}