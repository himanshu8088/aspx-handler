using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using WebServer.Core;

namespace WebServer.Tests
{
    public class FakeResultProperty : IResultProperty
    {
        public ITcpClient Result
        {
            get
            {
                return new TcpClientWrapper(new TcpClient());
            }
        }
    }
}
