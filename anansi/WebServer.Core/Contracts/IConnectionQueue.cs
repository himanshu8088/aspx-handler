namespace WebServer.Core
{
    public interface IConnectionQueue
    {
        void Enqueue(INetworkConnection conn);

        bool TryDequeue(out INetworkConnection conn);
    }
}
