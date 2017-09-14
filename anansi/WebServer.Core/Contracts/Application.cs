using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Core.Contracts
{
    public class Website
    {
        public string BaseDirectory { get; set; }

        public IWebsiteBinding Binding { get; set; }
    }

    public interface IWebsiteBinding
    {
        bool IsMatched(HttpRequest req);
    }

    public class PortBinding : IWebsiteBinding
    {
        public int Port { get; set; }

        public bool IsMatched(HttpRequest req)
        {
            throw new NotImplementedException();
        }
    }

    public class DomainNameBinding : IWebsiteBinding
    {
        public string DomainName { get; set; }

        public bool IsMatched(HttpRequest req)
        {
            throw new NotImplementedException();
        }
    }

    public class VirtualDirectoryBinding : IWebsiteBinding
    {
        public string Directory { get; set; }

        public bool IsMatched(HttpRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
