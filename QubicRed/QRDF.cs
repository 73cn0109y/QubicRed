using System;
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
				HeaderBar.BackColor = value;
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
	}
}
