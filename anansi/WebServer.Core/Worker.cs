using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WebServer.Core
{
    public class Worker : IWorker
    {
        public Worker(IHttpAdapter adapter = null, IHandlerFactory factory = null)
        {
            Adapter = adapter ?? new HttpAdapter();
            HandlerFactory = factory ?? new HandlerFactory();
        }

        public IHttpAdapter Adapter { get; private set; }

        public IHandlerFactory HandlerFactory { get; private set; }

        public void Process(INetworkConnection connection)
        {
            try
            {
                IHttpRequest httpRequest = Adapter.ReadRequest(connection.DataStream);
                IHttpHandler handler = HandlerFactory.Create(httpRequest);
                IHttpResponse httpResponse = handler.ProcessRequest(httpRequest);
                Adapter.WriteResponse(httpResponse, connection.DataStream);
            }
            catch(Exception ex)
            {
            }
        }
    }
}
