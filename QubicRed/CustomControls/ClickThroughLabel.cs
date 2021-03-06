﻿using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QubicRed.CustomControls
{
	public class ClickThroughLabel : Label
	{
		public TextRenderingHint TextRenderingHint { get; set; } = TextRenderingHint.AntiAlias;

		public ClickThroughLabel() { }

		protected override void WndProc(ref Message m)
		{
			const int WM_NCHITTEST = 0x0084;
			const int HTTRANSPARENT = (-1);

			if (m.Msg == WM_NCHITTEST)
			{
				m.Result = (IntPtr)HTTRANSPARENT;
			}
			else
			{
				base.WndProc(ref m);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = TextRenderingHint;

			base.OnPaint(e);
		}
	}
}
