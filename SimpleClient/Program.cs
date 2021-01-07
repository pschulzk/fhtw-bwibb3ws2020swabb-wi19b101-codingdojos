using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 8090;
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            Console.WriteLine("############# Client connected #############");
            NetworkStream ns = client.GetStream();

            // string received;
            string message;
            while (true)
            {
                /*
                received = Console.ReadLine() + "\r\n";
                byte[] buffer = Encoding.ASCII.GetBytes(received);
                ns.Write(buffer, 0, buffer.Length);
                byte[] receivedBytes = new byte[1024];
                int byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
                byte[] formated = new byte[byte_count];
                Array.Copy(receivedBytes, formated, byte_count); //handle  the null characteres in the byte array
                string data = Encoding.ASCII.GetString(formated);
                Console.WriteLine(data);
                */

                // FORMAT: SL123AB @Salzburg@Ladung1@100@40@Ladung2@34@34
                message = Console.ReadLine();
                // Console.WriteLine("!!! Listening: Message: " + message);
                client.Client.Send(Encoding.UTF8.GetBytes(message));

                if (message == "exit")
                {
                    ns.Close();
                    client.Close();
                    Console.WriteLine("############# Disconnected from server #############");
                    // Console.ReadKey();
                    break;
                }
            }

            Console.WriteLine("############# Quitting server gracefully #############");
            Environment.Exit(0);
        }
    }
}
