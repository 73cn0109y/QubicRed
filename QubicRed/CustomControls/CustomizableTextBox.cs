using System;
using System.Drawing;
using System.Windows.Forms;

namespace QubicRed.CustomControls
{
	public class CustomizableTextBox : Panel
	{
		public delegate void OnSubmit();
		public event OnSubmit Submit;

		public new string Text { get { return _text; } set { _text = value; drawBar = true; ResetDrawBarSwitch(); Invalidate(); } }
		public ContentAlignment TextAlign { get; set; } = ContentAlignment.TopLeft;
		public bool Activated { get { return _activated; } protected set { _activated = value; Invalidate(); } }

		private string _text = "";
		private bool drawBar = true;
		private bool _activated = false;
		private System.Timers.Timer drawBarSwitch;

		public CustomizableTextBox()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

			Size = new Size(150, 25);
			BackColor = Color.White;
			ForeColor = Color.Black;

			drawBarSwitch = new System.Timers.Timer(1000);
			drawBarSwitch.Elapsed += (se, ev) => { Invalidate(); drawBar = !drawBar; };
		}

		protected void ResetDrawBarSwitch()
		{
			drawBarSwitch.Stop();
			drawBarSwitch.Start();
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if(e.KeyChar == 13) // Enter
			{
				Submit?.Invoke();
				e.Handled = true;
				return;
			}

			if(e.KeyChar == 8) // BackSpace
			{
				if(Text.Length > 0)
					Text = Text.Substring(0, Text.Length - 1);
				e.Handled = true;
				return;
			}

			if(char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
				Text += e.KeyChar;

			base.OnKeyPress(e);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			Focus();

			base.OnMouseClick(e);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			Activated = true;
			drawBarSwitch.Start();

			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			Activated = false;
			drawBarSwitch.Stop();

			base.OnLostFocus(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

			string drawText = Text;
			Size textSize = e.Graphics.MeasureString(drawText, Font).ToSize();

			while (textSize.Width > Width)
			{
				drawText = drawText.Substring(1, drawText.Length - 1);
				textSize = e.Graphics.MeasureString(drawText, Font).ToSize();
			}

			e.Graphics.DrawString(drawText, Font, new SolidBrush(ForeColor), CalculateTextAlign(textSize));

			if(Activated)
			{
				int x = textSize.Width;
				if (x == 0)
					x = 3;
				if(drawBar)
					e.Graphics.DrawLine(new Pen(ForeColor), new Point(x, 3), new Point(x, Height - 6));
			}

			base.OnPaint(e);
		}

		protected Point CalculateTextAlign(Size textSize)
		{
			return new Point(0, Height / 2 - (textSize.Height / 2));

			switch (TextAlign)
			{
				case ContentAlignment.TopLeft:
					return Point.Empty;
				case ContentAlignment.TopCenter:
					break;
				case ContentAlignment.TopRight:
					break;
				case ContentAlignment.MiddleLeft:
					return new Point(0, Height / 2 - (textSize.Height / 2));
				case ContentAlignment.MiddleCenter:
					break;
				case ContentAlignment.MiddleRight:
					break;
				case ContentAlignment.BottomLeft:
					return new Point(0, Height - textSize.Height);
				case ContentAlignment.BottomCenter:
					break;
				case ContentAlignment.BottomRight:
					break;
			}

			return Point.Empty;
		}
	}
}
