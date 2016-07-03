using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QubicRed.CustomControls.Messenger;
using SocketMessage = QubicRed.Components.QRSocket_Extras.SocketMessage;
using System.IO;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Renci.SshNet;
using System.Net;
using System.Text;

namespace QubicRed.Apps
{
	public partial class Messenger : QRDF
	{
		private const string REMOTE_IMAGE_LOCATION = "ftp://f5-preview.runhosting.com/apps/messenger/images/";

		public UserInfo CurrentUser { get { return currentUser; } set { UpdateCurrentUser(value); } }
		public UserInfo RecipientUser { get { return recipientUser; } set { UpdateRecipientUser(value); } }
		public System.Media.SoundPlayer NotificationSound { get; protected set; }
		public new bool Activated { get; protected set; }
		public Reply.ContentType ChatType { get; protected set; } = Reply.ContentType.String;
		public bool Uploading { get; set; }

		private UserInfo currentUser = null;
		private UserInfo recipientUser = null;
		private FriendBlock SelectedFriend = null;
		private FriendBlock SelectedChat = null;
		private int ConversationID = -1;
		private List<Conversation> Conversations = null;
		private bool alternateChat = true;
		private int unreadMessages = 0;
		private DateTime lastNotification = DateTime.Now;
		private string[] pictureURLs;
		private long uploadTotalSize = 0;
		private long uploadProgressSize = 0;
		private FormWindowState currentState;

		protected Dictionary<string, string> PreDefinedMessage = new Dictionary<string, string>()
		{
			{ "SelectChat", "Select a chat from the left to begin..." },
			{ "TypeRecipient", "Type a message to " }
		};

		protected string[] SupportedExtensions = new string[]
		{
			".png",
			".jpg",
			".bmp",
			".jpeg",
			".tiff",
			".gif"
		};

		public Messenger()
		{
			InitializeComponent();

			ChatsButton.BackColor = AppColor;
			ChatButtonLabel.ForeColor = AppColor;
			ChatButtonLabel.BackColor = PeopleButtonLabel.BackColor = Color.White;

			ChatMessage.SelectionStart = ChatMessage.SelectionLength = 0;

			LoginOverlay.BringToFront();

			NotificationSound = new System.Media.SoundPlayer(@"Audio\Messenger_New_Message.wav");

			currentState = WindowState;
		}

		private void Send()
		{
			if(ChatType == Reply.ContentType.Picture)
			{
				SendPicture();
				return;
			}
			if (CurrentUser == null || RecipientUser == null)
				return;
			string Message = ChatMessage.Text.Trim();
			if (string.IsNullOrEmpty(Message))
				return;
			if (Message == PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName)
				return;
			SocketMessage msg = new SocketMessage(
				new object[] { "ConversationID", ConversationID },
				new object[] { "SenderID", CurrentUser.ID },
				new object[] { "RecipientID", RecipientUser.ID },
				new object[] { "Sender", CurrentUser.UserName },
				new object[] { "Message", ChatMessage.Text.Trim() },
				new object[] { "TimeStamp", DateTime.UtcNow.ToString("MM-dd-yyyy HH:mm:ss") },
				new object[] { "DataType", ChatType },
				new object[] { "Links", new object[] { } }
			);
			ClientSocket.Send("message", msg);
			ChatMessage.Text = PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName;
			ChatMessage.SelectionLength = ChatMessage.SelectionStart = 0;
			ChatMessage.ForeColor = Color.FromArgb(150, 150, 150);
			ChatType = Reply.ContentType.String;
			SendIcon.Image = Properties.Resources.send_disabled;

			ClientSocket.Send("typing", new SocketMessage(
				new object[] { "typing", false },
				new object[] { "RecipientID", RecipientUser.ID }
			));
		}

