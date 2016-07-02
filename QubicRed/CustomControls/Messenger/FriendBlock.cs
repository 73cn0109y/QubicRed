using System;
using System.Drawing;
using System.Windows.Forms;
using QubicRed.Apps;

namespace QubicRed.CustomControls.Messenger
{
	public class FriendBlock : Panel
	{
		public UserInfo User { get; protected set; }
		public Color AppColor { get; set; }
		public bool Selected { get { return _selected; } set { UpdateSelected(value); } }
		public string LastMessage { set { lblLastMessage.Text = value; } }
		public string TimeStamp { set { LastTimeStamp.Text = value; } }

		protected PictureBox UserImage;
		protected Label UserName;
		protected Label LastTimeStamp;
		protected Label lblLastMessage;
		private bool _selected = false;

		public FriendBlock(UserInfo _user, Size size)
		{
			User = _user;

			BackColor = Color.White;
			ForeColor = Color.Black;
			Size = size;
			Cursor = Cursors.Hand;

			UserImage = new PictureBox();
			UserImage.Dock = DockStyle.Left;
			UserImage.Size = new Size(50, 50);
			UserImage.SizeMode = PictureBoxSizeMode.CenterImage;
			UserImage.Image = User.UserImage.DownloadImage(UserImage.Size);
			UserImage.BackColor = Color.Transparent;

			UserName = new Label();
			UserName.AutoSize = true;
			UserName.Text = User.UserName;
			UserName.Location = new Point(UserImage.Width + 10, 10);
			UserName.TextAlign = ContentAlignment.MiddleLeft;
			UserName.BackColor = Color.Transparent;

			LastTimeStamp = new Label();
			LastTimeStamp.AutoSize = true;
			LastTimeStamp.Font = new Font(Font.FontFamily, 8, Font.Style);
			LastTimeStamp.Text = "00:00 PM";
			LastTimeStamp.Location = new Point(UserName.Location.X + UserName.Width - 10, UserName.Location.Y + 2);
			LastTimeStamp.TextAlign = ContentAlignment.MiddleLeft;
			LastTimeStamp.UseCompatibleTextRendering = true;
			LastTimeStamp.ForeColor = Color.FromArgb(200, 200, 200);
			LastTimeStamp.BackColor = Color.Transparent;

			lblLastMessage = new Label();
			lblLastMessage.AutoSize = false;
			lblLastMessage.AutoEllipsis = true;
			lblLastMessage.Size = new Size(Width - UserImage.Width - 10, 25);
			lblLastMessage.Location = new Point(UserImage.Width + 10, Height - lblLastMessage.Height - 10);
			lblLastMessage.Text = "This is where the last received message is shown";
			lblLastMessage.BackColor = Color.Transparent;

			Controls.Add(UserImage);
			Controls.Add(UserName);
			Controls.Add(LastTimeStamp);
			Controls.Add(lblLastMessage);
		}

		private void UpdateSelected(bool e)
		{
			if (_selected == e)
				return;

			_selected = e;

			if (e)
			{
				BackColor = AppColor;
				ForeColor = Color.White;
			}
			else
			{
				BackColor = Color.White;
				ForeColor = Color.Black;
			}
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			e.Control.Cursor = Cursors.Hand;
			e.Control.MouseClick += (se, ev) => { OnMouseClick(ev); };

			base.OnControlAdded(e);
		}
	}
}
