using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TruckExampleVZ.Delegates;

namespace TruckExampleVZ.ServerCommunication
{
    class Server
    {
        private readonly TcpListener tcpServer;
        private readonly List<ClientHandler> clients = new List<ClientHandler>();
        readonly GuiUpdate Informer;

        public Server(GuiUpdate informer)
        {
            Informer = informer;
            tcpServer = new TcpListener(IPAddress.Loopback, 8090);
            tcpServer.Start();
            Thread t = new Thread(AcceptClients) { IsBackground = true };
            t.Start();
        }

        private void AcceptClients()
        {
            while (true)
            {
                clients.Add(new ClientHandler(tcpServer.AcceptSocket(), Informer));
            }
        }
    }
}
