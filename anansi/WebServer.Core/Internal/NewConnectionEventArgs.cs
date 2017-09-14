using System;

namespace WebServer.Core
{
    public class NewConnectionEventArgs : EventArgs
    {
        public NewConnectionEventArgs(INetworkConnection conn)
        {
            Connection = conn;
        }

        public INetworkConnection Connection { get; private set; }
    }
}
