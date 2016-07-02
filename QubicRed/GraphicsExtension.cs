using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QubicRed
{
	public enum Corners : int
	{
		All,
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight,
		None
	}

	public static class GraphicsExtension
	{
		public static GraphicsPath GenerateRoundedRectangle(this Graphics graphics, RectangleF rectangle, float radius, Corners filter)
		{
			float diameter;
			GraphicsPath path = new GraphicsPath();
			if (radius <= 0.0F || filter == Corners.None)
			{
				path.AddRectangle(rectangle);
				path.CloseFigure();
				return path;
			}
			else
			{
				if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
					return graphics.GenerateCapsule(rectangle);
				diameter = radius * 2.0F;
				SizeF sizeF = new SizeF(diameter, diameter);
				RectangleF arc = new RectangleF(rectangle.Location, sizeF);
				if ((Corners.TopLeft & filter) == Corners.TopLeft)
					path.AddArc(arc, 180, 90);
				else
				{
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
					path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
				}
				arc.X = rectangle.Right - diameter;
				if ((Corners.TopRight & filter) == Corners.TopRight)
					path.AddArc(arc, 270, 90);
				else
				{
					path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
					path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
				}
				arc.Y = rectangle.Bottom - diameter;
				if ((Corners.BottomRight & filter) == Corners.BottomRight)
					path.AddArc(arc, 0, 90);
				else
				{
					path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
				}
				arc.X = rectangle.Left;
				if ((Corners.BottomLeft & filter) == Corners.BottomLeft)
					path.AddArc(arc, 90, 90);
				else
				{
					path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
				}
				path.CloseFigure();
			}
			return path;
		}

		public static GraphicsPath GenerateCapsule(this Graphics graphics, RectangleF rectangle)
		{
			float diameter;
			RectangleF arc;
			GraphicsPath path = new GraphicsPath();
			try
			{
				if (rectangle.Width > rectangle.Height)
				{
					diameter = rectangle.Height;
					SizeF sizeF = new SizeF(diameter, diameter);
					arc = new RectangleF(rectangle.Location, sizeF);
					path.AddArc(arc, 90, 180);
					arc.X = rectangle.Right - diameter;
					path.AddArc(arc, 270, 180);
				}
				else if (rectangle.Width < rectangle.Height)
				{
					diameter = rectangle.Width;
					SizeF sizeF = new SizeF(diameter, diameter);
					arc = new RectangleF(rectangle.Location, sizeF);
					path.AddArc(arc, 180, 180);
					arc.Y = rectangle.Bottom - diameter;
					path.AddArc(arc, 0, 180);
				}
				else
					path.AddEllipse(rectangle);
			}
			catch { path.AddEllipse(rectangle); }
			finally { path.CloseFigure(); }
			return path;
		}
	}
}
