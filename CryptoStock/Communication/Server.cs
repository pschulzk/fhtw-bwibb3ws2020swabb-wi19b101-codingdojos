using CryptoStock.Delegates;
using CryptoStock.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoStock.Communication
{
    class Server
    {
        private readonly CustomLogger logger;
        private readonly TcpListener tcpServer;
        private readonly List<ClientHandler> clients = new List<ClientHandler>();
        readonly GuiUpdate Informer;

        public Server(GuiUpdate informer, CustomLogger logger)
        {
            this.logger = logger;
            Informer = informer;
            tcpServer = new TcpListener(IPAddress.Loopback, 8090);
            Init();
        }

        private void Init()
        {
            tcpServer.Start();
            Thread t = new Thread(AcceptClients) { IsBackground = true };
            t.Start();
        }

        private void AcceptClients()
        {
            while (true)
            {
                logger.WriteLog("Server.AcceptClients");
                clients.Add(new ClientHandler(tcpServer.AcceptSocket(), Informer, logger));
            }
        }
    }
}
