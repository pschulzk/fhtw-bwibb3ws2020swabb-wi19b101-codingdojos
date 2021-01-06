using SimpleAsyncChatServer.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleAsyncChatServer.Communication
{
    class Server
    {
        private Socket serverSock;
        private List<ClientHandler> clientsConnected = new List<ClientHandler>();
        private readonly MessageInformer messageInformer;
        public Server()
        {
            serverSock = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );
            Console.WriteLine("Socket created");
            serverSock.Bind(new IPEndPoint(IPAddress.Loopback, 8090));
            Console.WriteLine("Binding done");
            serverSock.Listen(5);
            Console.WriteLine("Listening started");
            messageInformer = new MessageInformer(this.Broadcast);
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartAccepting()
        {

            while (true)
            {
                clientsConnected.Add(new ClientHandler(serverSock.Accept(), messageInformer));
                Thread thread = new Thread(new ParameterizedThreadStart(clientsConnected.Last().StartReceiving));
                thread.Start();
                //ThreadPool.QueueUserWorkItem(new WaitCallback(clientsConnected.Last().StartReceiving), null);
                Console.WriteLine("New Client accepted");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void Broadcast(Socket caller, string message)
        {
            foreach (var item in clientsConnected)
            {
                if (!item.ClientSock.Equals(caller))
                    item.ClientSock.Send(Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