		private void SendPicture()
		{
			if(Uploading)
			{
				MessageBox.Show("Please wait until the uploading is complete!");
				return;
			}
			if (CurrentUser == null || RecipientUser == null)
				return;
			string message = ChatMessage.Text.Trim();
			if (message == PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName)
				message = "";
			SocketMessage msg = new SocketMessage(
				new object[] { "ConversationID", ConversationID },
				new object[] { "SenderID", CurrentUser.ID },
				new object[] { "RecipientID", RecipientUser.ID },
				new object[] { "Sender", CurrentUser.UserName },
				new object[] { "Message", message },
				new object[] { "TimeStamp", DateTime.UtcNow.ToString("MM-dd-yyyy HH:mm:ss") },
				new object[] { "DataType", ChatType },
				new object[] { "Links", pictureURLs }
			);
			ClientSocket.Send("message", msg);
			ChatMessage.Text = PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName;
			ChatMessage.SelectionLength = ChatMessage.SelectionStart = 0;
			ChatMessage.ForeColor = Color.FromArgb(150, 150, 150);
			ChatType = Reply.ContentType.String;
			pictureURLs = null;
			SendIcon.Image = Properties.Resources.send_disabled;

			foreach (var upPic in UploadContainer.Controls.OfType<UploadPictureBox>())
				upPic?.Dispose();

			UploadHiddenItems.Text = "";
			UploadProgressPercent.Text = "0%";
			UploadContainer.Hide();

			ClientSocket.Send("typing", new SocketMessage(
				new object[] { "typing", false },
				new object[] { "RecipientID", RecipientUser.ID }
			));
		}

		private void ToggleEmojis() { }

		private void AttachFile() { }

		private void VoiceInput() { }

