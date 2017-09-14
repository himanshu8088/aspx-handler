using System;
using System.Collections.Generic;
using WebServer.Core.FileHandler;

namespace WebServer.Core
{
    public class HandlerFactory : IHandlerFactory
    {
        public IHttpHandler Create(IHttpRequest httpRequest)
        {
            return new TspxHandler();                        
        }
    }    
}


