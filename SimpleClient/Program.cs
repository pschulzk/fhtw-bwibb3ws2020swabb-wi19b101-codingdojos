using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8090);
            while (true)
            {
                string message = "SL123AB@Salzburg@Ladung1@100@40@Ladung2@34@34";
                client.Client.Send(Encoding.UTF8.GetBytes(message));
                Console.ReadLine();
            }
        }
    }
}
