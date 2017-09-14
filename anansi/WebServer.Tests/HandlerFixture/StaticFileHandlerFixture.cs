using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebServer.Core;
using Moq;
using System.Threading.Tasks;

namespace WebServer.Tests.HandlerFixture
{
    public class StaticFileHandlerFixture
    {
        [Fact]
        public void ProcessRequest_Should_Return_HttpResponse()
        {
            StaticFileHandler handler = new StaticFileHandler();
            IHttpRequest httpRequest = Mock.Of<IHttpRequest>(obj=>obj.Url=="/");
            IHttpResponse httpResponse  = handler.ProcessRequest(httpRequest);            
            Assert.NotNull(httpResponse);
        }
        //public void ProcessAsyncRequest_Should_Return_HttpResponse()
        //{
        //    StaticFileHandler handler = new StaticFileHandler();
        //    IHttpRequest httpRequest = Mock.Of<IHttpRequest>(obj => obj.Url == "/");
        //    Task<IHttpResponse> response = handler.ProcessAsyncRequest(httpRequest);
        //    IHttpResponse httpResponse = response.Result;
        //    Assert.NotNull(httpResponse);
        //}
    }
}
