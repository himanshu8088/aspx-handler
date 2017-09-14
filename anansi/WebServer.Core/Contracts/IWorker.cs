using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace WebServer.Core
{
    public interface IWorker
    {
        void Process(INetworkConnection conn);
    }
}
