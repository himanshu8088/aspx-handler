using System;
using System.Collections.Generic;


namespace WebServer.Core
{
    public class HttpResponse : IHttpResponse
    {
        public HttpStatus Status { get; set; }

        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public IContent Content { get; set; }
    }
}
