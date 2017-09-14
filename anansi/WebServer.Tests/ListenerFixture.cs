//using Xunit;
//using WebServer.Core;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Net.Sockets;

//namespace WebServer.Tests
//{
//    public class ListenerFixture
//    {
//        [Fact]
//        public void Listener_should_accept_clients_and_add_them_to_queue()
//        {
//            IConnectionQueue queue = new FixedSizeConnectionQueue();
//            Listener listener = new Listener(queue, new TcpListenerFaker());
//            CancellationTokenSource tokenSource = new CancellationTokenSource(500);
//            Task.Run(() => listener.Start(), tokenSource.Token);
//            Thread.Sleep(500);
//            Assert.True(queue.Count > 0);
//        }
//    }
//}
