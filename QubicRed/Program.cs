using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Desktop(PrimaryScreen()));
			//Application.Run(new Login(PrimaryScreen()));
			Application.Run(new Boot());
		}

		private static int PrimaryScreen()
		{
			for (int i = 0; i < Screen.AllScreens.Length; i++)
				if (Screen.AllScreens[i] == Screen.PrimaryScreen)
					return i;
			return 0;
		}
	}
}
