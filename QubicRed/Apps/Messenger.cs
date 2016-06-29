using System;
using System.Drawing;
using System.Windows.Forms;

namespace QubicRed.Apps
{
	public partial class Messenger : QRDF
	{
		public Messenger()
		{
			InitializeComponent();

			ChatsButton.BackColor = AppColor;
			ChatButtonLabel.ForeColor = AppColor;
			ChatButtonLabel.BackColor = PeopleButtonLabel.BackColor = Color.White;

			ChatMessage.SelectionStart = 0;
			ChatMessage.SelectionLength = 0;
		}

		private void Send()
		{
			string Message = ChatMessage.Text.Trim();
			if (string.IsNullOrEmpty(Message))
				return;
			string data = "{Sender:\"Test\",Message:\"" + Message + "\"}";
		}

		private void ToggleEmojis() { }

		private void AttachFile() { }

		private void VoiceInput() { }

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
			if (ChatMessage.Text.StartsWith("Type a message to"))
				ChatMessage.Text = "";
		}

		private void ChatMessage_KeyUp(object sender, KeyEventArgs e)
		{
			if (ChatMessage.Text.Length == 0)
				ChatMessage.Text = "Type a message to";
			if(e.KeyCode == Keys.Enter)
				Send();
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
	}
}
