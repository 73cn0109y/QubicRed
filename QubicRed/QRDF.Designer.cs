namespace QubicRed
{
	partial class QRDF
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
			this.HeaderBar = new System.Windows.Forms.Panel();
			this.MinimizeButton = new System.Windows.Forms.PictureBox();
			this.StateButton = new System.Windows.Forms.PictureBox();
			this.CloseButton = new System.Windows.Forms.PictureBox();
			this.Title = new QubicRed.CustomControls.ClickThroughLabel();
			this.ExtendedBar = new System.Windows.Forms.Panel();
			this.HeaderBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StateButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
			this.SuspendLayout();
			// 
			// HeaderBar
			// 
			this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.HeaderBar.Controls.Add(this.MinimizeButton);
			this.HeaderBar.Controls.Add(this.StateButton);
			this.HeaderBar.Controls.Add(this.CloseButton);
			this.HeaderBar.Controls.Add(this.Title);
			this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.HeaderBar.ForeColor = System.Drawing.Color.White;
			this.HeaderBar.Location = new System.Drawing.Point(0, 0);
			this.HeaderBar.Name = "HeaderBar";
			this.HeaderBar.Size = new System.Drawing.Size(800, 30);
			this.HeaderBar.TabIndex = 0;
			this.HeaderBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseDoubleClick);
			this.HeaderBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseDown);
			this.HeaderBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseMove);
			this.HeaderBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseUp);
			// 
			// MinimizeButton
			// 
			this.MinimizeButton.BackColor = System.Drawing.Color.Transparent;
			this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.MinimizeButton.Image = global::QubicRed.Properties.Resources.minimize;
			this.MinimizeButton.Location = new System.Drawing.Point(650, 0);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.Size = new System.Drawing.Size(50, 30);
			this.MinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.MinimizeButton.TabIndex = 3;
			this.MinimizeButton.TabStop = false;
			this.MinimizeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseClick);
			this.MinimizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseDown);
			this.MinimizeButton.MouseEnter += new System.EventHandler(this.MinimizeButton_MouseEnter);
			this.MinimizeButton.MouseLeave += new System.EventHandler(this.MinimizeButton_MouseLeave);
			this.MinimizeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseUp);
			// 
			// StateButton
			// 
			this.StateButton.BackColor = System.Drawing.Color.Transparent;
			this.StateButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.StateButton.Image = global::QubicRed.Properties.Resources.state;
			this.StateButton.Location = new System.Drawing.Point(700, 0);
			this.StateButton.Name = "StateButton";
			this.StateButton.Size = new System.Drawing.Size(50, 30);
			this.StateButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.StateButton.TabIndex = 2;
			this.StateButton.TabStop = false;
			this.StateButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StateButton_MouseClick);
			this.StateButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StateButton_MouseDown);
			this.StateButton.MouseEnter += new System.EventHandler(this.StateButton_MouseEnter);
			this.StateButton.MouseLeave += new System.EventHandler(this.StateButton_MouseLeave);
			this.StateButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StateButton_MouseUp);
			// 
			// CloseButton
			// 
			this.CloseButton.BackColor = System.Drawing.Color.Transparent;
			this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.CloseButton.Image = global::QubicRed.Properties.Resources.close;
			this.CloseButton.Location = new System.Drawing.Point(750, 0);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(50, 30);
			this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.CloseButton.TabIndex = 1;
			this.CloseButton.TabStop = false;
			this.CloseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseClick);
			this.CloseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseDown);
			this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
			this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
			this.CloseButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseUp);
			// 
			// Title
			// 
			this.Title.Dock = System.Windows.Forms.DockStyle.Left;
			this.Title.Location = new System.Drawing.Point(0, 0);
			this.Title.Name = "Title";
			this.Title.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.Title.Size = new System.Drawing.Size(710, 30);
			this.Title.TabIndex = 0;
			this.Title.Text = "Qubic Red - Application";
			this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Title.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			// 
			// ExtendedBar
			// 
			this.ExtendedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ExtendedBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.ExtendedBar.ForeColor = System.Drawing.Color.White;
			this.ExtendedBar.Location = new System.Drawing.Point(0, 30);
			this.ExtendedBar.Name = "ExtendedBar";
			this.ExtendedBar.Size = new System.Drawing.Size(800, 40);
			this.ExtendedBar.TabIndex = 1;
			// 
			// QRDF
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.ControlBox = false;
			this.Controls.Add(this.ExtendedBar);
			this.Controls.Add(this.HeaderBar);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Leelawadee UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "QRDF";
			this.Text = "Qubic Red - Application";
			this.HeaderBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StateButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel HeaderBar;
		public CustomControls.ClickThroughLabel Title;
		private System.Windows.Forms.PictureBox CloseButton;
		private System.Windows.Forms.PictureBox MinimizeButton;
		private System.Windows.Forms.PictureBox StateButton;
		public System.Windows.Forms.Panel ExtendedBar;
	}
}