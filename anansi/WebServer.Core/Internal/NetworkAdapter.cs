using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Core
{
    public class NetworkAdapter : INetworkAdapter
    {
        private TcpListener _tcp;
        public event EventHandler<NewConnectionEventArgs> NewConnection;

        public NetworkAdapter(IPAddress address, int port)
        {
            _tcp = new TcpListener(address, port);
        }

        private bool _isStopRequested = false;

        public void Start()
        {
            Task.Factory.StartNew(() => StartInternal());
        }

        private void StartInternal()
        {
            _tcp.Start();

            while (_isStopRequested == false)
            {
                //TODO: Make this async
                var client = _tcp.AcceptTcpClientAsync().GetAwaiter().GetResult();
                DispatchAsynchronously(client);
            }

            _tcp.Stop();
        }

        public void Stop()
        {
            _isStopRequested = true;
        }

        private void DispatchAsynchronously(TcpClient client)
        {
            var conn = new TcpConnection(client);
            Task.Run(() => OnNewConnection(conn));
        }

        protected void OnNewConnection(INetworkConnection conn)
        {
            NewConnection(this, new NewConnectionEventArgs(conn));
        }
    }
}
