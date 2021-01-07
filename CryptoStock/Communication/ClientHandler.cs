using CryptoStock.Delegates;
using CryptoStock.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStock.Communication
{
    class ClientHandler
    {
        private readonly CustomLogger logger;
        private readonly Socket socket;
        private readonly byte[] buffer = new byte[1024];
        private readonly GuiUpdate informer;

        public ClientHandler(Socket socket, GuiUpdate informer, CustomLogger logger)
        {
            this.logger = logger;
            this.socket = socket;
            this.informer = informer;
            Init();
        }

        private void Init()
        {
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            while (true)
            {
                int length;
                length = socket.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer, 0, length);
                logger.WriteLog("ClientHandler.Receive.message: " + message);

                informer(message);
                message = "";
            }
        }
    }
}
