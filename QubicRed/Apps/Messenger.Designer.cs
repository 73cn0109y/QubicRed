namespace QubicRed.Apps
{
	partial class Messenger
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
			this.components = new System.ComponentModel.Container();
			this.UserPicture = new System.Windows.Forms.PictureBox();
			this.UserName = new System.Windows.Forms.Label();
			this.ViewProfileButton = new System.Windows.Forms.Label();
			this.SideBar = new System.Windows.Forms.Panel();
			this.SideBarContainer = new System.Windows.Forms.Panel();
			this.NoChatsLabel = new System.Windows.Forms.Label();
			this.PeoplesButton = new System.Windows.Forms.Panel();
			this.PeopleButtonLabel = new System.Windows.Forms.Label();
			this.ChatsButton = new System.Windows.Forms.Panel();
			this.ChatButtonLabel = new System.Windows.Forms.Label();
			this.SideBarOptions = new System.Windows.Forms.Panel();
			this.SettingsButton = new System.Windows.Forms.PictureBox();
			this.SortIcon = new System.Windows.Forms.PictureBox();
			this.NewLabel = new System.Windows.Forms.Label();
			this.NewIcon = new System.Windows.Forms.PictureBox();
			this.CompressLabel = new System.Windows.Forms.Label();
			this.CompressIcon = new System.Windows.Forms.PictureBox();
			this.ChatContainer = new System.Windows.Forms.Panel();
			this.ChatMessageContainer = new System.Windows.Forms.Panel();
			this.SendIcon = new System.Windows.Forms.PictureBox();
			this.ChatMessage = new System.Windows.Forms.TextBox();
			this.EmojiIcon = new System.Windows.Forms.PictureBox();
			this.AttachmentIcon = new System.Windows.Forms.PictureBox();
			this.Seperator3 = new System.Windows.Forms.Panel();
			this.VoiceIcon = new System.Windows.Forms.PictureBox();
			this.ChatInfo = new System.Windows.Forms.Panel();
			this.Seperator5 = new System.Windows.Forms.Panel();
			this.SocialHubIcon = new System.Windows.Forms.PictureBox();
			this.SocialHubLabel = new System.Windows.Forms.Label();
			this.CleanChatLabel = new System.Windows.Forms.Label();
			this.CleanUserIcon = new System.Windows.Forms.PictureBox();
			this.BlockUserIcon = new System.Windows.Forms.PictureBox();
			this.BlockUserLabel = new System.Windows.Forms.Label();
			this.Seperator4 = new System.Windows.Forms.Panel();
			this.RecipientUserName = new System.Windows.Forms.Label();
			this.RecipientDescription = new System.Windows.Forms.Label();
			this.RecipientRealName = new System.Windows.Forms.Label();
			this.RecipientImage = new System.Windows.Forms.PictureBox();
			this.InnerChatContainer = new System.Windows.Forms.Panel();
			this.NoChatSelectedLabel = new System.Windows.Forms.Label();
			this.ViewInLine = new System.Windows.Forms.PictureBox();
			this.ViewAlternate = new System.Windows.Forms.PictureBox();
			this.ViewLabel = new System.Windows.Forms.Label();
			this.Seperator2 = new System.Windows.Forms.Panel();
			this.SpecialVideo = new System.Windows.Forms.PictureBox();
			this.SpecialCall = new System.Windows.Forms.PictureBox();
			this.SpecialLabel = new System.Windows.Forms.Label();
			this.Seperator1 = new System.Windows.Forms.Panel();
			this.ClientSocket = new QubicRed.Components.QRSocket(this.components);
			this.LoginOverlay = new System.Windows.Forms.Panel();
			this.LoginPleaseWait = new System.Windows.Forms.Label();
			this.LoginClear = new System.Windows.Forms.Button();
			this.LoginButton = new System.Windows.Forms.Button();
			this.LoginTitle = new System.Windows.Forms.Label();
			this.LoginPassWordLabel = new System.Windows.Forms.Label();
			this.LoginPassWord = new System.Windows.Forms.TextBox();
			this.LoginUserNameLabel = new System.Windows.Forms.Label();
			this.LoginUserName = new System.Windows.Forms.TextBox();
			this.ExtendedBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UserPicture)).BeginInit();
			this.SideBar.SuspendLayout();
			this.SideBarContainer.SuspendLayout();
			this.PeoplesButton.SuspendLayout();
			this.ChatsButton.SuspendLayout();
			this.SideBarOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SortIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NewIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CompressIcon)).BeginInit();
			this.ChatContainer.SuspendLayout();
			this.ChatMessageContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SendIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmojiIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AttachmentIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.VoiceIcon)).BeginInit();
			this.ChatInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SocialHubIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CleanUserIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BlockUserIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RecipientImage)).BeginInit();
			this.InnerChatContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ViewInLine)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ViewAlternate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpecialVideo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpecialCall)).BeginInit();
			this.LoginOverlay.SuspendLayout();
			this.SuspendLayout();
			// 
			// Title
			// 
			this.Title.Text = "Qubic Red - Messenger";
			// 
			// ExtendedBar
			// 
			this.ExtendedBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(142)))), ((int)(((byte)(93)))), ((int)(((byte)(156)))));
			this.ExtendedBar.Controls.Add(this.ViewProfileButton);
			this.ExtendedBar.Controls.Add(this.Seperator1);
			this.ExtendedBar.Controls.Add(this.SpecialLabel);
			this.ExtendedBar.Controls.Add(this.SpecialCall);
			this.ExtendedBar.Controls.Add(this.SpecialVideo);
			this.ExtendedBar.Controls.Add(this.Seperator2);
			this.ExtendedBar.Controls.Add(this.ViewLabel);
			this.ExtendedBar.Controls.Add(this.ViewAlternate);
			this.ExtendedBar.Controls.Add(this.ViewInLine);
			this.ExtendedBar.Controls.Add(this.UserName);
			this.ExtendedBar.Controls.Add(this.UserPicture);
			this.ExtendedBar.Size = new System.Drawing.Size(1280, 40);
			// 
			// UserPicture
			// 
			this.UserPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.UserPicture.BackColor = System.Drawing.Color.Transparent;
			this.UserPicture.Location = new System.Drawing.Point(5, 5);
			this.UserPicture.Name = "UserPicture";
			this.UserPicture.Size = new System.Drawing.Size(30, 30);
			this.UserPicture.TabIndex = 2;
			this.UserPicture.TabStop = false;
			// 
			// UserName
			// 
			this.UserName.AutoSize = true;
			this.UserName.BackColor = System.Drawing.Color.Transparent;
			this.UserName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UserName.Location = new System.Drawing.Point(41, 5);
			this.UserName.Name = "UserName";
			this.UserName.Size = new System.Drawing.Size(0, 19);
			this.UserName.TabIndex = 3;
			// 
			// ViewProfileButton
			// 
			this.ViewProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ViewProfileButton.AutoSize = true;
			this.ViewProfileButton.BackColor = System.Drawing.Color.Transparent;
			this.ViewProfileButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ViewProfileButton.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ViewProfileButton.Location = new System.Drawing.Point(43, 23);
			this.ViewProfileButton.Name = "ViewProfileButton";
			this.ViewProfileButton.Size = new System.Drawing.Size(57, 18);
			this.ViewProfileButton.TabIndex = 4;
			this.ViewProfileButton.Text = "View Profile";
			this.ViewProfileButton.UseCompatibleTextRendering = true;
			this.ViewProfileButton.Visible = false;
			// 
			// SideBar
			// 
			this.SideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.SideBar.BackColor = System.Drawing.Color.White;
			this.SideBar.Controls.Add(this.SideBarContainer);
			this.SideBar.Controls.Add(this.PeoplesButton);
			this.SideBar.Controls.Add(this.ChatsButton);
			this.SideBar.Controls.Add(this.SideBarOptions);
			this.SideBar.Location = new System.Drawing.Point(0, 71);
			this.SideBar.MaximumSize = new System.Drawing.Size(300, 99999);
			this.SideBar.Name = "SideBar";
			this.SideBar.Size = new System.Drawing.Size(300, 697);
			this.SideBar.TabIndex = 2;
			// 
			// SideBarContainer
			// 
			this.SideBarContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SideBarContainer.Controls.Add(this.NoChatsLabel);
			this.SideBarContainer.Location = new System.Drawing.Point(0, 90);
			this.SideBarContainer.Name = "SideBarContainer";
			this.SideBarContainer.Size = new System.Drawing.Size(300, 607);
			this.SideBarContainer.TabIndex = 3;
			// 
			// NoChatsLabel
			// 
			this.NoChatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NoChatsLabel.Font = new System.Drawing.Font("Leelawadee UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.NoChatsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.NoChatsLabel.Location = new System.Drawing.Point(0, 0);
			this.NoChatsLabel.Name = "NoChatsLabel";
			this.NoChatsLabel.Size = new System.Drawing.Size(300, 607);
			this.NoChatsLabel.TabIndex = 0;
			this.NoChatsLabel.Text = "It\'s a little lonely in here...";
			this.NoChatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PeoplesButton
			// 
			this.PeoplesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PeoplesButton.Controls.Add(this.PeopleButtonLabel);
			this.PeoplesButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PeoplesButton.Location = new System.Drawing.Point(150, 40);
			this.PeoplesButton.Name = "PeoplesButton";
			this.PeoplesButton.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.PeoplesButton.Size = new System.Drawing.Size(150, 50);
			this.PeoplesButton.TabIndex = 2;
			// 
			// PeopleButtonLabel
			// 
			this.PeopleButtonLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PeopleButtonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PeopleButtonLabel.Font = new System.Drawing.Font("Leelawadee UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.PeopleButtonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.PeopleButtonLabel.Location = new System.Drawing.Point(0, 0);
			this.PeopleButtonLabel.Name = "PeopleButtonLabel";
			this.PeopleButtonLabel.Size = new System.Drawing.Size(150, 47);
			this.PeopleButtonLabel.TabIndex = 0;
			this.PeopleButtonLabel.Text = "People";
			this.PeopleButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ChatsButton
			// 
			this.ChatsButton.Controls.Add(this.ChatButtonLabel);
			this.ChatsButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ChatsButton.Location = new System.Drawing.Point(0, 40);
			this.ChatsButton.Name = "ChatsButton";
			this.ChatsButton.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.ChatsButton.Size = new System.Drawing.Size(150, 50);
			this.ChatsButton.TabIndex = 1;
			// 
			// ChatButtonLabel
			// 
			this.ChatButtonLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ChatButtonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ChatButtonLabel.Font = new System.Drawing.Font("Leelawadee UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ChatButtonLabel.Location = new System.Drawing.Point(0, 0);
			this.ChatButtonLabel.Name = "ChatButtonLabel";
			this.ChatButtonLabel.Size = new System.Drawing.Size(150, 47);
			this.ChatButtonLabel.TabIndex = 0;
			this.ChatButtonLabel.Text = "Chats";
			this.ChatButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SideBarOptions
			// 
			this.SideBarOptions.Controls.Add(this.SettingsButton);
			this.SideBarOptions.Controls.Add(this.SortIcon);
			this.SideBarOptions.Controls.Add(this.NewLabel);
			this.SideBarOptions.Controls.Add(this.NewIcon);
			this.SideBarOptions.Controls.Add(this.CompressLabel);
			this.SideBarOptions.Controls.Add(this.CompressIcon);
			this.SideBarOptions.Dock = System.Windows.Forms.DockStyle.Top;
			this.SideBarOptions.Location = new System.Drawing.Point(0, 0);
			this.SideBarOptions.Name = "SideBarOptions";
			this.SideBarOptions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.SideBarOptions.Size = new System.Drawing.Size(300, 40);
			this.SideBarOptions.TabIndex = 0;
			this.SideBarOptions.Paint += new System.Windows.Forms.PaintEventHandler(this.SideBarOptions_Paint);
			// 
			// SettingsButton
			// 
			this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.SettingsButton.Image = global::QubicRed.Properties.Resources.settings;
			this.SettingsButton.Location = new System.Drawing.Point(260, 0);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(40, 39);
			this.SettingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.SettingsButton.TabIndex = 5;
			this.SettingsButton.TabStop = false;
			// 
			// SortIcon
			// 
			this.SortIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SortIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.SortIcon.Image = global::QubicRed.Properties.Resources.sort;
			this.SortIcon.Location = new System.Drawing.Point(220, 0);
			this.SortIcon.Name = "SortIcon";
			this.SortIcon.Size = new System.Drawing.Size(40, 39);
			this.SortIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.SortIcon.TabIndex = 4;
			this.SortIcon.TabStop = false;
			// 
			// NewLabel
			// 
			this.NewLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.NewLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.NewLabel.Location = new System.Drawing.Point(160, 0);
			this.NewLabel.Name = "NewLabel";
			this.NewLabel.Size = new System.Drawing.Size(60, 39);
			this.NewLabel.TabIndex = 3;
			this.NewLabel.Text = "New";
			this.NewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.NewLabel.MouseEnter += new System.EventHandler(this.NewLabel_MouseEnter);
			this.NewLabel.MouseLeave += new System.EventHandler(this.NewLabel_MouseLeave);
			// 
			// NewIcon
			// 
			this.NewIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.NewIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.NewIcon.Image = global::QubicRed.Properties.Resources._new;
			this.NewIcon.Location = new System.Drawing.Point(120, 0);
			this.NewIcon.Name = "NewIcon";
			this.NewIcon.Size = new System.Drawing.Size(40, 39);
			this.NewIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.NewIcon.TabIndex = 2;
			this.NewIcon.TabStop = false;
			// 
			// CompressLabel
			// 
			this.CompressLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CompressLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.CompressLabel.Location = new System.Drawing.Point(40, 0);
			this.CompressLabel.Name = "CompressLabel";
			this.CompressLabel.Size = new System.Drawing.Size(80, 39);
			this.CompressLabel.TabIndex = 1;
			this.CompressLabel.Text = "Compress";
			this.CompressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CompressLabel.MouseEnter += new System.EventHandler(this.CompressLabel_MouseEnter);
			this.CompressLabel.MouseLeave += new System.EventHandler(this.CompressLabel_MouseLeave);
			// 
			// CompressIcon
			// 
			this.CompressIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CompressIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.CompressIcon.Image = global::QubicRed.Properties.Resources.compress;
			this.CompressIcon.Location = new System.Drawing.Point(0, 0);
			this.CompressIcon.Name = "CompressIcon";
			this.CompressIcon.Size = new System.Drawing.Size(40, 39);
			this.CompressIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.CompressIcon.TabIndex = 0;
			this.CompressIcon.TabStop = false;
			// 
			// ChatContainer
			// 
			this.ChatContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ChatContainer.BackColor = System.Drawing.Color.White;
			this.ChatContainer.Controls.Add(this.ChatMessageContainer);
			this.ChatContainer.Controls.Add(this.ChatInfo);
			this.ChatContainer.Controls.Add(this.InnerChatContainer);
			this.ChatContainer.Location = new System.Drawing.Point(300, 70);
			this.ChatContainer.Name = "ChatContainer";
			this.ChatContainer.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
			this.ChatContainer.Size = new System.Drawing.Size(980, 698);
			this.ChatContainer.TabIndex = 3;
			this.ChatContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatContainer_Paint);
			// 
			// ChatMessageContainer
			// 
			this.ChatMessageContainer.Controls.Add(this.SendIcon);
			this.ChatMessageContainer.Controls.Add(this.ChatMessage);
			this.ChatMessageContainer.Controls.Add(this.EmojiIcon);
			this.ChatMessageContainer.Controls.Add(this.AttachmentIcon);
			this.ChatMessageContainer.Controls.Add(this.Seperator3);
			this.ChatMessageContainer.Controls.Add(this.VoiceIcon);
			this.ChatMessageContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ChatMessageContainer.Location = new System.Drawing.Point(1, 648);
			this.ChatMessageContainer.Name = "ChatMessageContainer";
			this.ChatMessageContainer.Size = new System.Drawing.Size(979, 50);
			this.ChatMessageContainer.TabIndex = 0;
			// 
			// SendIcon
			// 
			this.SendIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SendIcon.Dock = System.Windows.Forms.DockStyle.Right;
			this.SendIcon.Image = global::QubicRed.Properties.Resources.send;
			this.SendIcon.Location = new System.Drawing.Point(919, 0);
			this.SendIcon.Name = "SendIcon";
			this.SendIcon.Size = new System.Drawing.Size(60, 50);
			this.SendIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.SendIcon.TabIndex = 5;
			this.SendIcon.TabStop = false;
			this.SendIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SendIcon_MouseClick);
			// 
			// ChatMessage
			// 
			this.ChatMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ChatMessage.BackColor = System.Drawing.Color.White;
			this.ChatMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ChatMessage.Font = new System.Drawing.Font("Leelawadee UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ChatMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.ChatMessage.Location = new System.Drawing.Point(180, 16);
			this.ChatMessage.Name = "ChatMessage";
			this.ChatMessage.Size = new System.Drawing.Size(739, 22);
			this.ChatMessage.TabIndex = 4;
			this.ChatMessage.Text = "Login to begin...";
			this.ChatMessage.TextChanged += new System.EventHandler(this.ChatMessage_TextChanged);
			this.ChatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatMessage_KeyDown);
			this.ChatMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChatMessage_KeyUp);
			// 
			// EmojiIcon
			// 
			this.EmojiIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.EmojiIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.EmojiIcon.Image = global::QubicRed.Properties.Resources.emoji;
			this.EmojiIcon.Location = new System.Drawing.Point(120, 0);
			this.EmojiIcon.Name = "EmojiIcon";
			this.EmojiIcon.Size = new System.Drawing.Size(60, 50);
			this.EmojiIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.EmojiIcon.TabIndex = 3;
			this.EmojiIcon.TabStop = false;
			this.EmojiIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmojiIcon_MouseClick);
			// 
			// AttachmentIcon
			// 
			this.AttachmentIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AttachmentIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.AttachmentIcon.Image = global::QubicRed.Properties.Resources.attachment;
			this.AttachmentIcon.Location = new System.Drawing.Point(60, 0);
			this.AttachmentIcon.Name = "AttachmentIcon";
			this.AttachmentIcon.Size = new System.Drawing.Size(60, 50);
			this.AttachmentIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.AttachmentIcon.TabIndex = 2;
			this.AttachmentIcon.TabStop = false;
			this.AttachmentIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AttachmentIcon_MouseClick);
			// 
			// Seperator3
			// 
			this.Seperator3.Dock = System.Windows.Forms.DockStyle.Left;
			this.Seperator3.Location = new System.Drawing.Point(50, 0);
			this.Seperator3.Name = "Seperator3";
			this.Seperator3.Size = new System.Drawing.Size(10, 50);
			this.Seperator3.TabIndex = 1;
			this.Seperator3.Paint += new System.Windows.Forms.PaintEventHandler(this.Seperator_Paint);
			// 
			// VoiceIcon
			// 
			this.VoiceIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.VoiceIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.VoiceIcon.Image = global::QubicRed.Properties.Resources.voice;
			this.VoiceIcon.Location = new System.Drawing.Point(0, 0);
			this.VoiceIcon.Name = "VoiceIcon";
			this.VoiceIcon.Size = new System.Drawing.Size(50, 50);
			this.VoiceIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.VoiceIcon.TabIndex = 0;
			this.VoiceIcon.TabStop = false;
			this.VoiceIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VoiceIcon_MouseClick);
			// 
			// ChatInfo
			// 
			this.ChatInfo.Controls.Add(this.Seperator5);
			this.ChatInfo.Controls.Add(this.SocialHubIcon);
			this.ChatInfo.Controls.Add(this.SocialHubLabel);
			this.ChatInfo.Controls.Add(this.CleanChatLabel);
			this.ChatInfo.Controls.Add(this.CleanUserIcon);
			this.ChatInfo.Controls.Add(this.BlockUserIcon);
			this.ChatInfo.Controls.Add(this.BlockUserLabel);
			this.ChatInfo.Controls.Add(this.Seperator4);
			this.ChatInfo.Controls.Add(this.RecipientUserName);
			this.ChatInfo.Controls.Add(this.RecipientDescription);
			this.ChatInfo.Controls.Add(this.RecipientRealName);
			this.ChatInfo.Controls.Add(this.RecipientImage);
			this.ChatInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.ChatInfo.Location = new System.Drawing.Point(1, 0);
			this.ChatInfo.Name = "ChatInfo";
			this.ChatInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.ChatInfo.Size = new System.Drawing.Size(979, 115);
			this.ChatInfo.TabIndex = 1;
			this.ChatInfo.Visible = false;
			this.ChatInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatInfo_Paint);
			// 
			// Seperator5
			// 
			this.Seperator5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.Seperator5.Location = new System.Drawing.Point(545, 0);
			this.Seperator5.Name = "Seperator5";
			this.Seperator5.Size = new System.Drawing.Size(10, 114);
			this.Seperator5.TabIndex = 5;
			this.Seperator5.Paint += new System.Windows.Forms.PaintEventHandler(this.Seperator_Paint);
			// 
			// SocialHubIcon
			// 
			this.SocialHubIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SocialHubIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SocialHubIcon.Image = global::QubicRed.Properties.Resources.socialhub;
			this.SocialHubIcon.Location = new System.Drawing.Point(822, 50);
			this.SocialHubIcon.Name = "SocialHubIcon";
			this.SocialHubIcon.Size = new System.Drawing.Size(20, 19);
			this.SocialHubIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.SocialHubIcon.TabIndex = 10;
			this.SocialHubIcon.TabStop = false;
			// 
			// SocialHubLabel
			// 
			this.SocialHubLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SocialHubLabel.AutoSize = true;
			this.SocialHubLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SocialHubLabel.Location = new System.Drawing.Point(848, 50);
			this.SocialHubLabel.Name = "SocialHubLabel";
			this.SocialHubLabel.Size = new System.Drawing.Size(126, 19);
			this.SocialHubLabel.TabIndex = 9;
			this.SocialHubLabel.Text = "Open in Social Hub";
			this.SocialHubLabel.MouseEnter += new System.EventHandler(this.SocialHubLabel_MouseEnter);
			this.SocialHubLabel.MouseLeave += new System.EventHandler(this.SocialHubLabel_MouseLeave);
			// 
			// CleanChatLabel
			// 
			this.CleanChatLabel.AutoSize = true;
			this.CleanChatLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CleanChatLabel.Location = new System.Drawing.Point(463, 50);
			this.CleanChatLabel.Name = "CleanChatLabel";
			this.CleanChatLabel.Size = new System.Drawing.Size(76, 19);
			this.CleanChatLabel.TabIndex = 8;
			this.CleanChatLabel.Text = "Clean Chat";
			this.CleanChatLabel.MouseEnter += new System.EventHandler(this.CleanChatLabel_MouseEnter);
			this.CleanChatLabel.MouseLeave += new System.EventHandler(this.CleanChatLabel_MouseLeave);
			// 
			// CleanUserIcon
			// 
			this.CleanUserIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CleanUserIcon.Image = global::QubicRed.Properties.Resources.cleanchat;
			this.CleanUserIcon.Location = new System.Drawing.Point(439, 50);
			this.CleanUserIcon.Name = "CleanUserIcon";
			this.CleanUserIcon.Size = new System.Drawing.Size(20, 20);
			this.CleanUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.CleanUserIcon.TabIndex = 7;
			this.CleanUserIcon.TabStop = false;
			// 
			// BlockUserIcon
			// 
			this.BlockUserIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BlockUserIcon.Image = global::QubicRed.Properties.Resources.blockuser;
			this.BlockUserIcon.Location = new System.Drawing.Point(336, 50);
			this.BlockUserIcon.Name = "BlockUserIcon";
			this.BlockUserIcon.Size = new System.Drawing.Size(20, 20);
			this.BlockUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.BlockUserIcon.TabIndex = 6;
			this.BlockUserIcon.TabStop = false;
			// 
			// BlockUserLabel
			// 
			this.BlockUserLabel.AutoSize = true;
			this.BlockUserLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BlockUserLabel.Location = new System.Drawing.Point(360, 50);
			this.BlockUserLabel.Name = "BlockUserLabel";
			this.BlockUserLabel.Size = new System.Drawing.Size(73, 19);
			this.BlockUserLabel.TabIndex = 5;
			this.BlockUserLabel.Text = "Block User";
			this.BlockUserLabel.MouseEnter += new System.EventHandler(this.BlockUserLabel_MouseEnter);
			this.BlockUserLabel.MouseLeave += new System.EventHandler(this.BlockUserLabel_MouseLeave);
			// 
			// Seperator4
			// 
			this.Seperator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.Seperator4.Location = new System.Drawing.Point(320, 0);
			this.Seperator4.Name = "Seperator4";
			this.Seperator4.Size = new System.Drawing.Size(10, 114);
			this.Seperator4.TabIndex = 4;
			this.Seperator4.Paint += new System.Windows.Forms.PaintEventHandler(this.Seperator_Paint);
			// 
			// RecipientUserName
			// 
			this.RecipientUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.RecipientUserName.AutoSize = true;
			this.RecipientUserName.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.RecipientUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.RecipientUserName.Location = new System.Drawing.Point(172, 32);
			this.RecipientUserName.Name = "RecipientUserName";
			this.RecipientUserName.Size = new System.Drawing.Size(50, 21);
			this.RecipientUserName.TabIndex = 3;
			this.RecipientUserName.Text = "Test.001";
			this.RecipientUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.RecipientUserName.UseCompatibleTextRendering = true;
			// 
			// RecipientDescription
			// 
			this.RecipientDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.RecipientDescription.AutoEllipsis = true;
			this.RecipientDescription.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.RecipientDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.RecipientDescription.Location = new System.Drawing.Point(133, 60);
			this.RecipientDescription.Name = "RecipientDescription";
			this.RecipientDescription.Size = new System.Drawing.Size(179, 32);
			this.RecipientDescription.TabIndex = 2;
			this.RecipientDescription.Text = "Hi! This is my profile description";
			this.RecipientDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.RecipientDescription.UseCompatibleTextRendering = true;
			// 
			// RecipientRealName
			// 
			this.RecipientRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.RecipientRealName.AutoSize = true;
			this.RecipientRealName.Location = new System.Drawing.Point(132, 32);
			this.RecipientRealName.Name = "RecipientRealName";
			this.RecipientRealName.Size = new System.Drawing.Size(34, 19);
			this.RecipientRealName.TabIndex = 1;
			this.RecipientRealName.Text = "Test";
			// 
			// RecipientImage
			// 
			this.RecipientImage.Dock = System.Windows.Forms.DockStyle.Left;
			this.RecipientImage.Location = new System.Drawing.Point(0, 0);
			this.RecipientImage.Name = "RecipientImage";
			this.RecipientImage.Size = new System.Drawing.Size(115, 114);
			this.RecipientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.RecipientImage.TabIndex = 0;
			this.RecipientImage.TabStop = false;
			// 
			// InnerChatContainer
			// 
			this.InnerChatContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InnerChatContainer.AutoScroll = true;
			this.InnerChatContainer.BackColor = System.Drawing.Color.White;
			this.InnerChatContainer.Controls.Add(this.NoChatSelectedLabel);
			this.InnerChatContainer.Location = new System.Drawing.Point(1, 115);
			this.InnerChatContainer.Name = "InnerChatContainer";
			this.InnerChatContainer.Size = new System.Drawing.Size(995, 549);
			this.InnerChatContainer.TabIndex = 2;
			// 
			// NoChatSelectedLabel
			// 
			this.NoChatSelectedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NoChatSelectedLabel.Font = new System.Drawing.Font("Leelawadee UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.NoChatSelectedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.NoChatSelectedLabel.Location = new System.Drawing.Point(0, 0);
			this.NoChatSelectedLabel.Name = "NoChatSelectedLabel";
			this.NoChatSelectedLabel.Size = new System.Drawing.Size(995, 549);
			this.NoChatSelectedLabel.TabIndex = 1;
			this.NoChatSelectedLabel.Text = "Login to start chatting with your friends...";
			this.NoChatSelectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ViewInLine
			// 
			this.ViewInLine.BackColor = System.Drawing.Color.Transparent;
			this.ViewInLine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ViewInLine.Dock = System.Windows.Forms.DockStyle.Right;
			this.ViewInLine.Image = global::QubicRed.Properties.Resources.viewstack;
			this.ViewInLine.Location = new System.Drawing.Point(1240, 0);
			this.ViewInLine.Name = "ViewInLine";
			this.ViewInLine.Size = new System.Drawing.Size(40, 40);
			this.ViewInLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.ViewInLine.TabIndex = 5;
			this.ViewInLine.TabStop = false;
			// 
			// ViewAlternate
			// 
			this.ViewAlternate.BackColor = System.Drawing.Color.Transparent;
			this.ViewAlternate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ViewAlternate.Dock = System.Windows.Forms.DockStyle.Right;
			this.ViewAlternate.Image = global::QubicRed.Properties.Resources.viewalternate;
			this.ViewAlternate.Location = new System.Drawing.Point(1200, 0);
			this.ViewAlternate.Name = "ViewAlternate";
			this.ViewAlternate.Size = new System.Drawing.Size(40, 40);
			this.ViewAlternate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.ViewAlternate.TabIndex = 6;
			this.ViewAlternate.TabStop = false;
			// 
			// ViewLabel
			// 
			this.ViewLabel.BackColor = System.Drawing.Color.Transparent;
			this.ViewLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ViewLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.ViewLabel.Location = new System.Drawing.Point(1150, 0);
			this.ViewLabel.Name = "ViewLabel";
			this.ViewLabel.Size = new System.Drawing.Size(50, 40);
			this.ViewLabel.TabIndex = 7;
			this.ViewLabel.Text = "View";
			this.ViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Seperator2
			// 
			this.Seperator2.BackColor = System.Drawing.Color.Transparent;
			this.Seperator2.Dock = System.Windows.Forms.DockStyle.Right;
			this.Seperator2.Location = new System.Drawing.Point(1140, 0);
			this.Seperator2.Name = "Seperator2";
			this.Seperator2.Size = new System.Drawing.Size(10, 40);
			this.Seperator2.TabIndex = 8;
			this.Seperator2.Paint += new System.Windows.Forms.PaintEventHandler(this.Seperator_Paint);
			// 
			// SpecialVideo
			// 
			this.SpecialVideo.BackColor = System.Drawing.Color.Transparent;
			this.SpecialVideo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SpecialVideo.Dock = System.Windows.Forms.DockStyle.Right;
			this.SpecialVideo.Image = global::QubicRed.Properties.Resources.specialvideo;
			this.SpecialVideo.Location = new System.Drawing.Point(1100, 0);
			this.SpecialVideo.Name = "SpecialVideo";
			this.SpecialVideo.Size = new System.Drawing.Size(40, 40);
			this.SpecialVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.SpecialVideo.TabIndex = 9;
			this.SpecialVideo.TabStop = false;
			// 
			// SpecialCall
			// 
			this.SpecialCall.BackColor = System.Drawing.Color.Transparent;
			this.SpecialCall.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SpecialCall.Dock = System.Windows.Forms.DockStyle.Right;
			this.SpecialCall.Image = global::QubicRed.Properties.Resources.specialcall;
			this.SpecialCall.Location = new System.Drawing.Point(1060, 0);
			this.SpecialCall.Name = "SpecialCall";
			this.SpecialCall.Size = new System.Drawing.Size(40, 40);
			this.SpecialCall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.SpecialCall.TabIndex = 10;
			this.SpecialCall.TabStop = false;
			// 
			// SpecialLabel
			// 
			this.SpecialLabel.BackColor = System.Drawing.Color.Transparent;
			this.SpecialLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SpecialLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.SpecialLabel.Location = new System.Drawing.Point(990, 0);
			this.SpecialLabel.Name = "SpecialLabel";
			this.SpecialLabel.Size = new System.Drawing.Size(70, 40);
			this.SpecialLabel.TabIndex = 11;
			this.SpecialLabel.Text = "Special";
			this.SpecialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Seperator1
			// 
			this.Seperator1.BackColor = System.Drawing.Color.Transparent;
			this.Seperator1.Dock = System.Windows.Forms.DockStyle.Right;
			this.Seperator1.Location = new System.Drawing.Point(980, 0);
			this.Seperator1.Name = "Seperator1";
			this.Seperator1.Size = new System.Drawing.Size(10, 40);
			this.Seperator1.TabIndex = 9;
			this.Seperator1.Paint += new System.Windows.Forms.PaintEventHandler(this.Seperator_Paint);
			// 
			// ClientSocket
			// 
			this.ClientSocket.OnMessageReceived += new QubicRed.Components.QRSocket.MessageReceived(this.ClientSocket_OnMessagereceived);
			this.ClientSocket.SocketEvent += new QubicRed.Components.QRSocket.SocketEventHadnler(this.ClientSocket_SocketEvent);
			// 
			// LoginOverlay
			// 
			this.LoginOverlay.Controls.Add(this.LoginPleaseWait);
			this.LoginOverlay.Controls.Add(this.LoginClear);
			this.LoginOverlay.Controls.Add(this.LoginButton);
			this.LoginOverlay.Controls.Add(this.LoginTitle);
			this.LoginOverlay.Controls.Add(this.LoginPassWordLabel);
			this.LoginOverlay.Controls.Add(this.LoginPassWord);
			this.LoginOverlay.Controls.Add(this.LoginUserNameLabel);
			this.LoginOverlay.Controls.Add(this.LoginUserName);
			this.LoginOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LoginOverlay.Location = new System.Drawing.Point(0, 70);
			this.LoginOverlay.Name = "LoginOverlay";
			this.LoginOverlay.Size = new System.Drawing.Size(1280, 698);
			this.LoginOverlay.TabIndex = 0;
			this.LoginOverlay.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginOverlay_Paint);
			// 
			// LoginPleaseWait
			// 
			this.LoginPleaseWait.AutoSize = true;
			this.LoginPleaseWait.Location = new System.Drawing.Point(603, 399);
			this.LoginPleaseWait.Name = "LoginPleaseWait";
			this.LoginPleaseWait.Size = new System.Drawing.Size(88, 19);
			this.LoginPleaseWait.TabIndex = 7;
			this.LoginPleaseWait.Text = "Please Wait...";
			this.LoginPleaseWait.Visible = false;
			// 
			// LoginClear
			// 
			this.LoginClear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoginClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginClear.Location = new System.Drawing.Point(644, 366);
			this.LoginClear.Name = "LoginClear";
			this.LoginClear.Size = new System.Drawing.Size(100, 30);
			this.LoginClear.TabIndex = 6;
			this.LoginClear.Text = "Clear";
			this.LoginClear.UseVisualStyleBackColor = true;
			this.LoginClear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoginClear_MouseClick);
			// 
			// LoginButton
			// 
			this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Location = new System.Drawing.Point(538, 366);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(100, 30);
			this.LoginButton.TabIndex = 5;
			this.LoginButton.Text = "Login";
			this.LoginButton.UseVisualStyleBackColor = true;
			this.LoginButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoginButton_MouseClick);
			// 
			// LoginTitle
			// 
			this.LoginTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoginTitle.AutoSize = true;
			this.LoginTitle.Font = new System.Drawing.Font("Leelawadee UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LoginTitle.Location = new System.Drawing.Point(601, 249);
			this.LoginTitle.Name = "LoginTitle";
			this.LoginTitle.Size = new System.Drawing.Size(74, 32);
			this.LoginTitle.TabIndex = 4;
			this.LoginTitle.Text = "Login";
			// 
			// LoginPassWordLabel
			// 
			this.LoginPassWordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoginPassWordLabel.AutoSize = true;
			this.LoginPassWordLabel.Location = new System.Drawing.Point(499, 337);
			this.LoginPassWordLabel.Name = "LoginPassWordLabel";
			this.LoginPassWordLabel.Size = new System.Drawing.Size(67, 19);
			this.LoginPassWordLabel.TabIndex = 3;
			this.LoginPassWordLabel.Text = "Password";
			// 
			// LoginPassWord
			// 
			this.LoginPassWord.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoginPassWord.BackColor = System.Drawing.Color.White;
			this.LoginPassWord.ForeColor = System.Drawing.Color.Black;
			this.LoginPassWord.Location = new System.Drawing.Point(572, 334);
			this.LoginPassWord.Name = "LoginPassWord";
			this.LoginPassWord.PasswordChar = '•';
			this.LoginPassWord.Size = new System.Drawing.Size(207, 26);
			this.LoginPassWord.TabIndex = 2;
			// 
			// LoginUserNameLabel
			// 
			this.LoginUserNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoginUserNameLabel.AutoSize = true;
			this.LoginUserNameLabel.Location = new System.Drawing.Point(495, 305);
			this.LoginUserNameLabel.Name = "LoginUserNameLabel";
			this.LoginUserNameLabel.Size = new System.Drawing.Size(71, 19);
			this.LoginUserNameLabel.TabIndex = 1;
			this.LoginUserNameLabel.Text = "Username";
			// 
			// LoginUserName
			// 
			this.LoginUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.LoginUserName.BackColor = System.Drawing.Color.White;
			this.LoginUserName.ForeColor = System.Drawing.Color.Black;
			this.LoginUserName.Location = new System.Drawing.Point(572, 302);
			this.LoginUserName.Name = "LoginUserName";
			this.LoginUserName.Size = new System.Drawing.Size(207, 26);
			this.LoginUserName.TabIndex = 0;
			// 
			// Messenger
			// 
			this.AppColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(93)))), ((int)(((byte)(156)))));
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 768);
			this.Controls.Add(this.LoginOverlay);
			this.Controls.Add(this.ChatContainer);
			this.Controls.Add(this.SideBar);
			this.Name = "Messenger";
			this.Controls.SetChildIndex(this.SideBar, 0);
			this.Controls.SetChildIndex(this.ChatContainer, 0);
			this.Controls.SetChildIndex(this.ExtendedBar, 0);
			this.Controls.SetChildIndex(this.LoginOverlay, 0);
			this.ExtendedBar.ResumeLayout(false);
			this.ExtendedBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.UserPicture)).EndInit();
			this.SideBar.ResumeLayout(false);
			this.SideBarContainer.ResumeLayout(false);
			this.PeoplesButton.ResumeLayout(false);
			this.ChatsButton.ResumeLayout(false);
			this.SideBarOptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SortIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NewIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CompressIcon)).EndInit();
			this.ChatContainer.ResumeLayout(false);
			this.ChatMessageContainer.ResumeLayout(false);
			this.ChatMessageContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SendIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmojiIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AttachmentIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.VoiceIcon)).EndInit();
			this.ChatInfo.ResumeLayout(false);
			this.ChatInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SocialHubIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CleanUserIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BlockUserIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RecipientImage)).EndInit();
			this.InnerChatContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ViewInLine)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ViewAlternate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpecialVideo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpecialCall)).EndInit();
			this.LoginOverlay.ResumeLayout(false);
			this.LoginOverlay.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label ViewProfileButton;
		private System.Windows.Forms.Label UserName;
		private System.Windows.Forms.PictureBox UserPicture;
		private System.Windows.Forms.Panel SideBar;
		private System.Windows.Forms.Panel ChatContainer;
		private System.Windows.Forms.Panel SideBarOptions;
		private System.Windows.Forms.Panel ChatsButton;
		private System.Windows.Forms.Panel SideBarContainer;
		private System.Windows.Forms.Panel PeoplesButton;
		private System.Windows.Forms.Label ChatButtonLabel;
		private System.Windows.Forms.Label PeopleButtonLabel;
		private System.Windows.Forms.Label NoChatsLabel;
		private System.Windows.Forms.PictureBox ViewAlternate;
		private System.Windows.Forms.PictureBox ViewInLine;
		private System.Windows.Forms.Label ViewLabel;
		private System.Windows.Forms.Panel Seperator2;
		private System.Windows.Forms.Label SpecialLabel;
		private System.Windows.Forms.PictureBox SpecialCall;
		private System.Windows.Forms.PictureBox SpecialVideo;
		private System.Windows.Forms.Panel Seperator1;
		private System.Windows.Forms.Label CompressLabel;
		private System.Windows.Forms.PictureBox CompressIcon;
		private System.Windows.Forms.Label NewLabel;
		private System.Windows.Forms.PictureBox NewIcon;
		private System.Windows.Forms.PictureBox SettingsButton;
		private System.Windows.Forms.PictureBox SortIcon;
		private System.Windows.Forms.Panel ChatMessageContainer;
		private System.Windows.Forms.PictureBox VoiceIcon;
		private System.Windows.Forms.Panel Seperator3;
		private System.Windows.Forms.PictureBox EmojiIcon;
		private System.Windows.Forms.PictureBox AttachmentIcon;
		private System.Windows.Forms.TextBox ChatMessage;
		private System.Windows.Forms.PictureBox SendIcon;
		private System.Windows.Forms.Panel ChatInfo;
		private System.Windows.Forms.PictureBox RecipientImage;
		private System.Windows.Forms.Label RecipientRealName;
		private System.Windows.Forms.Label RecipientDescription;
		private System.Windows.Forms.Label RecipientUserName;
		private System.Windows.Forms.Panel Seperator4;
		private System.Windows.Forms.Label BlockUserLabel;
		private System.Windows.Forms.PictureBox BlockUserIcon;
		private System.Windows.Forms.Label CleanChatLabel;
		private System.Windows.Forms.PictureBox CleanUserIcon;
		private System.Windows.Forms.PictureBox SocialHubIcon;
		private System.Windows.Forms.Label SocialHubLabel;
		private System.Windows.Forms.Panel Seperator5;
		private Components.QRSocket ClientSocket;
		private System.Windows.Forms.Panel InnerChatContainer;
		private System.Windows.Forms.Panel LoginOverlay;
		private System.Windows.Forms.Label LoginPassWordLabel;
		private System.Windows.Forms.TextBox LoginPassWord;
		private System.Windows.Forms.Label LoginUserNameLabel;
		private System.Windows.Forms.TextBox LoginUserName;
		private System.Windows.Forms.Label LoginTitle;
		private System.Windows.Forms.Button LoginButton;
		private System.Windows.Forms.Button LoginClear;
		private System.Windows.Forms.Label NoChatSelectedLabel;
		private System.Windows.Forms.Label LoginPleaseWait;
	}
}