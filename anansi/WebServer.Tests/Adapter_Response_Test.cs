using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.Core;
using Xunit;

namespace WebServer.Tests
{
    public class Adapter_Response_Tester
    {
        [Fact]
        public void Response_should_always_start_with_a_standard_http_status_line()
        {
            IHttpResponse sampleHttpResponse = new HttpResponse()
            {
                Status = HttpStatus.NotFound,
            };
            byte[] httpResponseInStream = (new HttpAdapter()).GetResponse(sampleHttpResponse);
            string response = Encoding.ASCII.GetString(httpResponseInStream);
            Assert.StartsWith("HTTP/1.1 404 Not Found", response);
        }

        [Fact]
        public void Response_should_never_be_null()
        {
            IHttpResponse sampleHttpResponse = new HttpResponse()
            {
                Status = HttpStatus.NotFound,
            };
            byte[] httpResponseInStream = (new HttpAdapter()).GetResponse(sampleHttpResponse);
            Assert.NotNull(Encoding.ASCII.GetString(httpResponseInStream));
        }

        [Fact]
        public void Response_is_constructed_same_as_send_through_response_object()
        {
            IHttpResponse sampleHttpResponse = new HttpResponse()
            {
                Status = HttpStatus.OK
            };
            sampleHttpResponse.Headers.Add("Content-Type", "text/plain");
            sampleHttpResponse.Headers.Add("Encoding", "gzip");
            sampleHttpResponse.Headers.Add("Language", "en-US");
            sampleHttpResponse.Content = new StringContent("<html><head></head><body></body></html>");
            byte[] httpResponseInStream = (new HttpAdapter()).GetResponse(sampleHttpResponse);
            string resp = Encoding.ASCII.GetString(httpResponseInStream);
            Assert.Equal("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\nEncoding: gzip\r\nLanguage: en-US\r\n\r\n<html><head></head><body></body></html>", resp);
        }

        [Fact]
        public void Response_should_contain_status_line_in_the_start_and_content_at_the_end()
        {
            IHttpResponse sampleHttpResponse = new HttpResponse()
            {
                Status = HttpStatus.OK
            };
            sampleHttpResponse.Headers.Add("Content-Type", "text/plain");
            sampleHttpResponse.Headers.Add("Content-Length", "2435");
            sampleHttpResponse.Headers.Add("Encoding", "gzip");
            sampleHttpResponse.Headers.Add("Accept-Charset", "utf-8");
            sampleHttpResponse.Headers.Add("Connection", "keep-alive");
            sampleHttpResponse.Content = new StringContent("<html><head></head><body></body></html>");
            byte[] httpResponseInStream = (new HttpAdapter()).GetResponse(sampleHttpResponse);
            string response = Encoding.ASCII.GetString(httpResponseInStream);
            Assert.StartsWith("HTTP/1.1 200 OK", response);
            Assert.EndsWith("<html><head></head><body></body></html>", response);
        }

        [Fact]
        public void Response_should_contain_headers_in_sequence()
        {
            IHttpResponse sampleHttpResponse = new HttpResponse()
            {
                Status = HttpStatus.OK
            };
            sampleHttpResponse.Headers.Add("Content-Type", "text/plain");
            sampleHttpResponse.Headers.Add("Content-Length", "2435");
            sampleHttpResponse.Headers.Add("Encoding", "gzip");
            sampleHttpResponse.Headers.Add("Accept-Charset", "utf-8");
            sampleHttpResponse.Headers.Add("Connection", "keep-alive");
            sampleHttpResponse.Content = new StringContent("<html><head></head><body></body></html>");
            byte[] httpResponseInStream = (new HttpAdapter()).GetResponse(sampleHttpResponse);
            string response = Encoding.ASCII.GetString(httpResponseInStream);
            Assert.Contains("Content-Type: text/plain\r\nContent-Length: 2435\r\nEncoding: gzip\r\nAccept-Charset: utf-8\r\nConnection: keep-alive", response);
        }
    }


    internal class StringContent : IContent
    {
        private string _txt;

        public StringContent(string text)
        {
            _txt = text;
        }

        public string ContentType => "text/plain";

        public Stream GetStream()
        {
            return new MemoryStream(Encoding.ASCII.GetBytes(_txt));
        }
    }
}
