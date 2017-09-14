using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Core
{
    public interface INetworkAdapter
    {
        void Start();

        void Stop();

        event EventHandler<NewConnectionEventArgs> NewConnection;
    }
}
