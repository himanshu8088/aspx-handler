using System.Collections.Generic;

namespace WebServer.Core
{
    public interface IHttpRequest
    {
        Dictionary<string, string> Headers { get; }
        string Url { get; set; }
        string Verb { get; set; }
    }
}