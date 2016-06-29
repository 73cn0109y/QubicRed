using System;
using System.Drawing;
using System.Windows.Forms;

namespace QubicRed
{
	public static class Extensions
	{
		/// <summary>
		/// Checks to see if a Point is at the top of it's respected monitor
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public static bool AtTopOfScreen(this Point pos)
		{
			foreach (Screen scr in Screen.AllScreens)
				if (scr.Bounds.Contains(pos))
					if (pos.Y <= scr.Bounds.Top + 5)
						return true;

			return false;
		}

		/// <summary>
		/// Returns the working area size of a screen
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public static Size MaximumScreenSize(this Point pos)
		{
			foreach (Screen scr in Screen.AllScreens)
				if (scr.Bounds.Contains(pos))
					return scr.WorkingArea.Size;
			return new Size(800, 600);
		}

		public static Rectangle CurrentScreen(this Point pos)
		{
			foreach (Screen scr in Screen.AllScreens)
				if (scr.Bounds.Contains(pos))
					return scr.Bounds;
			return default(Rectangle);
		}
	}
}
