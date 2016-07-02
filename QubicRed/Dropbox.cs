using System;
using System.IO;
using System.Threading.Tasks;
using Dropbox.Api.Files;

namespace QubicRed
{
	public static class Dropbox
	{
		private static FileStream CurrentFileStream;
		private static global::Dropbox.Api.DropboxClient Client;

		public static async Task Upload(global::Dropbox.Api.DropboxClient client, string file, string targetPath, IProgress<double> progress = null)
		{
			const int chunkSize = 1024 * 1024;
			CurrentFileStream = File.Open(file, FileMode.Open, FileAccess.Read);
			Client = client;

			if (CurrentFileStream.Length <= chunkSize)
			{
				System.Diagnostics.Trace.WriteLine("Start one-shot upload");
				await Client.Files.UploadAsync(targetPath, body: CurrentFileStream);
			}

			else
			{
				System.Diagnostics.Trace.WriteLine("Start chunk upload");
				await ChunkUpload(targetPath, chunkSize, progress);
			}

			client.Dispose();
			CurrentFileStream.Close();
		}

		public static async Task ChunkUpload(String path, int chunkSize, IProgress<double> progress)
		{
			chunkSize = (int)CurrentFileStream.Length / 100;
			int numChunks = (int)Math.Ceiling((double)CurrentFileStream.Length / chunkSize);

			byte[] buffer = new byte[chunkSize];
			string sessionId = null;
			UploadSessionStartArg startArg = new UploadSessionStartArg();

			for (var idx = 0; idx < numChunks; idx++)
			{
				var byteRead = CurrentFileStream.Read(buffer, 0, chunkSize);

				using (MemoryStream memStream = new MemoryStream(buffer, 0, byteRead))
				{
					if (idx == 0)
					{
						var result = await Client.Files.UploadSessionStartAsync(startArg, memStream);
						sessionId = result.SessionId;
					}

					else
					{
						UploadSessionCursor cursor = new UploadSessionCursor(sessionId, (ulong)(chunkSize * idx));

						if (idx == numChunks - 1)
						{
							await Client.Files.UploadSessionFinishAsync(cursor, new CommitInfo(path), memStream);
						}

						else
						{
							await Client.Files.UploadSessionAppendAsync(cursor, memStream);
						}
					}
				}

				if(progress != null)
					progress.Report(Math.Round((float)(idx + 1) / (float)numChunks * 100));
			}
		}
	}
}
