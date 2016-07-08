using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QubicRed.CustomControls.Messenger
{
	public class UploadPictureBox : PictureBox
	{
		protected Panel ProgressBar { get; set; }
		protected PictureBox Remove { get; set; }

		public UploadPictureBox(string path, Size size)
		{
			BackColor = Color.Transparent;
			SizeMode = PictureBoxSizeMode.CenterImage;
			Name = path;
			Size = size;

			ProgressBar = new Panel();
			ProgressBar.Size = new Size(0, 5);
			ProgressBar.BackColor = Color.Green;
			ProgressBar.Location = new Point(0, Height - ProgressBar.Height);
			ProgressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

			Controls.Add(ProgressBar);
		}

		public async Task<bool> Upload(string source, string destination, NetworkCredential credentials, Action<long> progress = null)
		{
			const int CHUNK_SIZE = (1024 * 1024) / 2;
			int chunk = CHUNK_SIZE;

			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destination);
			request.Method = WebRequestMethods.Ftp.UploadFile;
			request.Credentials = credentials;

			using (Stream inputStream = File.Open(source, FileMode.Open, FileAccess.Read))
			using (Stream stream = request.GetRequestStream())
			{
				request.ContentLength = inputStream.Length;

				if (request.ContentLength <= chunk)
				{
					byte[] buffer = new byte[inputStream.Length];
					inputStream.Read(buffer, 0, buffer.Length);
					await stream.WriteAsync(buffer, 0, buffer.Length);
					Invoke(new MethodInvoker(() => { ProgressBar.Size = new Size(Width, ProgressBar.Height); }));
					progress?.Invoke(buffer.Length);
				}
				else
				{
					chunk = (int)inputStream.Length / 100;
					chunk = Math.Min(chunk, CHUNK_SIZE);

					byte[] buffer = new byte[chunk];
					int totalReadBytesCount = 0;
					int readBytesCount;

					while ((readBytesCount = inputStream.Read(buffer, 0, buffer.Length)) > 0)
					{
						await stream.WriteAsync(buffer, 0, readBytesCount);
						totalReadBytesCount += readBytesCount;

						double percent = (double)totalReadBytesCount / (double)inputStream.Length * 100.0;
						double percentWidth = percent * Width / 100.0;
						Invoke(new MethodInvoker(() => { ProgressBar.Size = new Size((int)percentWidth, ProgressBar.Height); }));
						progress?.Invoke(readBytesCount);
					}
				}
			}

			using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
				if (response.StatusCode == FtpStatusCode.ClosingData)
					return true;

			return false;
		}

		public async Task<bool> LoadImage(string filePath)
		{
			filePath = filePath.Replace("%3A", ":").Replace("%2F", "/"); // Do my own html decode

			if (File.Exists(filePath))
			{
				using (Stream inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
				using (MemoryStream stream = new MemoryStream())
				{
					byte[] buffer = new byte[inputStream.Length];
					await inputStream.ReadAsync(buffer, 0, buffer.Length);
					await stream.WriteAsync(buffer, 0, buffer.Length);
					using (Image img = new Bitmap(Image.FromStream(stream)).ResizeKeepRatio())
						Image = img.Clone() as Image;
					stream.Close();
					inputStream.Close();
				}

				return true;
			}
			else
			{
				using (Image img = filePath.DownloadFTPImage(Size))
					Image = img.ResizeKeepRatio();
			}

			return false;
		}
	}
}
