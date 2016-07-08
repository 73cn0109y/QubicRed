using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed
{
	public partial class Boot : Form
	{
		Login login;
		DateTime startUp = DateTime.Now;

		public Boot()
		{
			InitializeComponent();

			Size = Screen.AllScreens[PrimaryScreen()].Bounds.Size;
			Location = Screen.AllScreens[PrimaryScreen()].Bounds.Location;

			login = new Login(PrimaryScreen()) { Opacity = 0 };
			login.Show();

			Task.Run(async () =>
			{
				await login.Init();
				FadeOut();
			});
		}

		private void FadeOut()
		{
			System.Timers.Timer t = new System.Timers.Timer(10);
			t.Elapsed += (se, ev) => {
				if ((DateTime.Now - startUp).TotalSeconds < 2)
					return;
				Invoke(new MethodInvoker(() =>
				{
					Opacity -= 0.02;
					login.Opacity += 0.02;

					if (Opacity <= 0)
					{
						Hide();
						BootLoopGIF.Dispose();
						LoadingText.Dispose();
						t.Dispose();
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
	}
}
