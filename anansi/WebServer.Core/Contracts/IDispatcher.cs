using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServer.Core
{
    public interface IDispatcher
    {
        void Start();

        void Stop();
    }
}
