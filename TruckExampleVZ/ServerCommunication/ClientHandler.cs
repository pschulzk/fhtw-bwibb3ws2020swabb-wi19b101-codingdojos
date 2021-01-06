using System.Net.Sockets;
using System.Text;
using TruckExampleVZ.Delegates;

namespace TruckExampleVZ.ServerCommunication
{
    class ClientHandler
    {
        private Socket socket;
        private readonly byte[] buffer = new byte[1024];
        private readonly GuiUpdate Informer;

        public ClientHandler(Socket socket, GuiUpdate informer)
        {
            this.socket = socket;
            Informer = informer;
        }

        private void Receive()
        {
            while (true)
            {
                int length;
                length = socket.Receive(buffer);
                Informer(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}
