using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QubicRed
{
	public static class Extensions
	{
		private static Dictionary<string, string> CacheImageLocations = new Dictionary<string, string>();

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

		public static Image DownloadImage(this string url, Size size)
		{
			if (url == null)
				return null;

			if (url.StartsWith("ftp://"))
				return DownloadFTPImage(url, size);

			string localFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Cached", "Images", Path.GetFileName(url));
			localFile = localFile.Substring(6, localFile.Length - 6);

			if (CacheImageLocations.ContainsKey(url) || File.Exists(localFile))
				return Image.FromFile(localFile).ResizeKeepRatio(size);

			if (!Directory.Exists(Path.GetDirectoryName(localFile)))
				Directory.CreateDirectory(Path.GetDirectoryName(localFile));

			using (WebClient client = new WebClient())
				client.DownloadFile(url, localFile);

			CacheImageLocations.Add(url, localFile);

			return Image.FromFile(localFile).ResizeKeepRatio(size);
		}

		public static Image DownloadFTPImage(this string url, Size size)
		{
			if (url == null)
				return null;

			string localFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Cached", "Images", Path.GetFileName(url));

			if (localFile.StartsWith("file:\\"))
				localFile = localFile.Substring(6, localFile.Length - 6);

			if (File.Exists(localFile))
				return Image.FromFile(localFile);

			Image image = null;

			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
			request.Method = WebRequestMethods.Ftp.DownloadFile;
			request.UseBinary = true;
			request.Credentials = new NetworkCredential("2159860_user", "Qub1cR3dSt0rag3");

			using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
			using (Stream responseStream = response.GetResponseStream())
			using (FileStream fs = new FileStream(localFile, FileMode.Create, FileAccess.ReadWrite))
			{
				byte[] buffer = new byte[102400];
				int read = 0;
				do
				{
					read = responseStream.Read(buffer, 0, buffer.Length);
					fs.Write(buffer, 0, read);
					fs.Flush();
				} while (!(read == 0));

				fs.Flush();
				fs.Close();
			}

			if (File.Exists(localFile))
				using (Image img = Image.FromFile(localFile).ResizeKeepRatio(size)) // So we don't lock the file
					image = img.Clone() as Image;

			return image;
		}

		public static Bitmap ResizeKeepRatio(this Image image, Size targetSize = default(Size))
		{
			if (targetSize == default(Size))
				targetSize = new Size(100, 100);
			if (targetSize.Width > image.Width && targetSize.Height > image.Height)
				targetSize = image.Size;

			int sourceWidth = image.Width;
			int sourceHeight = image.Height;
			int Width = targetSize.Width;
			int Height = targetSize.Height;
			int targetX = 0;
			int targetY = 0;
			double Ratio = 0;
			double widthRatio = 0;
			double heightRatio = 0;

			widthRatio = ((double)Width / (double)sourceWidth);
			heightRatio = ((double)Height / (double)sourceHeight);

			Ratio = (widthRatio > heightRatio ? heightRatio : widthRatio);

			if (widthRatio > heightRatio)
				targetX = Convert.ToInt16((Width - (sourceWidth * Ratio)) / 2);
			else
				targetY = Convert.ToInt16((Height - (sourceHeight * Ratio)) / 2);

			int destWidth = (int)(sourceWidth * Ratio);
			int destHeight = (int)(sourceHeight * Ratio);

			Bitmap scaledImage = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
			scaledImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (Graphics g = Graphics.FromImage(scaledImage))
			{
				g.Clear(Color.Transparent);
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;

				g.DrawImage(image, new Rectangle(targetX, targetY, destWidth, destHeight), new Rectangle(0, 0, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
			}

			return scaledImage;
		}

		public static void EnableDoubleBuferring(this Control control)
		{
			var property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(control, true, null);
		}
	}
}
