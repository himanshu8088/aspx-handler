using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;

namespace WebServer.Core
{
    public class FixedSizeConnectionQueue : IConnectionQueue
    {
        public FixedSizeConnectionQueue(int maxSize = 100)
        {
            _maxQueueSize = maxSize;
        }

        private readonly ConcurrentQueue<INetworkConnection> _queue = new ConcurrentQueue<INetworkConnection>();
        private readonly int _maxQueueSize;

        public void Enqueue(INetworkConnection conn)
        {
            if (_queue.Count >= _maxQueueSize)
                throw new Exception("Limit for maximum number of concurrent requests is reached.");
            _queue.Enqueue(conn);
        }

        public bool TryDequeue(out INetworkConnection conn)
        {
            return _queue.TryDequeue(out conn);
        }
    }
}
