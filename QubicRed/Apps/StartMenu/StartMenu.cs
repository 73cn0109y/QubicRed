using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed.Apps
{
	public partial class StartMenu : Form
	{
		public Dictionary<string, object> UserSettings { get; protected set; }

		private bool togglingVisible = false;
		private Taskbar taskbar;
		private bool canLooseFocus = false;

		public StartMenu(Taskbar _taskbar)
		{
			taskbar = _taskbar;

			InitializeComponent();

			using (GraphicsPath gp = new GraphicsPath())
			{
				gp.AddLine(new Point(0, 0), new Point(Width, 0));
				gp.AddLine(new Point(Width, 0), new Point(Width, Height - 10));
				gp.AddLine(new Point(Width, Height - 10), new Point(10, Height - 10));
				gp.AddLine(new Point(10, Height - 10), new Point(0, Height));
				gp.AddLine(new Point(0, Height), new Point(0, 0));
				Region = new Region(gp);
			}
		}

		public async Task LoadAsync(Dictionary<string, object> userSettings)
		{
			Point originPoint = Location;
			Invoke(new MethodInvoker(() => { Location = new Point(-int.MaxValue, -int.MaxValue); }));

			UserSettings = userSettings;

			string wallpaper = UserSettings["wallpaper"].ToString();
			if (!File.Exists(UserSettings["wallpaper"].ToString()))
				wallpaper = Environment.System.Wallpapers + wallpaper;
			if (!File.Exists(wallpaper))
				return;
			using (MemoryStream stream = new MemoryStream())
			using (Stream file = File.Open(wallpaper, FileMode.Open, FileAccess.Read))
			{
				byte[] buffer = new byte[1024 * 1024];
				int read;
				while ((read = await file.ReadAsync(buffer, 0, buffer.Length)) != 0)
					await stream.WriteAsync(buffer, 0, read);
				using (Bitmap bmp = new Bitmap(Image.FromStream(stream)).Clone(new Rectangle(originPoint.X, originPoint.Y, Width, Height), System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
				using (TextureBrush textureBrush = new TextureBrush(Image.FromFile("C:/QubicRed/System/Wallpapers/TaskbarDarken.png"), WrapMode.Tile))
				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.FillRectangle(textureBrush, new Rectangle(Point.Empty, bmp.Size));
					BackgroundImage = bmp.Clone() as Image;
				}
			}

			Invoke(new MethodInvoker(() =>
			{
				Visible = false;
				Location = originPoint;
			}));

			canLooseFocus = true;
		}
		private Task currentFade;
		public void ToggleVisible(bool forceHide = false)
		{
			if(forceHide && togglingVisible)
			{
				currentFade.Dispose();
				togglingVisible = false;
			}
			if (togglingVisible)
				return;
			if (!TopMost)
				TopMost = true;
			currentFade = Task.Run(() =>
			{
				togglingVisible = true;
				Invoke(new MethodInvoker(() =>
				{
					if (Visible || forceHide)
					{
						Opacity = 1;
						while (Opacity > 0)
						{
							Opacity -= 0.02;
							System.Threading.Thread.Sleep(10);
						}
						Opacity = 0;
						Hide();
					}
					else
					{
						Opacity = 0;
						Show();
						while (Opacity < 1)
						{
							Opacity += 0.02;
							System.Threading.Thread.Sleep(10);
						}
						Opacity = 1;
						Focus();
						Activate();
					}
				}));
				togglingVisible = false;
				currentFade = null;
			});
		}

		protected override void OnLostFocus(EventArgs e)
		{
			if(Cursor.Position.Y < taskbar.Location.Y && canLooseFocus)
				ToggleVisible(true);

			base.OnLostFocus(e);
		}
	}
}
