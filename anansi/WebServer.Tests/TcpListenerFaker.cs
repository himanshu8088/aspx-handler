//using System;
//using System.Net.Sockets;
//using System.Threading;
//using System.Threading.Tasks;
//using WebServer.Core;

//namespace WebServer.Tests
//{
//    public class TcpListenerFaker : INetworkAdapter
//    {

//        public IResultProperty AcceptTcpClientAsync()
//        {
//            Thread.Sleep(100);
//            IResultProperty frp = new FakeResultProperty();
//            return frp;
//        }

//        public void Start()
//        {

//        }
//    }
//}
