namespace QubicRed
{
	partial class Login
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
			this.UserAvatar = new QubicRed.CustomControls.RoundedPictureBox();
			this.UserName = new System.Windows.Forms.Label();
			this.UserGroup = new System.Windows.Forms.Panel();
			this.LoginButton = new System.Windows.Forms.Button();
			this.PasswordField = new QubicRed.CustomControls.CustomizableTextBox();
			((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).BeginInit();
			this.UserGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// UserAvatar
			// 
			this.UserAvatar.Image = null;
			this.UserAvatar.Location = new System.Drawing.Point(56, 3);
			this.UserAvatar.Name = "UserAvatar";
			this.UserAvatar.RoundCorners = QubicRed.Corners.All;
			this.UserAvatar.Size = new System.Drawing.Size(100, 100);
			this.UserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.UserAvatar.TabIndex = 0;
			this.UserAvatar.TabStop = false;
			// 
			// UserName
			// 
			this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.UserName.Location = new System.Drawing.Point(53, 106);
			this.UserName.Name = "UserName";
			this.UserName.Size = new System.Drawing.Size(103, 23);
			this.UserName.TabIndex = 1;
			this.UserName.Text = "Administrator";
			this.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UserGroup
			// 
			this.UserGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.UserGroup.BackColor = System.Drawing.Color.Transparent;
			this.UserGroup.Controls.Add(this.LoginButton);
			this.UserGroup.Controls.Add(this.PasswordField);
			this.UserGroup.Controls.Add(this.UserAvatar);
			this.UserGroup.Controls.Add(this.UserName);
			this.UserGroup.Location = new System.Drawing.Point(412, 309);
			this.UserGroup.Name = "UserGroup";
			this.UserGroup.Size = new System.Drawing.Size(210, 165);
			this.UserGroup.TabIndex = 2;
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.LoginButton.FlatAppearance.BorderSize = 0;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Location = new System.Drawing.Point(171, 132);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(25, 25);
			this.LoginButton.TabIndex = 3;
			this.LoginButton.Text = ">";
			this.LoginButton.UseVisualStyleBackColor = false;
			// 
			// PasswordField
			// 
			this.PasswordField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.PasswordField.ForeColor = System.Drawing.Color.White;
			this.PasswordField.Location = new System.Drawing.Point(15, 132);
			this.PasswordField.Name = "PasswordField";
			this.PasswordField.Size = new System.Drawing.Size(156, 25);
			this.PasswordField.TabIndex = 4;
			this.PasswordField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PasswordField.Submit += new QubicRed.CustomControls.CustomizableTextBox.OnSubmit(this.customizableTextBox1_Submit);
			// 
			// Login
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1024, 768);
			this.ControlBox = false;
			this.Controls.Add(this.UserGroup);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Login";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).EndInit();
			this.UserGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private CustomControls.RoundedPictureBox UserAvatar;
		private System.Windows.Forms.Label UserName;
		private System.Windows.Forms.Panel UserGroup;
		private CustomControls.CustomizableTextBox PasswordField;
		private System.Windows.Forms.Button LoginButton;
	}
}