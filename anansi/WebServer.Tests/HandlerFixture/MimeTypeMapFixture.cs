using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebServer.Core;

namespace WebServer.Tests
{
    public class MimeTypeMapFixture
    {
        [Theory]
        [InlineData(".html", "text/html")]
        [InlineData(".xml", "text/xml")]
        [InlineData(".txt", "text/plain")]
        public void GetMimeType_Should_Return_MappedMimeType(string extension,string mimeTypeExpected)
        {
            string actualMimeType=MimeTypeMap.GetMimeType(extension);            
            Assert.Equal(mimeTypeExpected,actualMimeType);
        }               
    }
}
