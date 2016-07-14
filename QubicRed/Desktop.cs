using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed
{
	public partial class Desktop : Form
	{
		public Apps.Taskbar Taskbar { get; protected set; }
		public Apps.Sidebar Sidebar { get; protected set; }

		public Desktop(int i = 0)
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

			InitializeComponent();

			Location = Screen.AllScreens[i].Bounds.Location;
			Size = Screen.AllScreens[i].Bounds.Size;

			Taskbar = new Apps.Taskbar(this, i);
			Taskbar.Show();

			Sidebar = new Apps.Sidebar(this);
			Sidebar.Show();
		}

		public async Task LoadAsync()
		{
			await LoadWallpaper(Environment.User.Wallpaper);

			await Taskbar.LoadAsync();

			await Sidebar.LoadAsync();

			return;
		}

		public async Task LoadWallpaper(string e)
		{
			if (!File.Exists(e))
				e = Environment.System.Wallpapers + e;
			if (!File.Exists(e))
				return;
			using (MemoryStream stream = new MemoryStream())
			using (Stream file = File.Open(e, FileMode.Open, FileAccess.Read))
			{
				byte[] buffer = new byte[1024 * 1024];
				int read;
				while ((read = await file.ReadAsync(buffer, 0, buffer.Length)) != 0)
					await stream.WriteAsync(buffer, 0, read);
				using (Bitmap bmp = new Bitmap(Image.FromStream(stream), Size).Clone(ClientRectangle, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
					BackgroundImage = bmp.Clone() as Image;
			}

			return;
		}

		protected override void WndProc(ref Message m)
		{
			if(m.Msg == 0x0046) // WM_WINDOWPOSCHANGING
				Handle.SendToDesktop();
			base.WndProc(ref m);
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
	}
}
