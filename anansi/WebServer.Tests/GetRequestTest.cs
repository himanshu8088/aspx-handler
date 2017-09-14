using System;
using System.Collections.Generic;
using WebServer;
using System.Text;
using Xunit;
using WebServer.Core;
using System.IO;

namespace WebServer.Tests
{
    public class Get_Request_Test
    {
        [Fact]
        public void Get_Request_Test_Method()
        {
            string clientRequest = "GET /pass.html HTTP/1.1\r\nContent Type: html\r\n\n\r\n";
            byte[] clientRequestByte = Encoding.ASCII.GetBytes(clientRequest);
            MemoryStream stream = new MemoryStream();
            stream.Write(clientRequestByte, 0, clientRequestByte.Length);
            var arr = stream.ToArray();
            string str = "";
            foreach (var element in arr)
            {
                str += (char)element;
            }
            stream.Position = 0;
            IHttpRequest request = (new HttpAdapter()).ReadRequest(stream);
            IHttpRequest requestTest = new HttpRequest();
            requestTest.Verb = "GET";
            requestTest.Url = "/pass.html";
            requestTest.Headers.Add("Content Type", "html");
            Assert.Equal(requestTest.Url, request.Url);
            Assert.Equal(requestTest.Verb, request.Verb);
            Assert.Equal(requestTest.Headers, request.Headers);
        }
    }


    public static class CompatibilityExtensions
    {
        public static IHttpRequest GetRequest(this IHttpAdapter adapter, byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                return adapter.ReadRequest(stream);
            }
        }

        public static byte[] GetResponse(this IHttpAdapter adapter, IHttpResponse response)
        {

            using (var stream = new MemoryStream())
            {
                adapter.WriteResponse(response, stream);
                return stream.ToArray();
            }
        }

    }
}
