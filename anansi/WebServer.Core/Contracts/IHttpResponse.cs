using System.Collections.Generic;

namespace WebServer.Core
{
    public interface IHttpResponse
    {
        IContent Content { get; set; }
        Dictionary<string, string> Headers { get; set; }
        HttpStatus Status { get; set; }
    }
}