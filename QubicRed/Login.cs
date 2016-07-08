using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed
{
	public partial class Login : Form
	{
		private Desktop desktop;
		Dictionary<string, object> UserSettings = new Dictionary<string, object>();

		public Login(int i = 0)
		{
			InitializeComponent();

			Location = Screen.AllScreens[i].Bounds.Location;
			Size = Screen.AllScreens[i].Bounds.Size;

			Environment.User.CurrentUser = "Test";
		}

		public async Task Init()
		{
			await LoadSettings();

			using (MemoryStream stream = new MemoryStream())
			{
				// Background Image
				using (Stream file = File.Open(Environment.System.Wallpapers + "Login/001.png", FileMode.Open, FileAccess.Read))
				{
					byte[] buffer = new byte[1024 * 1024];
					int read;
					while ((read = await file.ReadAsync(buffer, 0, buffer.Length)) != 0)
						await stream.WriteAsync(buffer, 0, read);
					using (Bitmap bmp = new Bitmap(Image.FromStream(stream)).Clone(ClientRectangle, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
						BackgroundImage = bmp.Clone() as Image;
				}
				stream.Position = 0;
				// User Avatar
				using (Stream file = File.Open(Environment.User.UserDirectory + UserSettings["avatar"].ToString(), FileMode.Open, FileAccess.Read))
				{
					byte[] buffer = new byte[1024 * 1024];
					int read;
					while ((read = await file.ReadAsync(buffer, 0, buffer.Length)) != 0)
						await stream.WriteAsync(buffer, 0, read);
					using (Image image = Image.FromStream(stream))
					using (Bitmap bmp = new Bitmap(image, UserAvatar.Size).Clone(UserAvatar.DisplayRectangle, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
						UserAvatar.Image = bmp.Clone() as Image;
				}
			}

			return;
		}

		private async Task LoadSettings()
		{
			string[] lines;
			using (Stream reader = File.Open(Environment.User.UserDirectory + "settings.dat", FileMode.Open, FileAccess.Read))
			{
				StringBuilder settingsContent = new StringBuilder();
				byte[] buffer = new byte[1024 * 1024];
				int read;
				while ((read = await reader.ReadAsync(buffer, 0, buffer.Length)) != 0)
					settingsContent.Append(Encoding.Default.GetString(buffer, 0, read));
				lines = settingsContent.ToString().Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
			}

			foreach (string line in lines)
			{
				string name = line.Split('=')[0].Trim();
				string value = line.Split('=')[1].Trim();
				UserSettings.Add(name, value);
			}

			Environment.User.CurrentUser = UserSettings["username"].ToString();
			Environment.User.RealName = UserSettings["realname"].ToString();

			return;
		}

		private void customizableTextBox1_Submit()
		{
			if(PasswordField.Text == UserSettings["password"].ToString())
			{
				desktop = new Desktop(PrimaryScreen()) { Opacity = 0 };
				desktop.Show();

				Task.Run(async () =>
				{
					await desktop.LoadAsync(UserSettings);
					FadeOut();
				});
			}
		}

		private void FadeOut()
		{
			Invoke(new MethodInvoker(() => { UserGroup.Dispose(); }));

			System.Timers.Timer t = new System.Timers.Timer(10);
			t.AutoReset = true;
			t.Elapsed += (se, ev) => {
				Invoke(new MethodInvoker(() =>
				{
					Opacity -= 0.02;
					desktop.Opacity += 0.02;

					if (Opacity <= 0)
					{
						desktop.Taskbar.TopMost = true;
						t?.Dispose();
						Dispose();
					}
				}));
			};
			t.Start();
		}

		private int PrimaryScreen()
		{
			for (int i = 0; i < Screen.AllScreens.Length; i++)
				if (Screen.AllScreens[i] == Screen.PrimaryScreen)
					return i;
			return 0;
		}

		protected override void OnShown(EventArgs e)
		{
			PasswordField.Focus();

			base.OnShown(e);
		}
	}
}
