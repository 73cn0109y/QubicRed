using System;

namespace QubicRed
{
	public static class Environment
	{
		public static string Root { get { return "C:/QubicRed/"; } }

		public static class System
		{
			public static string Root { get { return Environment.Root + "System/"; } }
			public static string Wallpapers { get { return Root + "Wallpapers/"; } }
		}

		public static class Applications
		{
			public static string Root { get { return Environment.Root + "Applications/"; } }
		}

		public static class User
		{
			public static string Root { get { return Environment.Root + "Users/"; } }
			public static string CurrentUser { get; set; } = "Guest";
			public static string RealName { get; set; } = "Guest User";
			public static string UserDirectory { get { return Root + CurrentUser + "/"; } }
		}
	}
}
