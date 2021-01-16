using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExamBB05App.ServerCommunication
{
    public class ClientHandler
    {
        private Socket socket;
        private readonly byte[] buffer = new byte[512];
        readonly Action<string> Updater;

        public ClientHandler(Action<string> updater, Socket socket)
        {
            this.socket = socket;
            Updater = updater;
            Task.Factory.StartNew(Receive);
        }

        public void Receive()
        {
            while (true)
            {
                int length;
                length = socket.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer, 0, length);
                System.Diagnostics.Debug.WriteLine("!!! ClientHandler.Receive.message: " + message + "\r\n");

                Updater(message);
                message = "";
            }
        }
    }
}
