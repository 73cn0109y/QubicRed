using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed.Apps
{
	public partial class Taskbar : Form
	{
		public StartMenu StartMenu { get; protected set; }
		public int ScreenPoint { get; protected set; }

		private System.Timers.Timer TimeKeeper;

		public Taskbar(int i = 0)
		{
			ScreenPoint = i;

			InitializeComponent();

			Size = new Size(Screen.AllScreens[i].Bounds.Width, Height);
			Location = new Point(Screen.AllScreens[i].Bounds.Left, Screen.AllScreens[i].Bounds.Bottom - Height);

			StartMenu = new StartMenu(this);
			StartMenu.Location = new Point(20, Location.Y - StartMenu.Height - 10);
			StartMenu.Show();

			TimeKeeper = new System.Timers.Timer(50);
			TimeKeeper.Elapsed += TimeKeeper_Elapsed;
			TimeKeeper.Start();
		}

		public async Task LoadAsync()
		{
			string wallpaper = Environment.User.Wallpaper;
			if (!File.Exists(Environment.User.Wallpaper))
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
				using (Bitmap bmp = new Bitmap(Image.FromStream(stream).ResizeKeepRatio(Screen.AllScreens[ScreenPoint].Bounds.Size)).Clone(new Rectangle(Location.X, Location.Y, Width, Height), System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
				using (TextureBrush textureBrush = new TextureBrush(Image.FromFile("C:/QubicRed/System/Wallpapers/TaskbarDarken.png"), System.Drawing.Drawing2D.WrapMode.Tile))
				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.FillRectangle(textureBrush, new Rectangle(Point.Empty, bmp.Size));
					BackgroundImage = bmp.Clone() as Image;
				}
			}

			StartButton.Image = Image.FromFile(Environment.User.UserDirectory + Environment.User.Avatar);

			await StartMenu.LoadAsync();

			return;
		}

		private void TimeKeeper_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Invoke(new MethodInvoker(() =>
			{
				Time.Text = DateTime.Now.ToString("h:mm tt");
				Date.Text = DateTime.Now.ToString("dddd d");
			}));
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams p = base.CreateParams;
				p.ExStyle |= 0x08000000; // WS_EX_NOACTIVATE
				p.Parent = IntPtr.Zero;
				return p;
			}
		}

		private void StartButton_MouseClick(object sender, MouseEventArgs e)
		{
			StartMenu.ToggleVisible();
		}
	}
}
