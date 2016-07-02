using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QubicRed
{
	public partial class QRDF : Form
	{
		public new string Text { get { return Title.Text; } set { Title.Text = value; } }

		public Color AppColor
		{
			get
			{
				return HeaderBar.BackColor;
			}
			set
			{
				BackColor = HeaderBar.BackColor = value;
				ExtendedBar.BackColor = Color.FromArgb(240, value);
			}
		}

		protected bool canDragWindow = false;
		protected Point dragStartPosition = new Point(-1, -1);

		public QRDF()
		{
			InitializeComponent();
		}

		#region Close Button
		private void CloseButton_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				Close();
		}

		private void CloseButton_MouseDown(object sender, MouseEventArgs e)
		{
			CloseButton.BackColor = Color.FromArgb(50, 255, 255, 255);
		}

		private void CloseButton_MouseEnter(object sender, EventArgs e)
		{
			CloseButton.BackColor = Color.FromArgb(30, 255, 255, 255);
		}

		private void CloseButton_MouseLeave(object sender, EventArgs e)
		{
			CloseButton.BackColor = Color.Transparent;
		}

		private void CloseButton_MouseUp(object sender, MouseEventArgs e)
		{
			CloseButton.BackColor = Color.FromArgb(30, 255, 255, 255);
		}
		#endregion

		#region State Button
		private void StateButton_MouseClick(object sender, MouseEventArgs e)
		{
			WindowState = (WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized);
		}

		private void StateButton_MouseDown(object sender, MouseEventArgs e)
		{
			StateButton.BackColor = Color.FromArgb(50, 255, 255, 255);
		}

		private void StateButton_MouseEnter(object sender, EventArgs e)
		{
			StateButton.BackColor = Color.FromArgb(30, 255, 255, 255);
		}

		private void StateButton_MouseLeave(object sender, EventArgs e)
		{
			StateButton.BackColor = Color.Transparent;
		}

		private void StateButton_MouseUp(object sender, MouseEventArgs e)
		{
			StateButton.BackColor = Color.FromArgb(30, 255, 255, 255);
		}
		#endregion

		#region Minimize Button
		private void MinimizeButton_MouseClick(object sender, MouseEventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void MinimizeButton_MouseDown(object sender, MouseEventArgs e)
		{
			MinimizeButton.BackColor = Color.FromArgb(50, 255, 255, 255);
		}

		private void MinimizeButton_MouseEnter(object sender, EventArgs e)
		{
			MinimizeButton.BackColor = Color.FromArgb(30, 255, 255, 255);
		}

		private void MinimizeButton_MouseLeave(object sender, EventArgs e)
		{
			MinimizeButton.BackColor = Color.Transparent;
		}

		private void MinimizeButton_MouseUp(object sender, MouseEventArgs e)
		{
			MinimizeButton.BackColor = Color.FromArgb(30, 255, 255, 255);
		}
		#endregion

		#region Header
		private void HeaderBar_MouseDown(object sender, MouseEventArgs e)
		{
			dragStartPosition = e.Location;
		}

		private void HeaderBar_MouseMove(object sender, MouseEventArgs e)
		{
			if (dragStartPosition != new Point(-1, -1) && !canDragWindow)
				canDragWindow = true;
			else if (canDragWindow)
			{
				Point screenPoint = PointToScreen(e.Location);

				if (WindowState == FormWindowState.Maximized && screenPoint.Y > 10)
				{
					double maxPercent = e.X / (double)Width * 100;
					WindowState = FormWindowState.Normal;
					double normX = Width * maxPercent / 100;

					dragStartPosition = new Point((int)normX, e.Y);
					screenPoint = PointToScreen(dragStartPosition);
				}
				Location = new Point(screenPoint.X - dragStartPosition.X, screenPoint.Y - dragStartPosition.Y);
			}
		}

		private void HeaderBar_MouseUp(object sender, MouseEventArgs e)
		{
			if (Cursor.Position.AtTopOfScreen() && WindowState != FormWindowState.Maximized)
			{
				int screenTop = Cursor.Position.CurrentScreen().Top;
				if (Location.Y < screenTop)
					Location = new Point(Location.X, screenTop);
				MaximumSize = Cursor.Position.MaximumScreenSize();
				WindowState = FormWindowState.Maximized;
			}

			dragStartPosition = new Point(-1, -1);
			canDragWindow = false;
		}

		private void HeaderBar_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			WindowState = (WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal);
		}
		#endregion

		protected override void WndProc(ref Message m)
		{
			const UInt32 WM_NCHITTEST = 0x0084;
			const UInt32 WM_MOUSEMOUSE = 0x0200;
			const UInt32 HTLEFT = 10;
			const UInt32 HTRIGHT = 11;
			const UInt32 HTBOTTOMRIGHT = 17;
			const UInt32 HTBOTTOM = 15;
			const UInt32 HTBOTTOMLEFT = 16;
			const UInt32 HTTOP = 12;
			const UInt32 HTTOPLEFT = 13;
			const UInt32 HTTOPRIGHT = 14;

			const int RESIZE_HANDLE_SIZE = 10;
			bool handled = false;

			if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOUSE)
			{
				Size formSize = Size;
				Point screenPoint = new Point(m.LParam.ToInt32());
				Point clientPoint = PointToClient(screenPoint);

				Dictionary<UInt32, Rectangle> boxes = new Dictionary<uint, Rectangle>()
				{
					{ HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
					//{ HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2 * RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
					{ HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
					//{ HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2 * RESIZE_HANDLE_SIZE) },
					//{ HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
					//{ HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2 * RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
					//{ HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
					//{ HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2 * RESIZE_HANDLE_SIZE) }
				};

				foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
				{
					if (hitBox.Value.Contains(clientPoint))
					{
						m.Result = (IntPtr)hitBox.Key;
						handled = true;
						break;
					}
				}
			}

			if (!handled)
				base.WndProc(ref m);
		}
	}
}
