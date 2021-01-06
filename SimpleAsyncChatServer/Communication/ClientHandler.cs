using SimpleAsyncChatServer.Delegates;
using System;
using System.Net.Sockets;
using System.Text;

namespace SimpleAsyncChatServer.Communication
{
    class ClientHandler
    {
        private Socket clientSock;
        private readonly MessageInformer informer;

        public Socket ClientSock
        {
            get { return clientSock; }
            //set { clientSock = value; }
        }

        private readonly byte[] buffer = new byte[512];

        public ClientHandler(Socket clientSock, MessageInformer informer)
        {
            this.clientSock = clientSock;
            this.informer = informer;


        }

        /// <summary>
        ///  Receive messages from the client
        /// </summary>
        /// <param name="obj"></param>
        public void StartReceiving(object obj)
        {
            int length;
            string name = "";
            string message = "";

            #region  Handle Name
            do
            {
                length = clientSock.Receive(buffer);
                name += Encoding.UTF8.GetString(buffer, 0, length);

            } while (!name.Contains("\r\n"));
            name = name.Substring(0, name.Length - 2);

            clientSock.Send(Encoding.UTF8.GetBytes("hello " + name + "\r\n"));

            #endregion 

            while (true)
            {
                length = clientSock.Receive(buffer);
                message += Encoding.UTF8.GetString(buffer, 0, length);
                if (message.Contains("\r\n"))
                {

                    Console.Write(name + ": " + message);
                    informer(clientSock, name + ": " + message);
                    message = "";

                }
            }

        }
    }
}
