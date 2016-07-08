using System;
using System.Runtime.InteropServices;

namespace QubicRed
{
	public static class Win32
	{
		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		public static void SendToDesktop(this IntPtr hWnd)
		{
			SetWindowPos(hWnd, new IntPtr(1), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010);
		}
	}
}
