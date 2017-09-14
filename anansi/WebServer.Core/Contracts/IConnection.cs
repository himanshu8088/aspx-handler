using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebServer.Core
{
    public interface INetworkConnection : IDisposable
    {
        Stream DataStream { get; } 
    }
}
