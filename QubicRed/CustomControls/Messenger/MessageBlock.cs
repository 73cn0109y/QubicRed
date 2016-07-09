using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed.CustomControls.Messenger
{
	public class MessageBlock : Panel
	{
		protected const int PICTURE_SIZE = 100;

		public string Message { set { if(lblMessage != null) lblMessage.Text = value; } }
		public string Date { set { if (lblDate != null) lblDate.Text = value; } }
		public string Sender { get; set; }
		public bool Alternate { get { return alternate; } set { SetAlternate(value); } }

		protected Panel pnlContainer;
		protected Label lblMessage;
		protected Label lblDate;
		protected bool alternate = false;
		protected bool containsPictures = false;

		public MessageBlock()
		{
			BackColor = Color.FromArgb(230, 230, 230);
			ForeColor = Color.Black;
			Size = MinimumSize = new Size(125, 50);
			Font = new Font("Leelawadee UI", 12, FontStyle.Regular);
			Padding = new Padding(1);
			Anchor = AnchorStyles.Left | AnchorStyles.Top;

			pnlContainer = new Panel();
			pnlContainer.BackColor = Color.White;
			pnlContainer.Dock = DockStyle.Fill;

			lblMessage = new Label();
			lblMessage.AutoSize = false;
			lblMessage.TextAlign = ContentAlignment.TopLeft;
			lblMessage.Padding = new Padding(10);
			lblMessage.BackColor = Color.Transparent;

			lblDate = new Label();
			lblDate.AutoSize = false;
			lblDate.Size = new Size(100, 25);
			lblDate.TextAlign = ContentAlignment.MiddleLeft;
			lblDate.Location = new Point(10, pnlContainer.Height - lblDate.Height - 5);
			lblDate.Text = "00:00 AM";
			lblDate.Font = new Font(Font.FontFamily, 8, Font.Style);
			lblDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lblDate.BackColor = Color.Transparent;
			lblDate.ForeColor = Color.FromArgb(150, 150, 150);

			pnlContainer.Controls.Add(lblDate);
			pnlContainer.Controls.Add(lblMessage);
			Controls.Add(pnlContainer);
		}

		public MessageBlock(string[] urls, string msg)
		{
			containsPictures = true;

			BackColor = Color.FromArgb(230, 230, 230);
			ForeColor = Color.Black;
			Size = MinimumSize = new Size(150, PICTURE_SIZE + 25 + 20);
			Font = new Font("Leelawadee UI", 12, FontStyle.Regular);
			Padding = new Padding(1);
			Anchor = AnchorStyles.Left | AnchorStyles.Top;

			pnlContainer = new Panel();
			pnlContainer.BackColor = Color.White;
			pnlContainer.Dock = DockStyle.Fill;

			const int MAX_DISPLAYED_PICTURES = 6;
			int i = 1;
			int x = 10;
			foreach (string url in urls)
			{
				if (i > MAX_DISPLAYED_PICTURES)
					break;

				UploadPictureBox upBox = new UploadPictureBox(url, new Size(PICTURE_SIZE, PICTURE_SIZE));
				upBox.Location = new Point(x, 10);
				upBox.Cursor = Cursors.Hand;
				upBox.MouseClick += Picture_MouseClick;
				upBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;

				pnlContainer.Controls.Add(upBox);

				i++;
				x += upBox.Width + 5;
			}

			lblDate = new Label();
			lblDate.AutoSize = false;
			lblDate.Size = new Size(100, 25);
			lblDate.TextAlign = ContentAlignment.MiddleLeft;
			lblDate.Location = new Point(10, pnlContainer.Height - lblDate.Height - 5);
			lblDate.Text = "00:00 AM";
			lblDate.Font = new Font(Font.FontFamily, 8, Font.Style);
			lblDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lblDate.BackColor = Color.Transparent;
			lblDate.ForeColor = Color.FromArgb(150, 150, 150);

			bool hasMsg = false;

			if (msg != null)
				if (msg.Trim().Length > 0)
					hasMsg = true;

			if (hasMsg)
			{
				lblMessage = new Label();
				lblMessage.AutoSize = false;
				lblMessage.TextAlign = ContentAlignment.TopLeft;
				lblMessage.Padding = new Padding(10);
				lblMessage.BackColor = Color.Transparent;
				lblMessage.Text = msg;
				lblMessage.Location = new Point(0, PICTURE_SIZE + 10);

				pnlContainer.Controls.Add(lblMessage);
			}

			pnlContainer.Controls.Add(lblDate);
			Controls.Add(pnlContainer);

			Task.Run(async () =>
			{
				foreach (UploadPictureBox upBox in pnlContainer.Controls.OfType<UploadPictureBox>())
					await upBox.LoadImage(upBox.Name);
				GC.Collect();
			});
		}

		public void FormatSize()
		{
			using (Graphics g = CreateGraphics())
			{
				int totalHeight = 0;
				int width = 0;
				Size size = default(Size);

				if(containsPictures)
				{
					Size = new Size(15 + (pnlContainer.Controls.OfType<PictureBox>().Count() * (PICTURE_SIZE + 5)), PICTURE_SIZE);

					if (lblMessage != null)
					{
						size = g.MeasureString(lblMessage.Text, Font).ToSize();
						width = size.Width + (lblMessage.Padding.Left * 2) + 10;

						int lines = (int)((float)size.Width / (float)MaximumSize.Width);

						totalHeight += (size.Height * lines) + (lblMessage.Padding.Bottom * 2);
						totalHeight += lblDate.Height;
						totalHeight += 40;
						totalHeight += PICTURE_SIZE;
					}
					else
					{
						totalHeight += lblDate.Height;
						totalHeight += 20;
					}

					if (width < 150)
						width = 150;

					Size = new Size(Math.Max(width, Width), totalHeight);
					if (lblMessage != null)
					{
						lblMessage.Size = new Size(Width, totalHeight - PICTURE_SIZE);
						lblDate.BringToFront();
					}

					foreach (PictureBox pic in pnlContainer.Controls.OfType<PictureBox>())
					{
						if (pic.Location.X + pic.Width > Width)
							pic.Hide();
						else if (!pic.Visible)
							pic.Show();
					}
				}
				else
				{
					if (lblMessage != null)
					{
						size = g.MeasureString(lblMessage.Text, Font).ToSize();

						int lines = (int)((float)size.Width / (float)MaximumSize.Width);

						totalHeight += (size.Height * lines) + (lblMessage.Padding.Bottom * 2);
						totalHeight += lblDate.Height;
						totalHeight += 20;
						width = size.Width + (lblMessage.Padding.Left * 2) + 10;
						if (width < 150)
							width = 150;
						Size = new Size(width, totalHeight);
						lblMessage.Size = new Size(Width, totalHeight);
					}
				}
			}
		}

		private void SetAlternate(bool e)
		{
			if (alternate == e)
				return;

			alternate = e;

			pnlContainer.BackColor = (alternate ? Color.Transparent : Color.White);
		}

		private void Picture_MouseClick(object sender, MouseEventArgs e)
		{
			string file = ((PictureBox)sender).Name;
			if (!File.Exists(file))
			{
				if (file.StartsWith("ftp"))
				{
					file = file.Replace("%3A", ":").Replace("%2F", "/"); // Do my own html decode
					file = file.Substring(file.LastIndexOf("/") + 1, file.Length - file.LastIndexOf("/") - 1);
				}
				file = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Cached", "Images", Path.GetFileName(file));
			}
			if (file.StartsWith("file:\\"))
				file = file.Substring(6, file.Length - 6);
			// Will not work without explorer running
			System.Diagnostics.Process.Start(file); 
		}
	}
}
