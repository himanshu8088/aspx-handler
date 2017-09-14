using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServer.Core
{
    public class RealResultProperty : IResultProperty
    {
        public ITcpClient Result { get; set; }

        public RealResultProperty(ITcpClient result)
        {
            Result = result;
        }
    }
}
