namespace QubicRed
{
	partial class Boot
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Boot));
			this.BootLoopGIF = new System.Windows.Forms.PictureBox();
			this.LoadingText = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BootLoopGIF)).BeginInit();
			this.SuspendLayout();
			// 
			// BootLoopGIF
			// 
			this.BootLoopGIF.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.BootLoopGIF.BackColor = System.Drawing.Color.Transparent;
			this.BootLoopGIF.Image = ((System.Drawing.Image)(resources.GetObject("BootLoopGIF.Image")));
			this.BootLoopGIF.Location = new System.Drawing.Point(300, 240);
			this.BootLoopGIF.Name = "BootLoopGIF";
			this.BootLoopGIF.Size = new System.Drawing.Size(200, 120);
			this.BootLoopGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.BootLoopGIF.TabIndex = 0;
			this.BootLoopGIF.TabStop = false;
			// 
			// LoadingText
			// 
			this.LoadingText.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoadingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LoadingText.Location = new System.Drawing.Point(297, 363);
			this.LoadingText.Name = "LoadingText";
			this.LoadingText.Size = new System.Drawing.Size(203, 23);
			this.LoadingText.TabIndex = 1;
			this.LoadingText.Text = "Loading...";
			this.LoadingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Boot
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.LoadingText);
			this.Controls.Add(this.BootLoopGIF);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Boot";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Boot";
			((System.ComponentModel.ISupportInitialize)(this.BootLoopGIF)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox BootLoopGIF;
		private System.Windows.Forms.Label LoadingText;
	}
}