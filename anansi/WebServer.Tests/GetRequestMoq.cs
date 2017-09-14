using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.Core;
using Xunit;

namespace WebServer.Tests
{
    public class GetRequestMoq
    {
        [Fact]
        public void Get_Request_Moq_Test()
        {
            var httpAdapterMoq = new Moq.Mock<IHttpAdapter>();
            var httpRequest = new HttpRequest();
            byte[] bytedata = Encoding.ASCII.GetBytes("GET /pass.html HTTP/1.1\r\nContent Type: html\r\n\n\r\n");
            Stream stream = new MemoryStream();
            stream.Write(bytedata, 0, bytedata.Length);
            stream.Position=0;
            httpRequest.Verb = "GET";
            httpRequest.Url = "/pass.html";
            httpRequest.Headers.Add("Content Type", "html");
            httpAdapterMoq.Setup(request => request.ReadRequest(It.IsAny<Stream>())).Returns(httpRequest);
            var result = httpAdapterMoq.Object.ReadRequest(stream);
            Assert.Equal(httpRequest, result);
            httpAdapterMoq.Verify(adapter => adapter.ReadRequest(It.IsAny<Stream>()), Times.Once);
        }
    }
}
