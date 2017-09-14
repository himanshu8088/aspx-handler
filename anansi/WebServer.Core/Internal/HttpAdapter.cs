using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebServer.Core
{
    public class HttpAdapter : IHttpAdapter
    {
        private static readonly byte[] NewLine = Encoding.ASCII.GetBytes("\r\n");
        private static readonly byte[] Space = Encoding.ASCII.GetBytes(" ");
        private static readonly byte[] Colon = Encoding.ASCII.GetBytes(": ");
        private static readonly string Newline = "\r\n";

        public IHttpRequest ReadRequest(Stream rqStream)
        {
            IHttpRequest request = new HttpRequest();
            var payload = rqStream.ReadAllBytes();

            BigString payloadStr = new BigString(payload);
            var lines = payloadStr.Split(NewLine);
            var tokens = lines[0].Split(Space);
            request.Verb = tokens[0].ToString();
            request.Url = tokens[1].ToString();
            var headerLines = lines.Skip(1).Take(lines.Length - 2).ToArray();
            foreach (var line in headerLines)
            {
                tokens = line.Split(Colon);
                if (tokens.Length == 2)
                    request.Headers[tokens[0].ToString()] = tokens[1].ToString();
            }
            return request;
        }

        public void WriteResponse(IHttpResponse response, Stream rsStream)
        {
            var buffer = new StringBuilder();
            buffer.Append("HTTP/1.1 ")
                  .Append(response.Status.Code.ToString())
                  .Append(" ")
                  .Append(response.Status.Description)
                  .Append("\r\n");
            foreach (var header in response.Headers)
                buffer.Append(header.Key)
                      .Append(": ")
                      .Append(header.Value)
                      .Append("\r\n");
            buffer.Append("\r\n");
            var prefix = Encoding.ASCII.GetBytes(buffer.ToString());
            rsStream.Write(prefix, 0, prefix.Length);
            if (response.Content != null)
            {
                using (var contentStream = response.Content.GetStream())
                {
                    contentStream.CopyContentsTo(rsStream);
                }                    
            }
        }
    }
}
