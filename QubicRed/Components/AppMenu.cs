using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed.Components
{
	public partial class AppMenu : Component
	{
		private const int APP_WIDTH = 65;
		private const int APP_HEIGHT = 85;
		private const int APP_SPACING = 20;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Dictionary<string, object[]> Applications { get; set; } = new Dictionary<string, object[]>()
		{
			{ "Messages", new object[] { typeof(Apps.Messenger), Properties.Resources.messenger_icon } },
			{ "Calculator", new object[] { typeof(Apps.Messenger), Properties.Resources.calculator_icon } },
			{ "Gallery", new object[] { typeof(Apps.Messenger), Properties.Resources.gallery_icon } },
			{ "Mail", new object[] { typeof(Apps.Messenger), Properties.Resources.mail_icon } },
			{ "Manager", new object[] { typeof(Apps.Messenger), Properties.Resources.manager_icon } },
			{ "Music", new object[] { typeof(Apps.Messenger), Properties.Resources.music_icon } },
			{ "News", new object[] { typeof(Apps.Messenger), Properties.Resources.news_icon } },
			{ "Notes", new object[] { typeof(Apps.Messenger), Properties.Resources.notes_icon } },
			{ "Project Web", new object[] { typeof(Apps.Messenger), Properties.Resources.projectweb_icon } },
			{ "Settings", new object[] { typeof(Apps.Messenger), Properties.Resources.settings_icon } },
			{ "Social Hub", new object[] { typeof(Apps.Messenger), Properties.Resources.socialhub_icon } },
			{ "Store", new object[] { typeof(Apps.Messenger), Properties.Resources.store_icon } }
		};
		public Panel ApplicationContainer { get; set; }

		public AppMenu()
		{
			InitializeComponent();
		}

		public AppMenu(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public void Load()
		{
			if (ApplicationContainer == null)
				return;

			int startX = (ApplicationContainer.Width / 2 - (((APP_WIDTH + APP_SPACING) * 5) / 2));
			int x = startX;
			int y = 10;

			foreach (KeyValuePair<string, object[]> app in Applications)
			{
				Panel appItem = new Panel();
				appItem.Size = new Size(APP_WIDTH, APP_HEIGHT);
				appItem.Location = new Point(x, y);
				appItem.BackColor = Color.Transparent;
				appItem.Name = app.Key;
				appItem.Cursor = Cursors.Hand;
				appItem.MouseEnter += app_MouseEnter;
				appItem.MouseLeave += app_MouseLeave;
				appItem.MouseClick += (se, ev) => { LaunchApp(app.Value[0] as Type); };

				CustomControls.RoundedPictureBox icon = new CustomControls.RoundedPictureBox();
				icon.Size = new Size(28, 28);
				icon.Location = new Point(APP_WIDTH / 2 - (14), APP_WIDTH / 2 - (14));
				icon.BackColor = Color.Transparent;
				icon.Image = app.Value[1] as Image;
				icon.SizeMode = PictureBoxSizeMode.CenterImage;
				icon.MouseClick += (se, ev) => { LaunchApp(app.Value[0] as Type); };

				CustomControls.ClickThroughLabel title = new CustomControls.ClickThroughLabel();
				title.AutoSize = false;
				title.Dock = DockStyle.Bottom;
				title.Size = new Size(appItem.Width, APP_HEIGHT - (icon.Location.Y + icon.Height));
				title.Text = app.Key;
				title.BackColor = Color.Transparent;
				title.Font = new Font("Segoe UI", 8, FontStyle.Regular);
				title.UseCompatibleTextRendering = true;
				title.ForeColor = Color.White;
				title.TextAlign = ContentAlignment.MiddleCenter;
				title.MouseClick += (se, ev) => { LaunchApp(app.Value[0] as Type); };

				appItem.Controls.Add(icon);
				appItem.Controls.Add(title);

				ApplicationContainer.Invoke(new MethodInvoker(() => { ApplicationContainer.Controls.Add(appItem); }));

				x += appItem.Width + APP_SPACING;

				if (x + appItem.Width + APP_SPACING >= ApplicationContainer.Width)
				{
					x = startX;
					y += appItem.Height + APP_SPACING;
				}
			}

			return;
		}

		private void LaunchApp(Type t, params object[] args)
		{
			if(t == typeof(Apps.Messenger))
				((Apps.Messenger)Activator.CreateInstance(t)).Show();
		}

		private void app_MouseEnter(object sender, EventArgs e)
		{
			Panel p = sender as Panel;
			if (p == null)
				return;
			p.BackColor = Color.FromArgb(50, 255, 255, 255);
		}

		private void app_MouseLeave(object sender, EventArgs e)
		{
			Panel p = sender as Panel;
			if (p == null)
				return;
			if (p.ClientRectangle.Contains(p.PointToClient(Cursor.Position)))
				return;
			p.BackColor = Color.Transparent;
		}
	}
}
