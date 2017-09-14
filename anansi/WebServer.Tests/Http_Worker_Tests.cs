using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using WebServer.Core;
using System.IO;

namespace WebServer.Tests
{
    public class Http_Worker_Tests
    {
        [Fact]
        public void Worker_always_perform_all_coordinating_tasks()
        {
            Mock<INetworkConnection> networkConnection = new Mock<INetworkConnection>();
            Mock<IHttpAdapter> adapter = new Mock<IHttpAdapter>();
            MemoryStream sampleStream = new MemoryStream();
            Mock<IHandlerFactory> handlerFactory = new Mock<IHandlerFactory>();
            Mock<IHttpRequest> request = new Mock<IHttpRequest>();
            Mock<IHttpHandler> handler = new Mock<IHttpHandler>();
            Mock<IHttpResponse> response = new Mock<IHttpResponse>();
            byte[] sampleBytes = new byte[10];
            adapter.Setup(x => x.ReadRequest(sampleStream)).Returns(request.Object);
            adapter.Setup(x => x.WriteResponse(response.Object, sampleStream));
            handler.Setup(x => x.ProcessRequest(request.Object)).Returns(response.Object);
            handlerFactory.Setup(x => x.Create(request.Object)).Returns(handler.Object);
            Worker worker = new Worker(adapter.Object, handlerFactory.Object);
            networkConnection.Setup(x => x.DataStream).Returns(sampleStream);
            worker.Process(networkConnection.Object);
            adapter.Verify(x => x.ReadRequest(sampleStream), Times.Once);
            handlerFactory.Verify(x => x.Create(request.Object), Times.Once);
            handler.Verify(x => x.ProcessRequest(request.Object), Times.Once);
            adapter.Verify(x => x.WriteResponse(response.Object, sampleStream), Times.Once);
        }
    }
}
