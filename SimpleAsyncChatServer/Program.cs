using SimpleAsyncChatServer.Communication;
using System;

namespace SimpleAsyncChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartAccepting();
            server.StartAccepting();
            Console.ReadLine();
        }
    }
}
