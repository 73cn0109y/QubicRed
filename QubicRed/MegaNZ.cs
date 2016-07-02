using System;
using System.IO;
using System.Linq;
using CG.Web.MegaApiClient;

namespace QubicRed
{
	public static class MegaNZ
	{
		public static void UploadWithProgression(string filepath)
		{
			MegaApiClient client = new MegaApiClient();
			client.Login("texpert30@live.com.au", "Cetlog2848");

			/*using (var stream = new ProgressionStream(new FileStream(filepath, FileMode.Open, FileAccess.Read), PrintProgression))
			{
				var parent = client.GetNodes().FirstOrDefault(x => x.Type == NodeType.Root);
				client.Upload(stream, Path.GetFileName(filepath), parent);
			}*/

			client.UploadFile(filepath, client.GetNodes().FirstOrDefault(x => x.Type == NodeType.Root));
		}

		public static void DownloadWithProgression(string filepath)
		{
			/*MegaApiClient client = new MegaApiClient();
			client.Login("texpert30@live.com.au", "Cetlog2848");

			using (var fileStream = new FileStream(filepath, FileMode.Create))
			{
				using (var downloadStream = new ProgressionStream(client.Download(node), PrintProgression))
				{
					downloadStream.CopyTo(fileStream);
				}
			}*/
		}

		private static void PrintProgression(double progression)
		{
			Console.WriteLine(progression);
		}
	}

	public class ProgressionStream : Stream
	{
		public delegate void ProgressionHandler(double progression);

		private Stream _sourceStream;
		private ProgressionHandler _progressionHandler;

		public ProgressionStream(Stream sourceStream, ProgressionHandler progressionHandler)
		{
			this._sourceStream = sourceStream;
			this._progressionHandler = progressionHandler;
		}

		public override int Read(byte[] array, int offset, int count)
		{
			this._progressionHandler(this.Position / (double)this.Length * 100);

			return this._sourceStream.Read(array, offset, count);
		}

		public override bool CanRead
		{
			get
			{
				return this._sourceStream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this._sourceStream.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this._sourceStream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return this._sourceStream.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this._sourceStream.Position;
			}

			set
			{
				this._sourceStream.Position = value;
			}
		}

		public override void Flush()
		{
			this._sourceStream.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this._sourceStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			this._sourceStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this._sourceStream.Write(buffer, offset, count);
		}
	}
}
