using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamBB05App.ServerCommunication
{
    class Server
    {
        public Action<string> informer;
        private readonly TcpListener tcpServer;
        private readonly List<ClientHandler> clients = new List<ClientHandler>();


        public Server(Action<string> informer)
        {
            this.informer = informer;
            tcpServer = new TcpListener(IPAddress.Loopback, 8888);
            tcpServer.Start();
            Thread t = new Thread(Accepting) { IsBackground = true };
            t.Start();
        }

        private void Accepting()
        {
            while (true)
            {
                clients.Add(new ClientHandler(informer, tcpServer.AcceptSocket()));
            }
        }
    }
}
