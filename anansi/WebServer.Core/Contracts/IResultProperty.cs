using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServer.Core
{
    public interface IResultProperty
    {
        ITcpClient Result { get; }
    }
}