		private void ResizeChat(bool resizeWindow = false)
		{
			if (InnerChatContainer.Controls.Count <= 0)
				return;
			if (CurrentUser == null)
				return;
			if (RecipientUser == null)
				return;

			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { ResizeChat(resizeWindow); }));
				return;
			}

			bool bottom = InnerChatContainer.VerticalScroll.Value + InnerChatContainer.Height + 1 >= InnerChatContainer.VerticalScroll.Maximum;
			Point autoScroll = InnerChatContainer.AutoScrollPosition;

			InnerChatContainer.AutoScrollPosition = new Point(0, 0);

			int y = 5;
			foreach (MessageBlock msg in InnerChatContainer.Controls.OfType<MessageBlock>())
			{
				if (msg.Sender != CurrentUser.UserName)
					msg.Alternate = true;
				else
					msg.Alternate = false;

				Invoke(new MethodInvoker(() =>
				{
					msg.MaximumSize = new Size(((InnerChatContainer.Width - 20) / 2) - 20, int.MaxValue);
					msg.FormatSize();

					int x = msg.Sender.ToLower() == CurrentUser.UserName.ToLower() ?
						(InnerChatContainer.Width - msg.Width - 30) : 20;

					msg.Location = new Point(x, y);
				}));

				y += msg.Height + 10;
			}

			if (bottom || resizeWindow)
				InnerChatContainer.ScrollControlIntoView(InnerChatContainer.Controls[InnerChatContainer.Controls.Count - 1]);
			else
			{
				unreadMessages++;
				ChatUnreadMessage.Text = "You have " + unreadMessages + " unread message" + (unreadMessages > 1 ? "s" : "");
				ChatUnreadMessage.Show();
				InnerChatContainer.AutoScrollPosition = new Point(-autoScroll.X, -autoScroll.Y);
			}

			if (Uploading)
			{
				int maxX = UploadHiddenItems.Location.X;
				int hidden = 0;
				foreach (UploadPictureBox upBox in UploadContainer.Controls.OfType<UploadPictureBox>())
				{
					if (upBox.Location.X + upBox.Width >= maxX)
					{
						hidden++;
						upBox.Visible = false;
					}
					else if (!upBox.Visible)
						upBox.Visible = true;
				}

				if (hidden == 0)
					UploadHiddenItems.Visible = false;
				else
					UploadHiddenItems.Text = "+" + hidden;
			}

			UserTyping.Location = new Point((ChatContainer.Width / 2 - (UserTyping.Width / 2)), UserTyping.Location.Y);
		}

		private void Login()
		{
			LoginStatus.Text = "Logging in...";

			string username = LoginUserName.Text;
			string password = LoginPassWord.Text;

			ClientSocket.Send("login", new SocketMessage(
				new object[] { "UserName", username },
				new object[] { "PassWord", password }));
		}

		private void LoginResult(object e)
		{
			SocketMessage msg = new SocketMessage(e);
			object error = msg.GetValue("Error");
			if (error != null)
			{
				return;
			}
			object id = msg.GetValue("ID");
			int userID = -1;
			if (id != null)
				userID = int.Parse(id.ToString());
			CurrentUser = new UserInfo(
				userID,
				msg.GetValue("UserName")?.ToString(),
				msg.GetValue("RealName")?.ToString(),
				msg.GetValue("Description")?.ToString(),
				msg.GetValue("UserImage")?.ToString()
			);
			ClientSocket.Send("friendslist", new SocketMessage(new object[] { "UserName", CurrentUser.UserName }));
		}

		private void FriendsListResult(object e)
		{
			if(InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { FriendsListResult(e); }));
				return;
			}

			List<Friend> friendList = ExtJson.DeserializeToList<Friend>(JsonConvert.SerializeObject(e)).ToList();

			ClientSocket.Send("conversations", new SocketMessage(new object[] { "UserName", CurrentUser.UserName }));
		}

		private void ConversationsResult(object e)
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { ConversationsResult(e); }));
				return;
			}

			Conversations = JsonConvert.SerializeObject(e).DeserializeToList<Conversation>().ToList();

			if (Conversations.Count > 0)
				NoChatsLabel?.Dispose();

			foreach(Conversation conv in Conversations)
			{
				FriendBlock block = new FriendBlock(conv.Recipient, new Size(SideBarContainer.Width, 75));
				block.AppColor = AppColor;
				block.MouseClick += ConversationBlock_MouseClick;
				block.Location = new Point(0, SideBarContainer.Controls.Count * 75);
				SideBarContainer.Controls.Add(block);

				if (conv.Replies.Count > 0)
				{
					Reply lastReply = conv.Replies[conv.Replies.Count - 1];

					string timeStamp = lastReply.TimeStamp;
					timeStamp = DateTime.Parse(timeStamp).ToString("h:mm tt");

					block.LastMessage = lastReply.Message;
					block.TimeStamp = timeStamp;
				}
			}
		}

		private void UpdateCurrentUser(UserInfo e)
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { UpdateCurrentUser(e); }));
				return;
			}

			currentUser = e;

			UserName.Text = CurrentUser.UserName;
			UserPicture.Image = CurrentUser.UserImage.DownloadImage(UserPicture.Size);

			ViewProfileButton.Show();
			LoginOverlay.Hide();

			if (RecipientUser == null)
				ChatMessage.Text = PreDefinedMessage["SelectChat"];
			else
				ChatMessage.Text = PreDefinedMessage["TypeRecipient"];
		}

		private void UpdateRecipientUser(UserInfo e)
		{
			recipientUser = e;

			RecipientUserName.Text = recipientUser.UserName;
			RecipientRealName.Text = recipientUser.RealName;
			RecipientDescription.Text = recipientUser.Description;
			RecipientImage.Image = recipientUser.UserImage.DownloadImage(RecipientImage.Size);
			RecipientUser.IsTyping += RecipientUser_IsTyping;

			ChatMessage.Text = PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName;
			ChatMessage.SelectionLength = ChatMessage.SelectionStart = 0;

			RecipientUserName.Location = new Point(RecipientRealName.Location.X + RecipientRealName.Width + 6, RecipientRealName.Location.Y);
		}

		private void SwitchLayouts(bool alternate)
		{
			if (alternateChat == alternate)
				return;

			alternateChat = alternate;
			ResizeChat();
		}

		private void CompressSidebar()
		{
			bool compress = SideBar.Width > 50;

			if (compress)
				SideBar.Size = new Size(50, SideBar.Height);
			else
				SideBar.Size = new Size(300, SideBar.Height);

			PeoplesButton.Visible = ChatsButton.Visible = !compress;
			SideBarContainer.Location = new Point(0, (compress ?
				ChatsButton.Location.Y :
				(ChatsButton.Location.Y + ChatsButton.Height)));
			SideBarContainer.Size = new Size(SideBarContainer.Width, (compress ?
				(SideBar.Height - ChatsButton.Location.Y) :
				(SideBar.Height - (ChatsButton.Location.Y + ChatsButton.Height))));


			ChatContainer.Size = new Size(Width - SideBar.Width, ChatContainer.Height);
			ChatContainer.Location = new Point(SideBar.Width, ChatContainer.Location.Y);
			ResizeChat();
		}

		private void RecipientUser_IsTyping()
		{
			Invoke(new MethodInvoker(() =>
			{
				bool typing = RecipientUser.UserTyping;

				if (typing)
				{
					if (!UserTyping.Visible)
						UserTyping.Show();
					UserTyping.Text = RecipientUser.UserName + " is typing...";
					UserTyping.BringToFront();
					UserTyping.Location = new Point(ChatContainer.Width / 2 - (UserTyping.Width / 2), UserTyping.Location.Y);
				}
				else
					UserTyping.Hide();
			}));
		}

		private void Upload_ProgressChanged(object sender, double e)
		{
			Invoke(new MethodInvoker(() =>
			{
				LoginStatus.Text = "Upload is " + e + "% complete...";
			}));
		}

		private void FriendBlock_MouseClick(object sender, MouseEventArgs e)
		{
			FriendBlock block = sender as FriendBlock;

			if (block == null)
				return;
			if (block == SelectedFriend)
				return;

			if(SelectedFriend != null)
				SelectedFriend.Selected = false;

			SelectedFriend = block;
			SelectedFriend.Selected = true;
		}

		private void ConversationBlock_MouseClick(object sender, MouseEventArgs e)
		{
			FriendBlock block = sender as FriendBlock;

			if (block == null)
				return;
			if (block == SelectedChat)
				return;

			if (SelectedChat != null)
				SelectedChat.Selected = false;

			SelectedChat = block;
			SelectedChat.Selected = true;

			RecipientUser = SelectedChat.User;
			ChatInfo.Show();

			if (NoChatSelectedLabel.IsDisposed)
			{
				Invoke(new MethodInvoker(() =>
				{
					InnerChatContainer.Controls.Clear();
				}));
			}

			ConversationID = -1;

			foreach (Reply reply in Conversations.Where(x => x.Recipient == RecipientUser).FirstOrDefault().Replies)
			{
				if (ConversationID == -1)
					ConversationID = reply.ConversationID;

				MessageBlock msgBlock;

				if (reply.DataType == Reply.ContentType.Picture)
					msgBlock = new MessageBlock(reply.Links, reply.Message);
				else
					msgBlock = new MessageBlock();

				msgBlock.Message = reply.Message;
				msgBlock.Sender = reply.SenderID == CurrentUser.ID ? CurrentUser.UserName : RecipientUser.UserName;
				msgBlock.Date = DateTime.Parse(reply.TimeStamp).ToString("h:mm tt");
				msgBlock.MaximumSize = new Size(((InnerChatContainer.Width - 20) / 2) - 20, int.MaxValue);

				Invoke(new MethodInvoker(() => { msgBlock.FormatSize(); InnerChatContainer.Controls.Add(msgBlock); }));
			}

			ResizeChat();

			NoChatSelectedLabel?.Dispose();
		}

		private void Seperator_Paint(object sender, PaintEventArgs e)
		{
			Panel se = (Panel)sender;
			Color c = se.BackColor == Color.White ? Color.FromArgb(75, 0, 0, 0) : Color.FromArgb(75, 255, 255, 255);
			using (Brush brush = new SolidBrush(c))
			{
				Rectangle r = new Rectangle((se.Width / 2) - 1, (int)((se.Height / 8) * 2.5), 1, (int)(((se.Height / 8) * 3.5)));
				e.Graphics.FillRectangle(brush, r);
			}
		}

		#region Chat Message
		private void ChatMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (RecipientUser == null)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
				return;
			}
			if (ChatMessage.Text == PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName)
			{
				ChatMessage.Text = "";
				ChatMessage.ForeColor = Color.Black;
			}
			if(e.KeyCode == Keys.Enter) // Stops windows sound
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		private void ChatMessage_KeyUp(object sender, KeyEventArgs e)
		{
			if(RecipientUser != null)
			{
				ClientSocket.Send("typing", new SocketMessage(
						new object[] { "typing", !(ChatMessage.Text.Length == 0) },
						new object[] { "RecipientID", RecipientUser.ID }
					));
			}

			if (ChatMessage.Text.Length == 0)
			{
				if (RecipientUser == null)
					ChatMessage.Text = PreDefinedMessage["SelectChat"];
				else
					ChatMessage.Text = PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName;
				ChatMessage.ForeColor = Color.FromArgb(150, 150, 150);
			}
			if (e.KeyCode == Keys.Enter)
			{
				Send();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}

			SendIcon.Image = (ChatMessage.ForeColor == Color.Black ?
				Properties.Resources.send :
				Properties.Resources.send_disabled);
		}

		private void ChatMessage_TextChanged(object sender, EventArgs e)
		{
			if (RecipientUser == null)
			{
				ChatMessage.Text = PreDefinedMessage["SelectChat"];
				ChatMessage.SelectionStart = ChatMessage.SelectionLength = 0;
			}
		}
		#endregion

		private void SendIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				Send();
		}

		#region Block User
		private void BlockUserLabel_MouseEnter(object sender, EventArgs e)
		{
			BlockUserLabel.ForeColor = AppColor;
		}

		private void BlockUserLabel_MouseLeave(object sender, EventArgs e)
		{
			BlockUserLabel.ForeColor = Color.Black;
		}
		#endregion

		#region Clean Chat
		private void CleanChatLabel_MouseEnter(object sender, EventArgs e)
		{
			CleanChatLabel.ForeColor = AppColor;
		}

		private void CleanChatLabel_MouseLeave(object sender, EventArgs e)
		{
			CleanChatLabel.ForeColor = Color.Black;
		}
		#endregion

		private void EmojiIcon_MouseClick(object sender, MouseEventArgs e)
		{
			ToggleEmojis();
		}

		private void AttachmentIcon_MouseClick(object sender, MouseEventArgs e)
		{
			AttachFile();
		}

		private void VoiceIcon_MouseClick(object sender, MouseEventArgs e)
		{
			VoiceInput();
		}

		#region Social Hub
		private void SocialHubLabel_MouseEnter(object sender, EventArgs e)
		{
			SocialHubLabel.ForeColor = AppColor;
		}

		private void SocialHubLabel_MouseLeave(object sender, EventArgs e)
		{
			SocialHubLabel.ForeColor = Color.Black;
		}
		#endregion

		#region Compress
		private void CompressLabel_MouseEnter(object sender, EventArgs e)
		{
			CompressLabel.ForeColor = AppColor;
		}

		private void CompressLabel_MouseLeave(object sender, EventArgs e)
		{
			CompressLabel.ForeColor = Color.Black;
		}
		#endregion

		#region New
		private void NewLabel_MouseEnter(object sender, EventArgs e)
		{
			NewLabel.ForeColor = AppColor;
		}

		private void NewLabel_MouseLeave(object sender, EventArgs e)
		{
			NewLabel.ForeColor = Color.Black;
		}
		#endregion

		private void ChatContainer_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.FromArgb(50, 0, 0, 0)), new Point(0, 0), new Point(0, ChatContainer.Height));
		}

		private void ChatInfo_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.FromArgb(50, 0, 0, 0)), new Point(0, ChatInfo.Height - 1), new Point(ChatInfo.Width, ChatInfo.Height - 1));
		}

		private void SideBarOptions_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.FromArgb(50, 0, 0, 0)), new Point(0, SideBarOptions.Height - 1), new Point(SideBarOptions.Width, SideBarOptions.Height - 1));
		}

		private void ClientSocket_OnMessagereceived(SocketMessage e)
		{
			string dataString = e.GetValue("DataType") == null ? "" : e.GetValue("DataType").ToString();
			Reply.ContentType dataType = (Reply.ContentType)Enum.Parse(typeof(Reply.ContentType), dataString);

			string[] urls = null;

			if(e.Data.ContainsKey("Links"))
				urls = JsonConvert.DeserializeObject<string[]>(JsonConvert.SerializeObject(e.Data["Links"]));

			MessageBlock block;

			if (dataType == Reply.ContentType.Picture && urls != null)
				block = new MessageBlock(urls, e.GetValue("Message").ToString());
			else
				block = new MessageBlock();

			string timeStamp = e.GetValue("TimeStamp").ToString();
			timeStamp = DateTime.Parse(timeStamp).ToString("h:mm tt");

			block.Message = e.GetValue("Message").ToString();
			block.Sender = e.GetValue("Sender").ToString();
			block.Date = timeStamp;
			block.MaximumSize = new Size(((InnerChatContainer.Width - 20) / 2) - 20, int.MaxValue);

			Invoke(new MethodInvoker(() =>
			{
				block.FormatSize();

				InnerChatContainer.Controls.Add(block);

				SelectedChat.LastMessage = e.GetValue("Message").ToString();
				SelectedChat.TimeStamp = timeStamp;
			}));

			if((DateTime.Now - lastNotification).TotalSeconds > 5 && block.Sender != CurrentUser.UserName && !Activated)
			{
				lastNotification = DateTime.Now;
				NotificationSound.Play();
			}

			ResizeChat();
		}

		private void ClientSocket_SocketEvent(Components.SocketEvent e)
		{
			switch (e.Name.ToLower())
			{
				case "connected":
					if ((bool)e.Data)
						ClientSocket.RegisterModule("messenger");
					break;
				case "moduleregistered":
					Invoke(new MethodInvoker(() =>
					{
						LoginButton.Enabled = true;
						LoginStatus.Text = "Connection Successful!";
					}));
					break;
				case "login":
					LoginResult(e.Data);
					break;
				case "friendslist":
					FriendsListResult(e.Data);
					break;
				case "conversations":
					ConversationsResult(e.Data);
					break;
				case "typing":
					SocketMessage msg = new SocketMessage(e.Data);
					if (RecipientUser != null)
						RecipientUser.UserTyping = bool.Parse(msg.GetValue("typing").ToString());
					break;
			}
		}

		protected override void OnShown(EventArgs e)
		{
			ClientSocket.Init();

			base.OnShown(e);
		}

		protected override void OnActivated(EventArgs e)
		{
			Activated = true;

			base.OnActivated(e);
		}

		protected override void OnDeactivate(EventArgs e)
		{
			Activated = false;

			base.OnDeactivate(e);
		}

		protected override void OnResizeEnd(EventArgs e)
		{
			base.OnResizeEnd(e);

			if (IsHandleCreated)
				ResizeChat(true);
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0005)
			{
				if (WindowState != currentState)
					ResizeChat(true);
				currentState = WindowState;
			}
			base.WndProc(ref m);
		}

		private void LoginButton_MouseClick(object sender, MouseEventArgs e)
		{
			Login();
		}

		private void LoginClear_MouseClick(object sender, MouseEventArgs e)
		{
			LoginUserName.Text = "";
			LoginPassWord.Text = "";
			LoginUserName.Focus();
		}

		private void LoginOverlay_Paint(object sender, PaintEventArgs e)
		{

		}

		private void ViewAlternate_MouseClick(object sender, MouseEventArgs e)
		{
			SwitchLayouts(true);
		}

		private void ViewInLine_MouseClick(object sender, MouseEventArgs e)
		{
			SwitchLayouts(false);
		}

		private void CompressIcon_MouseClick(object sender, MouseEventArgs e)
		{
			CompressSidebar();
		}

		private void CompressLabel_MouseClick(object sender, MouseEventArgs e)
		{
			CompressSidebar();
		}

		private void ChatUnreadMessage_MouseClick(object sender, MouseEventArgs e)
		{
			unreadMessages = 0;
			if (InnerChatContainer.Controls.Count <= 1)
				return;
			InnerChatContainer.ScrollControlIntoView(InnerChatContainer.Controls[InnerChatContainer.Controls.Count - 1]);
			ChatUnreadMessage.Hide();
		}

		private void NoChatSelectedLabel_Click(object sender, EventArgs e)
		{

		}

		private void InnerChatContainer_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
				UploadDropHere.Show();
				UploadDropHere.BringToFront();
			}
			else
				UploadDropHere.Hide();
		}

		private void InnerChatContainer_DragLeave(object sender, EventArgs e)
		{
			UploadDropHere.Hide();
		}

		private void InnerChatContainer_DragDrop(object sender, DragEventArgs e)
		{
			UploadDropHere.Hide();

			string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

			if (files == null)
				return;
			if (files.Length <= 0)
				return;

			foreach (string file in files)
			{
				if (!SupportedExtensions.Contains(Path.GetExtension(file)))
				{
					MessageBox.Show("Unsupported file detected!");
					return;
				}
			}

			string[] serverNames = new string[files.Length];

			foreach (var upPic in UploadContainer.Controls.OfType<UploadPictureBox>())
				upPic?.Dispose();

			UploadTotalProgressBar.Size = new Size(0, UploadTotalProgressBar.Height);

			ChatType = Reply.ContentType.Picture;
			Uploading = true;
			uploadTotalSize = uploadProgressSize = 0;
			UploadContainer.Show();
			int x, y;
			int h = UploadContainer.Height - 10;
			int cc = 1;

			x = y = 10;

			if (files.Length > 5)
				UploadHiddenItems.Text = "+" + (files.Length - 5).ToString();

			UploadHiddenItems.Visible = files.Length > 5;

			foreach (string file in files)
			{
				uploadTotalSize += new FileInfo(file).Length;

				if (cc > 5)
					continue;

				UploadPictureBox upPicture = new UploadPictureBox(file, new Size(h, h));
				upPicture.Location = new Point(x, y);

				UploadContainer.Controls.Add(upPicture);

				x += upPicture.Width + 5;

				cc++;
			}
			Task.Run(async () =>
			{
				UploadPictureBox[] upBoxes = UploadContainer.Controls.OfType<UploadPictureBox>().ToArray();

				for(int c = 0; c < upBoxes.Length; c++)
					await upBoxes[c].LoadImage(upBoxes[c].Name);

				for(int c = 0; c < upBoxes.Length; c++)
				{
					string dest = REMOTE_IMAGE_LOCATION + Guid.NewGuid() + Path.GetExtension(upBoxes[c].Name);
					serverNames[c] = dest;
					await upBoxes[c].Upload(upBoxes[c].Name,
						dest,
						new NetworkCredential("2159860_user", "Qub1cR3dSt0rag3"),
						UploadProgress);
				}

				if(files.Length > 5) // Upload all the files that aren't actually shown in the preview bar
				{
					for (int i = 5; i < files.Length; i++)
					{
						const int CHUNK_SIZE = (1024 * 1024) / 2;
						string source = files[i];
						string destination = REMOTE_IMAGE_LOCATION + Guid.NewGuid() + Path.GetExtension(source);
						int chunk = CHUNK_SIZE;

						serverNames[i] = destination; 

						FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destination);
						request.Method = WebRequestMethods.Ftp.UploadFile;
						request.Credentials = new NetworkCredential("2159860_user", "Qub1cR3dSt0rag3");

						using (Stream inputStream = File.Open(source, FileMode.Open, FileAccess.Read))
						using (Stream stream = request.GetRequestStream())
						{
							request.ContentLength = inputStream.Length;

							if (request.ContentLength <= chunk)
							{
								byte[] buffer = new byte[inputStream.Length];
								inputStream.Read(buffer, 0, buffer.Length);
								await stream.WriteAsync(buffer, 0, buffer.Length);
								UploadProgress(buffer.Length);
							}
							else
							{
								chunk = Math.Min((int)inputStream.Length / 100, CHUNK_SIZE);

								byte[] buffer = new byte[chunk];
								int totalReadBytesCount = 0;
								int readBytesCount;

								while ((readBytesCount = inputStream.Read(buffer, 0, buffer.Length)) > 0)
								{
									await stream.WriteAsync(buffer, 0, readBytesCount);
									totalReadBytesCount += readBytesCount;
									UploadProgress(readBytesCount);
								}
							}
						}
					}
				}

				SendIcon.Image = Properties.Resources.send;
				pictureURLs = serverNames;

				Uploading = false;
			});
		}

		private void UploadProgress(long progress)
		{
			if(InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { UploadProgress(progress); }));
				return;
			}

			uploadProgressSize += progress;
			double percent = (double)uploadProgressSize / (double)uploadTotalSize * 100.0;
			double percentWidth =  percent * UploadContainer.Width / 100.0;
			UploadTotalProgressBar.Size = new Size((int)percentWidth, UploadTotalProgressBar.Height);
			UploadProgressPercent.Text = Math.Round(percent).ToString() + "%";
		}
	}

	public class UserInfo : IDisposable
	{
		public delegate void Typing();
		public event Typing IsTyping;

		public int ID { get; set; }
		public string UserName { get; set; }
		public string RealName { get; set; }
		public string Description { get; set; }
		public string UserImage { get; set; }
		public bool UserTyping { get { return userTyping; }set { userTyping = value; IsTyping?.Invoke(); } }

		protected bool userTyping = false;

		public UserInfo() { }
		public UserInfo(int _id, string _username, string _realname, string _description, string _userimage)
		{
			ID = _id;
			UserName = _username;
			RealName = _realname;
			Description = _description;
			UserImage = _userimage;
		}

		#region Dispose
		private bool disposed = false;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				ID = -1;
				UserName = null;
				RealName = null;
				Description = null;
				UserImage = null;
			}

			disposed = true;
		}
		~UserInfo()
		{
			Dispose(false);
		}
		#endregion
	}

	public class Friend
	{
		public int UserID { get; set; }
		public int FriendID { get; set; }
	}

	public class Conversation
	{
		public UserInfo Recipient { get; set; }
		public List<Reply> Replies { get; set; }
	}

	public class Reply
	{
		public enum ContentType : int
		{
			String,
			Picture
		}

		public int ID { get; set; }
		public int ConversationID { get; set; }
		public int SenderID { get; set; }
		public int RecipientID { get; set; }
		public string Message { get; set; }
		public string TimeStamp { get; set; }
		public ContentType DataType { get; set; } = ContentType.String;
		public UserInfo SenderInfo { get; set; }
		public string[] Links { get; set; }
	}


	public static class ExtJson
	{
		public static List<string> InvalidJsonElements;
		public static IList<T> DeserializeToList<T>(this string jsonString)
		{
			InvalidJsonElements = null;
			var array = JArray.Parse(jsonString);
			IList<T> objectsList = new List<T>();

			foreach (var item in array)
			{
				try
				{
					// CorrectElements
					objectsList.Add(item.ToObject<T>());
				}
				catch (Exception ex)
				{
					InvalidJsonElements = InvalidJsonElements ?? new List<string>();
					InvalidJsonElements.Add(item.ToString());
				}
			}

			return objectsList;
		}
	}
}
