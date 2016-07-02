using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QubicRed.CustomControls
{
	public class RoundedPictureBox : PictureBox
	{
		public Corners RoundCorners { get { return roundCorners; } set { roundCorners = value; Invalidate(); } }

		private Corners roundCorners = Corners.All;

		public RoundedPictureBox() { }

		protected override void OnPaint(PaintEventArgs pe)
		{
			using (GraphicsPath gp = new GraphicsPath())
			{
				pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				gp.AddEllipse(new Rectangle(0, 0, Width - 1, Height - 1));
				Region = new Region(gp);
			}

			base.OnPaint(pe);
		}
	}
}
