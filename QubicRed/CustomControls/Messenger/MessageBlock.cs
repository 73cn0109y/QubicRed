using System;
using System.Drawing;
using System.Windows.Forms;

namespace QubicRed.CustomControls.Messenger
{
	public class MessageBlock : Panel
	{
		public string Message { set { if(lblMessage != null) lblMessage.Text = value; } }
		public string Date { set { if (lblDate != null) lblDate.Text = value; } }
		public string Sender { get; set; }

		protected Panel pnlContainer;
		protected Label lblMessage;
		protected Label lblDate;

		public MessageBlock()
		{
			BackColor = Color.FromArgb(150, 150, 150);
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

			lblDate = new Label();
			lblDate.AutoSize = false;
			lblDate.Size = new Size(100, 25);
			lblDate.TextAlign = ContentAlignment.MiddleLeft;
			lblDate.Location = new Point(10, pnlContainer.Height - lblDate.Height);
			lblDate.Text = "00:00 AM";
			lblDate.Font = new Font(Font.FontFamily, 8, Font.Style);
			lblDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

			pnlContainer.Controls.Add(lblDate);
			pnlContainer.Controls.Add(lblMessage);
			Controls.Add(pnlContainer);
		}

		public void FormatSize()
		{
			using (Graphics g = CreateGraphics())
			{
				int totalHeight = 0;
				Size size = g.MeasureString(lblMessage.Text, Font).ToSize();

				int lines = (int)((float)size.Width / (float)MaximumSize.Width);

				totalHeight += (size.Height * lines) + (lblMessage.Padding.Bottom * 2);
				totalHeight += lblDate.Height;
				totalHeight += 15;
				Size = new Size(size.Width + (lblMessage.Padding.Left * 2) +10, totalHeight);
				lblMessage.Size = new Size(Width, totalHeight);
			}
		}
	}
}
