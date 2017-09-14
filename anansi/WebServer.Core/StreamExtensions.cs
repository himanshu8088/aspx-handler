using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Core
{
    internal static class StreamExtensions
    {
        public static void CopyContentsTo(this Stream origin, Stream destination, int bufferSize = 4096)
        {
            var buffer = new byte[bufferSize];
            int contentLength = 0;
            while(true)
            {
                contentLength = origin.Read(buffer, 0, buffer.Length);
                if (contentLength != 0) 
                    destination.Write(buffer, 0, contentLength);
                if (contentLength < bufferSize)
                    break;
            }
        }


        public static async Task CopyContentsToAsync(this Stream origin, Stream destination, int bufferSize = 4096)
        {
            var buffer = new byte[bufferSize];
            int contentLength = 0;
            while (true)
            {
                contentLength = await origin.ReadAsync(buffer, 0, buffer.Length);
                if (contentLength != 0)
                    await destination.WriteAsync(buffer, 0, contentLength);
                if (contentLength < bufferSize)
                    break;
            }
        }


        public static byte[] ReadAllBytes(this Stream origin)
        {
            using (var stream = new MemoryStream())
            {
                origin.CopyContentsTo(stream);
                return stream.ToArray();
            }
        }

        public static async Task<byte[]> ReadAllBytesAsync(this Stream origin)
        {
            using (var stream = new MemoryStream())
            {
                await origin.CopyContentsToAsync(stream);
                return stream.ToArray();
            }
        }
    }
}
