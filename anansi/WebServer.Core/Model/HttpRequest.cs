using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Core
{
    public class HttpRequest : IHttpRequest
    {
        public string Verb { get; set; }

        public string Url { get; set; }

        public Dictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
