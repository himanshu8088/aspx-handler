//using System.Collections.Generic;
//using System.Net.Sockets;
//using System.Threading;
//using System.Threading.Tasks;
//using WebServer.Core;
//using Xunit;

//namespace WebServer.Tests
//{
//    public class ThreadDispatcherTester
//    {
//        [Fact]
//        public void Queue_should_empty_after_dispather_start()
//        {
//            IConnectionQueue queue = new ConnectionQueue();

//            for (int i = 0; i < 10; i++)
//            {
//                queue.Enqueue(new TcpClientWrapper(new TcpClient()));
//            }

//            IDispatcher dispatcher = new TaskBasedClientDispatcher(queue);

//            CancellationTokenSource tokenSource = new CancellationTokenSource(2000);
//            Task.Run(() => dispatcher.Start(), tokenSource.Token);
//            Thread.Sleep(3000);
//            Assert.Equal(0, queue.Count);
//        }
//    }
//}
