using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Core
{
    public class ResponseHeader
    {
        private static Dictionary<string, string> _headers = new Dictionary<string, string>();

        
        public static Dictionary<string, string> Headers
        {
            get { return _headers; }
            private set { _headers = value; }
        }

        public ResponseHeader(string contentType, string age, string etag,string location,string proxyAuthentication, string retryAfter,string server,string vary,string authenticate)
        {                       
            _headers.Add("Age", age);
            _headers.Add("ETag", etag);
            _headers.Add("Locatiopn", location);
            _headers.Add("Proxy-Authentication", proxyAuthentication);
            _headers.Add("Retry-After", retryAfter);
            _headers.Add("Server", server);
            _headers.Add("Vary", vary);
            _headers.Add("WWW-Authenticate", authenticate);
             Headers = _headers;
        }     
    }
}
