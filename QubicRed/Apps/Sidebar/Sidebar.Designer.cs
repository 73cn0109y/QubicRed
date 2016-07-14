namespace QubicRed.Apps
{
	partial class Sidebar
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
			this.DateLabel = new System.Windows.Forms.Label();
			this.TimeLabel = new System.Windows.Forms.Label();
			this.WeatherContainer = new System.Windows.Forms.Panel();
			this.CalendarContainer = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// DateLabel
			// 
			this.DateLabel.AutoSize = true;
			this.DateLabel.BackColor = System.Drawing.Color.Transparent;
			this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.DateLabel.Location = new System.Drawing.Point(12, 9);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(179, 17);
			this.DateLabel.TabIndex = 0;
			this.DateLabel.Text = "July 2016, Thursday 14";
			// 
			// TimeLabel
			// 
			this.TimeLabel.AutoSize = true;
			this.TimeLabel.BackColor = System.Drawing.Color.Transparent;
			this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.TimeLabel.Location = new System.Drawing.Point(12, 30);
			this.TimeLabel.Name = "TimeLabel";
			this.TimeLabel.Size = new System.Drawing.Size(53, 13);
			this.TimeLabel.TabIndex = 1;
			this.TimeLabel.Text = "00:00 PM";
			// 
			// WeatherContainer
			// 
			this.WeatherContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WeatherContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.WeatherContainer.Location = new System.Drawing.Point(0, 60);
			this.WeatherContainer.Name = "WeatherContainer";
			this.WeatherContainer.Size = new System.Drawing.Size(300, 100);
			this.WeatherContainer.TabIndex = 2;
			// 
			// CalendarContainer
			// 
			this.CalendarContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CalendarContainer.BackColor = System.Drawing.Color.Transparent;
			this.CalendarContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.CalendarContainer.Location = new System.Drawing.Point(0, 175);
			this.CalendarContainer.Name = "CalendarContainer";
			this.CalendarContainer.Size = new System.Drawing.Size(300, 200);
			this.CalendarContainer.TabIndex = 3;
			// 
			// Sidebar
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(300, 600);
			this.ControlBox = false;
			this.Controls.Add(this.CalendarContainer);
			this.Controls.Add(this.WeatherContainer);
			this.Controls.Add(this.TimeLabel);
			this.Controls.Add(this.DateLabel);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 600);
			this.Name = "Sidebar";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Sidebar";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.Label TimeLabel;
		private System.Windows.Forms.Panel WeatherContainer;
		private System.Windows.Forms.Panel CalendarContainer;
	}
}