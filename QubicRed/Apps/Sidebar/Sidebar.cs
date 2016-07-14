using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QubicRed.Apps
{
	public partial class Sidebar : Form
	{
		public Desktop Desktop { get; protected set; }
		public bool CanLooseFocus { get; protected set; } = false;

		private bool slidingToggle = false;
		private System.Timers.Timer TimeKeeper;

		public Sidebar(Desktop desktop)
		{
			Desktop = desktop;

			InitializeComponent();

			Size = new Size(300, Desktop.Height - Desktop.Taskbar.Height);
			Location = new Point(Desktop.Right, Desktop.Top);

			TimeKeeper = new System.Timers.Timer(50);
			TimeKeeper.Elapsed += TimeKeeper_Elapsed;
			TimeKeeper.Start();

			LoadCalendar();
		}

		public async Task LoadAsync()
		{
			string wallpaper = Environment.User.Wallpaper;
			if (!File.Exists(wallpaper))
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
				using (Bitmap bmp = new Bitmap(Image.FromStream(stream), Desktop.Size).Clone(new Rectangle(Desktop.Right - Width, Desktop.Top, Width, Height), System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
				using (TextureBrush textureBrush = new TextureBrush(Image.FromFile("C:/QubicRed/System/Wallpapers/TaskbarDarken.png"), WrapMode.Tile))
				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.FillRectangle(textureBrush, new Rectangle(Point.Empty, bmp.Size));
					BackgroundImage = bmp.Clone() as Image;
				}
			}

			CanLooseFocus = true;
		}

		public void LoadCalendar(int month = -1, int year = -1)
		{
			if(InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { LoadCalendar(month, year); }));
				return;
			}
			if (year != -1)
			{
				if (year < 1970)
					year = 1970;
				else if (year > 9999)
					year = 9999;
			}
			else
				year = DateTime.Now.Year;
			if (month != -1)
			{
				if (month < 1)
					month = 1;
				else if (month > 12)
					month = 12;
			}
			else
				month = DateTime.Now.Month;

			Size daySize = new Size(CalendarContainer.Width / 7, CalendarContainer.Width / 7);
			int startOfMonth = (int)new DateTime(year, month, 1).DayOfWeek;
			int daysInMonth = DateTime.DaysInMonth(year, month);
			int currentWeekDay = (int)DateTime.Now.DayOfWeek;
			int centeredX = CalendarContainer.Width / 2 - ((daySize.Width * 7) / 2);
			int x = centeredX;
			int y = 50;

			for (int i = 0; i < 7; i++)
			{
				Label dayTitle = new Label();
				dayTitle.Name = "DayTitle_" + i;
				dayTitle.AutoSize = false;
				dayTitle.Size = new Size(daySize.Width, 50);
				dayTitle.Location = new Point(x, 0);
				dayTitle.BackColor = Color.Transparent;
				dayTitle.ForeColor = (i == currentWeekDay ? Color.DeepSkyBlue : Color.White);
				dayTitle.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
				dayTitle.Text = ((DayOfWeek)i).ToString().Substring(0, 3).ToUpper();
				dayTitle.TextAlign = ContentAlignment.MiddleCenter;
				dayTitle.Paint += (se, ev) =>
				{
					string name = ((Label)se).Name;
					int num = int.Parse(name.Substring(name.IndexOf("_") + 1, name.Length - name.IndexOf("_") - 1));
					ev.Graphics.FillRectangle(num == currentWeekDay ? Brushes.DeepSkyBlue : Brushes.White, new Rectangle(0, dayTitle.Height - 1, dayTitle.Width, 1));
				};
				dayTitle.Invalidate();

				CalendarContainer.Controls.Add(dayTitle);

				x += daySize.Width;
			}

			x = centeredX;

			int daysLastMonth = DateTime.DaysInMonth(month - 1 <= 0 ? year - 1 : year, month - 1 <= 0 ? 12 : month - 1);

			for(int i = 0; i < startOfMonth; i++)
			{
				Label prevMonth = new Label();
				prevMonth.Name = "PrevMonth_" + i;
				prevMonth.AutoSize = false;
				prevMonth.Size = daySize;
				prevMonth.Location = new Point(x, y);
				prevMonth.Text = ((daysLastMonth - startOfMonth) + (i + 1)).ToString();
				prevMonth.TextAlign = ContentAlignment.MiddleCenter;
				prevMonth.BackColor = Color.Transparent;
				prevMonth.ForeColor = Color.FromArgb(150, 150, 150);

				CalendarContainer.Controls.Add(prevMonth);

				x += daySize.Width;
				if(x + daySize.Width >= CalendarContainer.Width)
				{
					x = centeredX;
					y += daySize.Height;
				}
			}

			for(int i = 0; i < daysInMonth; i++)
			{
				Label day = new Label();
				day.Name = "Day_" + i;
				day.AutoSize = false;
				day.Size = daySize;
				day.Location = new Point(x, y);
				day.Text = (i + 1).ToString();
				day.TextAlign = ContentAlignment.MiddleCenter;
				day.BackColor = Color.Transparent;
				day.Paint += (se, ev) =>
				{
					string name = ((Label)se).Name;
					int num = int.Parse(name.Substring(name.IndexOf("_") + 1, name.Length - name.IndexOf("_") -1));
					if (num + 1 == DateTime.Now.Day)
					{
						ev.Graphics.CompositingQuality = CompositingQuality.HighQuality;
						ev.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
						ev.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
						ev.Graphics.SmoothingMode = SmoothingMode.HighQuality;

						StringFormat sf = new StringFormat();
						sf.LineAlignment = StringAlignment.Center;
						sf.Alignment = StringAlignment.Center;

						ev.Graphics.FillEllipse(Brushes.DeepSkyBlue, ((Label)se).ClientRectangle);
						ev.Graphics.DrawString((num + 1).ToString(), ((Label)se).Font, Brushes.White, ((Label)se).DisplayRectangle, sf);
					}
				};

				CalendarContainer.Controls.Add(day);

				x += daySize.Width;
				if(x + daySize.Width >= CalendarContainer.Width)
				{
					x = centeredX;
					y += daySize.Height;
				}
			}

			CalendarContainer.Size = new Size(CalendarContainer.Width, CalendarContainer.Controls[CalendarContainer.Controls.Count - 1].Location.Y + daySize.Height);
		}

		public void ToggleVisible(bool forceHide = false)
		{
			if (slidingToggle)
				return;
			if (!TopMost)
				TopMost = true;

			slidingToggle = true;

			Task.Run(() =>
			{
				Invoke(new MethodInvoker(() =>
				{
					if (Left < Desktop.Right || forceHide)
					{
						while(Left < Desktop.Right)
						{
							Location = new Point(Location.X + 5, Location.Y);
							System.Threading.Thread.Sleep(10);
						}
						Location = new Point(Desktop.Right, Location.Y);
					}
					else
					{
						while(Left > Desktop.Right - Width)
						{
							Location = new Point(Location.X - 5, Location.Y);
							System.Threading.Thread.Sleep(10);
						}
						Location = new Point(Desktop.Right - Width, Location.Y);
					}
				}));

				slidingToggle = false;
			});
		}

		private void TimeKeeper_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Invoke(new MethodInvoker(() =>
			{
				DateLabel.Text = DateTime.Now.ToString("MMMM yyyy, ddddd d");
				TimeLabel.Text = DateTime.Now.ToString("h:mm tt");
			}));
		}
	}
}
