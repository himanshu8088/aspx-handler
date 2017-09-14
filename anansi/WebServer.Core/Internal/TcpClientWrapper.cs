using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServer.Core
{
    public class TcpClientWrapper : ITcpClient
    {
        private TcpClient _actualClient;

        public TcpClientWrapper(TcpClient client)
        {
            _actualClient = client;
        }

        public void Dispose()
        {
            _actualClient.Dispose();
        }

        public NetworkStream GetStream()
        {
            return _actualClient.GetStream();
        }
    }
}
