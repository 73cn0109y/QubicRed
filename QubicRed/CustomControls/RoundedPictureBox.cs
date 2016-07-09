using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace QubicRed.CustomControls
{
	public class RoundedPictureBox : PictureBox
	{
		public Corners RoundCorners { get { return roundCorners; } set { roundCorners = value; Invalidate(); } }
		public new Image Image { get { return image; } set { image = value; Invalidate(); } }

		private Corners roundCorners = Corners.All;
		private Image image = null;

		public RoundedPictureBox() { }

		protected override void OnPaint(PaintEventArgs pe)
		{
			using(GraphicsPath gp = new GraphicsPath())
			{
				Brush imageBrush;

				if (Image != null)
					imageBrush = new TextureBrush(Image.ResizeKeepRatio(Size));
				else
					imageBrush = new TextureBrush(new Bitmap(Width, Height));

				pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				pe.Graphics.CompositingQuality = CompositingQuality.HighQuality;
				pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				gp.AddEllipse(0, 0, Width - 1, Height - 1);
				pe.Graphics.FillPath(imageBrush, gp);
			}

			//base.OnPaint(pe);
		}
	}
}
