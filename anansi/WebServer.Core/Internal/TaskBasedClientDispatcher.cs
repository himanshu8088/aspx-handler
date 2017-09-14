using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.Core
{
    public class TaskBasedClientDispatcher : IDispatcher
    {
        private readonly IConnectionQueue _queue;
        private bool _isStopRequested;

        public TaskBasedClientDispatcher(IConnectionQueue queue)
        {
            _queue = queue;
            _isStopRequested = false;
        }

        public void Start()
        {
            Task.Factory.StartNew(StartDispatch);
        }

        private void StartDispatch()
        {
            while (_isStopRequested == false)
            {
                if (_queue.TryDequeue(out INetworkConnection conn) == true)
                {
                    Task.Factory.StartNew(() =>
                        {
                            using (conn)
                            {
                                IWorker worker = new Worker();
                                worker.Process(conn);
                            }
                        });
                }
                Thread.Sleep(10);
            }
        }

        public void Stop()
        {
            _isStopRequested = true;
        }
    }
}
