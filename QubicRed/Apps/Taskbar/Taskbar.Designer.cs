namespace QubicRed.Apps
{
	partial class Taskbar
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
			this.Time = new System.Windows.Forms.Label();
			this.Date = new System.Windows.Forms.Label();
			this.StartButton = new QubicRed.CustomControls.RoundedPictureBox();
			((System.ComponentModel.ISupportInitialize)(this.StartButton)).BeginInit();
			this.SuspendLayout();
			// 
			// Time
			// 
			this.Time.BackColor = System.Drawing.Color.Transparent;
			this.Time.Dock = System.Windows.Forms.DockStyle.Right;
			this.Time.Location = new System.Drawing.Point(715, 0);
			this.Time.Name = "Time";
			this.Time.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
			this.Time.Size = new System.Drawing.Size(85, 40);
			this.Time.TabIndex = 1;
			this.Time.Text = "00:00 PM";
			this.Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Date
			// 
			this.Date.BackColor = System.Drawing.Color.Transparent;
			this.Date.Dock = System.Windows.Forms.DockStyle.Right;
			this.Date.Location = new System.Drawing.Point(605, 0);
			this.Date.Name = "Date";
			this.Date.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.Date.Size = new System.Drawing.Size(110, 40);
			this.Date.TabIndex = 2;
			this.Date.Text = "Wednesday 00";
			this.Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// StartButton
			// 
			this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.StartButton.BackColor = System.Drawing.Color.Transparent;
			this.StartButton.Location = new System.Drawing.Point(5, 5);
			this.StartButton.Name = "StartButton";
			this.StartButton.RoundCorners = QubicRed.Corners.All;
			this.StartButton.Size = new System.Drawing.Size(30, 30);
			this.StartButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.StartButton.TabIndex = 0;
			this.StartButton.TabStop = false;
			this.StartButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StartButton_MouseClick);
			// 
			// Taskbar
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(800, 40);
			this.ControlBox = false;
			this.Controls.Add(this.Date);
			this.Controls.Add(this.Time);
			this.Controls.Add(this.StartButton);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 30);
			this.Name = "Taskbar";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "QubicRed - Taskbar";
			((System.ComponentModel.ISupportInitialize)(this.StartButton)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CustomControls.RoundedPictureBox StartButton;
		private System.Windows.Forms.Label Time;
		private System.Windows.Forms.Label Date;
	}
}