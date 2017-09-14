using System.Collections.Generic;
using System.Net;
using WebServer.Core;

namespace WebServer.Core
{
    public class ServerSettings
    {
        public string IPAddress { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 8080;
        public int MaxQueueSize { get; set; } = 100;
        public string TcpListenerWrapperType { get; set; }
    }
}
