using System;
using System.IO;
using System.Net.Sockets;

namespace WebServer.Core
{
    public class TcpConnection : INetworkConnection
    {
        private TcpClient _client;

        public TcpConnection(TcpClient client)
        {
            _client = client;
            DataStream = client.GetStream();
        }

        public Stream DataStream { get; private set; }

        public void Dispose()
        {
            var copy = _client;
            copy?.Dispose();
            _client = null;
        }
    }
}
