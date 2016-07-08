namespace QubicRed.Apps
{
	partial class StartMenu
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
			this.SideBar = new System.Windows.Forms.Panel();
			this.User = new System.Windows.Forms.PictureBox();
			this.Power = new System.Windows.Forms.PictureBox();
			this.Notifications = new System.Windows.Forms.PictureBox();
			this.Search = new System.Windows.Forms.PictureBox();
			this.Apps = new System.Windows.Forms.PictureBox();
			this.Home = new System.Windows.Forms.PictureBox();
			this.HomeGroup = new System.Windows.Forms.Panel();
			this.HomeTitle = new System.Windows.Forms.Label();
			this.AppsGroup = new System.Windows.Forms.Panel();
			this.ApplicationsTitle = new System.Windows.Forms.Label();
			this.SearchGroup = new System.Windows.Forms.Panel();
			this.SearchTitle = new System.Windows.Forms.Label();
			this.NotificationsGroup = new System.Windows.Forms.Panel();
			this.NotificationsTitle = new System.Windows.Forms.Label();
			this.UserGroup = new System.Windows.Forms.Panel();
			this.HomeGroupNext = new System.Windows.Forms.Label();
			this.HomeGroupTitle = new System.Windows.Forms.Label();
			this.HomeGroupPrevious = new System.Windows.Forms.Label();
			this.ApplicationsSort = new System.Windows.Forms.Label();
			this.ApplicationsSortIcon = new System.Windows.Forms.PictureBox();
			this.NotificationsDeleteAll = new System.Windows.Forms.Label();
			this.NotificationsDeleteAllIcon = new System.Windows.Forms.PictureBox();
			this.SideBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.User)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Power)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Notifications)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Search)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Apps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Home)).BeginInit();
			this.HomeGroup.SuspendLayout();
			this.AppsGroup.SuspendLayout();
			this.SearchGroup.SuspendLayout();
			this.NotificationsGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ApplicationsSortIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NotificationsDeleteAllIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// SideBar
			// 
			this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.SideBar.Controls.Add(this.User);
			this.SideBar.Controls.Add(this.Power);
			this.SideBar.Controls.Add(this.Notifications);
			this.SideBar.Controls.Add(this.Search);
			this.SideBar.Controls.Add(this.Apps);
			this.SideBar.Controls.Add(this.Home);
			this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
			this.SideBar.Location = new System.Drawing.Point(0, 0);
			this.SideBar.Name = "SideBar";
			this.SideBar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.SideBar.Size = new System.Drawing.Size(50, 600);
			this.SideBar.TabIndex = 0;
			// 
			// User
			// 
			this.User.BackColor = System.Drawing.Color.Transparent;
			this.User.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.User.Image = global::QubicRed.Properties.Resources.taskbar_user;
			this.User.Location = new System.Drawing.Point(0, 490);
			this.User.Name = "User";
			this.User.Size = new System.Drawing.Size(50, 50);
			this.User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.User.TabIndex = 5;
			this.User.TabStop = false;
			this.User.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Paint);
			this.User.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
			// 
			// Power
			// 
			this.Power.BackColor = System.Drawing.Color.Transparent;
			this.Power.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Power.Image = global::QubicRed.Properties.Resources.taskbar_power;
			this.Power.Location = new System.Drawing.Point(0, 540);
			this.Power.Name = "Power";
			this.Power.Size = new System.Drawing.Size(50, 50);
			this.Power.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Power.TabIndex = 4;
			this.Power.TabStop = false;
			this.Power.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Paint);
			this.Power.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
			// 
			// Notifications
			// 
			this.Notifications.BackColor = System.Drawing.Color.Transparent;
			this.Notifications.Dock = System.Windows.Forms.DockStyle.Top;
			this.Notifications.Location = new System.Drawing.Point(0, 150);
			this.Notifications.Name = "Notifications";
			this.Notifications.Size = new System.Drawing.Size(50, 50);
			this.Notifications.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Notifications.TabIndex = 3;
			this.Notifications.TabStop = false;
			this.Notifications.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Paint);
			this.Notifications.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
			// 
			// Search
			// 
			this.Search.BackColor = System.Drawing.Color.Transparent;
			this.Search.Dock = System.Windows.Forms.DockStyle.Top;
			this.Search.Image = global::QubicRed.Properties.Resources.taskbar_search;
			this.Search.Location = new System.Drawing.Point(0, 100);
			this.Search.Name = "Search";
			this.Search.Size = new System.Drawing.Size(50, 50);
			this.Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Search.TabIndex = 2;
			this.Search.TabStop = false;
			this.Search.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Paint);
			this.Search.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
			// 
			// Apps
			// 
			this.Apps.BackColor = System.Drawing.Color.Transparent;
			this.Apps.Dock = System.Windows.Forms.DockStyle.Top;
			this.Apps.Image = global::QubicRed.Properties.Resources.taskbar_apps;
			this.Apps.Location = new System.Drawing.Point(0, 50);
			this.Apps.Name = "Apps";
			this.Apps.Size = new System.Drawing.Size(50, 50);
			this.Apps.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Apps.TabIndex = 1;
			this.Apps.TabStop = false;
			this.Apps.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Paint);
			this.Apps.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
			// 
			// Home
			// 
			this.Home.BackColor = System.Drawing.Color.Transparent;
			this.Home.Dock = System.Windows.Forms.DockStyle.Top;
			this.Home.Image = global::QubicRed.Properties.Resources.taskbar_home;
			this.Home.Location = new System.Drawing.Point(0, 0);
			this.Home.Name = "Home";
			this.Home.Size = new System.Drawing.Size(50, 50);
			this.Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Home.TabIndex = 0;
			this.Home.TabStop = false;
			this.Home.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Paint);
			this.Home.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
			// 
			// HomeGroup
			// 
			this.HomeGroup.BackColor = System.Drawing.Color.Transparent;
			this.HomeGroup.Controls.Add(this.HomeGroupPrevious);
			this.HomeGroup.Controls.Add(this.HomeGroupTitle);
			this.HomeGroup.Controls.Add(this.HomeGroupNext);
			this.HomeGroup.Controls.Add(this.HomeTitle);
			this.HomeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HomeGroup.Location = new System.Drawing.Point(50, 0);
			this.HomeGroup.Name = "HomeGroup";
			this.HomeGroup.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.HomeGroup.Size = new System.Drawing.Size(450, 600);
			this.HomeGroup.TabIndex = 1;
			// 
			// HomeTitle
			// 
			this.HomeTitle.AutoSize = true;
			this.HomeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.HomeTitle.Location = new System.Drawing.Point(6, 21);
			this.HomeTitle.Name = "HomeTitle";
			this.HomeTitle.Size = new System.Drawing.Size(78, 29);
			this.HomeTitle.TabIndex = 0;
			this.HomeTitle.Text = "Home";
			// 
			// AppsGroup
			// 
			this.AppsGroup.BackColor = System.Drawing.Color.Transparent;
			this.AppsGroup.Controls.Add(this.ApplicationsSortIcon);
			this.AppsGroup.Controls.Add(this.ApplicationsSort);
			this.AppsGroup.Controls.Add(this.ApplicationsTitle);
			this.AppsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AppsGroup.Location = new System.Drawing.Point(50, 0);
			this.AppsGroup.Name = "AppsGroup";
			this.AppsGroup.Size = new System.Drawing.Size(450, 600);
			this.AppsGroup.TabIndex = 2;
			this.AppsGroup.Visible = false;
			// 
			// ApplicationsTitle
			// 
			this.ApplicationsTitle.AutoSize = true;
			this.ApplicationsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ApplicationsTitle.Location = new System.Drawing.Point(6, 21);
			this.ApplicationsTitle.Name = "ApplicationsTitle";
			this.ApplicationsTitle.Size = new System.Drawing.Size(144, 29);
			this.ApplicationsTitle.TabIndex = 1;
			this.ApplicationsTitle.Text = "Applications";
			// 
			// SearchGroup
			// 
			this.SearchGroup.BackColor = System.Drawing.Color.Transparent;
			this.SearchGroup.Controls.Add(this.SearchTitle);
			this.SearchGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SearchGroup.Location = new System.Drawing.Point(50, 0);
			this.SearchGroup.Name = "SearchGroup";
			this.SearchGroup.Size = new System.Drawing.Size(450, 600);
			this.SearchGroup.TabIndex = 2;
			this.SearchGroup.Visible = false;
			// 
			// SearchTitle
			// 
			this.SearchTitle.AutoSize = true;
			this.SearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.SearchTitle.Location = new System.Drawing.Point(6, 21);
			this.SearchTitle.Name = "SearchTitle";
			this.SearchTitle.Size = new System.Drawing.Size(107, 29);
			this.SearchTitle.TabIndex = 1;
			this.SearchTitle.Text = "Search...";
			// 
			// NotificationsGroup
			// 
			this.NotificationsGroup.BackColor = System.Drawing.Color.Transparent;
			this.NotificationsGroup.Controls.Add(this.NotificationsDeleteAllIcon);
			this.NotificationsGroup.Controls.Add(this.NotificationsDeleteAll);
			this.NotificationsGroup.Controls.Add(this.NotificationsTitle);
			this.NotificationsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NotificationsGroup.Location = new System.Drawing.Point(50, 0);
			this.NotificationsGroup.Name = "NotificationsGroup";
			this.NotificationsGroup.Size = new System.Drawing.Size(450, 600);
			this.NotificationsGroup.TabIndex = 2;
			this.NotificationsGroup.Visible = false;
			// 
			// NotificationsTitle
			// 
			this.NotificationsTitle.AutoSize = true;
			this.NotificationsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.NotificationsTitle.Location = new System.Drawing.Point(6, 21);
			this.NotificationsTitle.Name = "NotificationsTitle";
			this.NotificationsTitle.Size = new System.Drawing.Size(145, 29);
			this.NotificationsTitle.TabIndex = 1;
			this.NotificationsTitle.Text = "Notifications";
			// 
			// UserGroup
			// 
			this.UserGroup.BackColor = System.Drawing.Color.Transparent;
			this.UserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UserGroup.Location = new System.Drawing.Point(50, 0);
			this.UserGroup.Name = "UserGroup";
			this.UserGroup.Size = new System.Drawing.Size(450, 600);
			this.UserGroup.TabIndex = 2;
			this.UserGroup.Visible = false;
			// 
			// HomeGroupNext
			// 
			this.HomeGroupNext.AutoSize = true;
			this.HomeGroupNext.Cursor = System.Windows.Forms.Cursors.Hand;
			this.HomeGroupNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.HomeGroupNext.Location = new System.Drawing.Point(420, 28);
			this.HomeGroupNext.Name = "HomeGroupNext";
			this.HomeGroupNext.Size = new System.Drawing.Size(18, 20);
			this.HomeGroupNext.TabIndex = 1;
			this.HomeGroupNext.Text = ">";
			this.HomeGroupNext.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SwitchHomeTab_MouseClick);
			// 
			// HomeGroupTitle
			// 
			this.HomeGroupTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.HomeGroupTitle.Location = new System.Drawing.Point(349, 30);
			this.HomeGroupTitle.Name = "HomeGroupTitle";
			this.HomeGroupTitle.Size = new System.Drawing.Size(65, 17);
			this.HomeGroupTitle.TabIndex = 2;
			this.HomeGroupTitle.Text = "Overview";
			this.HomeGroupTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// HomeGroupPrevious
			// 
			this.HomeGroupPrevious.AutoSize = true;
			this.HomeGroupPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
			this.HomeGroupPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.HomeGroupPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.HomeGroupPrevious.Location = new System.Drawing.Point(325, 28);
			this.HomeGroupPrevious.Name = "HomeGroupPrevious";
			this.HomeGroupPrevious.Size = new System.Drawing.Size(18, 20);
			this.HomeGroupPrevious.TabIndex = 3;
			this.HomeGroupPrevious.Text = "<";
			this.HomeGroupPrevious.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SwitchHomeTab_MouseClick);
			// 
			// ApplicationsSort
			// 
			this.ApplicationsSort.AutoSize = true;
			this.ApplicationsSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ApplicationsSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.ApplicationsSort.Location = new System.Drawing.Point(358, 30);
			this.ApplicationsSort.Name = "ApplicationsSort";
			this.ApplicationsSort.Size = new System.Drawing.Size(80, 17);
			this.ApplicationsSort.TabIndex = 3;
			this.ApplicationsSort.Text = "Sort by A-Z";
			// 
			// ApplicationsSortIcon
			// 
			this.ApplicationsSortIcon.Location = new System.Drawing.Point(337, 32);
			this.ApplicationsSortIcon.Name = "ApplicationsSortIcon";
			this.ApplicationsSortIcon.Size = new System.Drawing.Size(15, 15);
			this.ApplicationsSortIcon.TabIndex = 4;
			this.ApplicationsSortIcon.TabStop = false;
			// 
			// NotificationsDeleteAll
			// 
			this.NotificationsDeleteAll.AutoSize = true;
			this.NotificationsDeleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.NotificationsDeleteAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.NotificationsDeleteAll.Location = new System.Drawing.Point(371, 30);
			this.NotificationsDeleteAll.Name = "NotificationsDeleteAll";
			this.NotificationsDeleteAll.Size = new System.Drawing.Size(67, 17);
			this.NotificationsDeleteAll.TabIndex = 4;
			this.NotificationsDeleteAll.Text = "Delete all";
			// 
			// NotificationsDeleteAllIcon
			// 
			this.NotificationsDeleteAllIcon.Location = new System.Drawing.Point(351, 32);
			this.NotificationsDeleteAllIcon.Name = "NotificationsDeleteAllIcon";
			this.NotificationsDeleteAllIcon.Size = new System.Drawing.Size(15, 15);
			this.NotificationsDeleteAllIcon.TabIndex = 5;
			this.NotificationsDeleteAllIcon.TabStop = false;
			// 
			// StartMenu
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(500, 600);
			this.ControlBox = false;
			this.Controls.Add(this.HomeGroup);
			this.Controls.Add(this.NotificationsGroup);
			this.Controls.Add(this.AppsGroup);
			this.Controls.Add(this.SearchGroup);
			this.Controls.Add(this.UserGroup);
			this.Controls.Add(this.SideBar);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StartMenu";
			this.Opacity = 0D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "StartMenu";
			this.SideBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.User)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Power)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Notifications)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Search)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Apps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Home)).EndInit();
			this.HomeGroup.ResumeLayout(false);
			this.HomeGroup.PerformLayout();
			this.AppsGroup.ResumeLayout(false);
			this.AppsGroup.PerformLayout();
			this.SearchGroup.ResumeLayout(false);
			this.SearchGroup.PerformLayout();
			this.NotificationsGroup.ResumeLayout(false);
			this.NotificationsGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ApplicationsSortIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NotificationsDeleteAllIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel SideBar;
		private System.Windows.Forms.PictureBox Notifications;
		private System.Windows.Forms.PictureBox Search;
		private System.Windows.Forms.PictureBox Apps;
		private System.Windows.Forms.PictureBox Home;
		private System.Windows.Forms.PictureBox User;
		private System.Windows.Forms.PictureBox Power;
		private System.Windows.Forms.Panel HomeGroup;
		private System.Windows.Forms.Panel AppsGroup;
		private System.Windows.Forms.Panel SearchGroup;
		private System.Windows.Forms.Panel NotificationsGroup;
		private System.Windows.Forms.Panel UserGroup;
		private System.Windows.Forms.Label HomeTitle;
		private System.Windows.Forms.Label ApplicationsTitle;
		private System.Windows.Forms.Label SearchTitle;
		private System.Windows.Forms.Label NotificationsTitle;
		private System.Windows.Forms.Label HomeGroupPrevious;
		private System.Windows.Forms.Label HomeGroupTitle;
		private System.Windows.Forms.Label HomeGroupNext;
		private System.Windows.Forms.Label ApplicationsSort;
		private System.Windows.Forms.PictureBox ApplicationsSortIcon;
		private System.Windows.Forms.PictureBox NotificationsDeleteAllIcon;
		private System.Windows.Forms.Label NotificationsDeleteAll;
	}
}