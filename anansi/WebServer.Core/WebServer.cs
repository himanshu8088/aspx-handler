using System;
using System.IO;
using WebServer.Core;
using System.Threading.Tasks;
using System.Net;

namespace WebServer.Core
{
    public class WebServer
    {
        public WebServer(ServerSettings settings, IConnectionQueue queue = null,
            INetworkAdapter adapter = null,
            IDispatcher dispatcher = null
            )
        {
            _settings = settings;
            Queue = queue ?? new FixedSizeConnectionQueue(_settings.MaxQueueSize);
            Dispatcher = dispatcher ?? new TaskBasedClientDispatcher(Queue);
            IPAddress ip = IPAddress.Parse(_settings.IPAddress);
            Adapter = adapter ?? new NetworkAdapter(ip, _settings.Port);
            Adapter.NewConnection += (s, e) => Queue.Enqueue(e.Connection);
        }

        public IConnectionQueue Queue { get; private set; }

        public INetworkAdapter Adapter { get; private set; }

        public IDispatcher Dispatcher { get; private set; }

        private readonly ServerSettings _settings;

        public void Start()
        {   
            Dispatcher.Start();
            Adapter.Start();
        }

        public void Stop()
        {
            Dispatcher.Stop();
            Adapter.Stop();
        }
    }
}
