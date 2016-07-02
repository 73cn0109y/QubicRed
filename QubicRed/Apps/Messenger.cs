using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QubicRed.CustomControls.Messenger;
using Dropbox.Api;
using SocketMessage = QubicRed.Components.QRSocket_Extras.SocketMessage;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Dropbox.Api.Files;
using System.Drawing.Imaging;
using System.Net;

namespace QubicRed.Apps
{
	public partial class Messenger : QRDF
	{
		public UserInfo CurrentUser { get { return currentUser; } set { UpdateCurrentUser(value); } }
		public UserInfo RecipientUser { get { return recipientUser; } set { UpdateRecipientUser(value); } }
		public System.Media.SoundPlayer NotificationSound { get; protected set; }
		public new bool Activated { get; protected set; }

		private UserInfo currentUser = null;
		private UserInfo recipientUser = null;
		private FriendBlock SelectedFriend = null;
		private FriendBlock SelectedChat = null;
		private int ConversationID = -1;
		private List<Conversation> Conversations = null;
		private bool alternateChat = true;
		private int unreadMessages = 0;
		private DateTime lastNotification = DateTime.Now;

		protected Dictionary<string, string> PreDefinedMessage = new Dictionary<string, string>()
		{
			{ "SelectChat", "Select a chat from the left to begin..." },
			{ "TypeRecipient", "Type a message to " }
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
		}

		private void Send()
		{
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
				new object[] { "DataType", 0}
			);
			ClientSocket.Send("message", msg);
			ChatMessage.Text = PreDefinedMessage["TypeRecipient"] + RecipientUser.UserName;
			ChatMessage.SelectionLength = ChatMessage.SelectionStart = 0;
			ChatMessage.ForeColor = Color.FromArgb(150, 150, 150);
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

				int x = msg.Sender.ToLower() == CurrentUser.UserName.ToLower() ?
				(InnerChatContainer.Width - msg.Width - 30) : 20;

				Invoke(new MethodInvoker(() => { msg.Location = new Point(x, y); }));
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

			//if (friendList.Count > 0)
				//NoChatsLabel?.Dispose();

			/*foreach (Friend friend in friendList)
			{
				UserInfo userInfo = new UserInfo(friend.FriendID, "UserName", "RealName", "Description", null);
				FriendBlock block = new FriendBlock(userInfo, new Size(SideBarContainer.Width, 75));
				block.AppColor = AppColor;

				block.MouseClick += FriendBlock_MouseClick;

				block.Location = new Point(0, SideBarContainer.Controls.Count * 75);
				SideBarContainer.Controls.Add(block);
			}*/

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

		private async Task<bool> Upload(string fileName)
		{
			if (!File.Exists(fileName))
				return false;

			using (DropboxClient dbx = new DropboxClient("iuvg5K38P2EAAAAAAAAGkRJPuLrbD0tShTADR4vgbs7TRnFu3IXD32l48e4KQ6UN"))
			{
				Progress<double> progress = new Progress<double>();
				progress.ProgressChanged += Upload_ProgressChanged;
				await Dropbox.Upload(dbx, fileName, "/" + Path.GetFileName(fileName), progress);
			}

			return true;
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

				MessageBlock msgBlock = new MessageBlock();
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
			string timeStamp = e.GetValue("TimeStamp").ToString();
			timeStamp = DateTime.Parse(timeStamp).ToString("h:mm tt");

			MessageBlock block = new MessageBlock();
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

			if((DateTime.Now - lastNotification).TotalSeconds > 5)
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
			}
		}

		protected override void OnShown(EventArgs e)
		{
			ClientSocket.Init();

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				// Dropbox
				Task.Run(() => { return Upload(ofd.FileName); });

				// Mega.NZ
				//MegaNZ.UploadWithProgression(@"E:\Pictures\Windows 10 Google\001.png");
			}
			ofd.Dispose();

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
			if (IsHandleCreated)
				ResizeChat(true);

			base.OnResizeEnd(e);
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
	}

	public class UserInfo : IDisposable
	{
		public int ID { get; set; }
		public string UserName { get; set; }
		public string RealName { get; set; }
		public string Description { get; set; }
		public string UserImage { get; set; }

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
		public int ID { get; set; }
		public int ConversationID { get; set; }
		public int SenderID { get; set; }
		public int RecipientID { get; set; }
		public string Message { get; set; }
		public string TimeStamp { get; set; }
		public int DataType { get; set; }
		public UserInfo SenderInfo { get; set; }
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
