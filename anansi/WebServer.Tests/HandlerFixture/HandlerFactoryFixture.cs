using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebServer.Core;
using Moq;

namespace WebServer.Tests
{
   public class HandlerFactoryFixture
    {
        [Fact]
        public void Create_Should_Always_Return_Handler()
        {
            Mock<IHttpRequest> httpRequest = new Mock<IHttpRequest>();
            httpRequest.SetupAllProperties();            
            HandlerFactory factory = new HandlerFactory();
            IHttpHandler httpHandler=factory.Create(httpRequest.Object);
            Assert.NotNull(httpHandler);            
        }
    }
}
