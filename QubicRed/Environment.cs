using System;
using QubicRed.Apps;
using QubicRed.Components;

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
			public static string UserName { get; set; } = "Admin";
			public static string RealName { get; set; } = "Administrator";
			public static string UserDirectory { get { return Root + UserName + "/"; } }
			public static string Wallpaper { get; set; } = "001.png";
			public static string Avatar { get; set; } = "avatar.png";
		}
	}
}
