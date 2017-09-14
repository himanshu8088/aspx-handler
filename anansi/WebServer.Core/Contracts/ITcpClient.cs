using System.Net.Sockets;

namespace WebServer.Core
{
    public interface ITcpClient
    {
        NetworkStream GetStream();
        void Dispose();
    }
}
