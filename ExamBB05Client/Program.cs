﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExamBB05Client
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {

            // CLientkommunikation anlegen
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Loopback, 8081));
            Socket clientSocket = client.Client;

            while (true)
            {

                int warenKorbNr = rand.Next();
                int produktNr1 = rand.Next();
                int produktNr2 = rand.Next();

                int gewicht = int.Parse(Console.ReadLine());

                // { Warenkorb - WarenkorbNr{ Produkt - ProduktNr,2,1.75} { Produkt - ProduktNr,1,8.5} }
                string message = "{ Warenkorb - " + warenKorbNr + "{ Produkt - " + produktNr1 + ", 2, 1.75 } { Produkt - " + produktNr2 + ", 1, 8.5 } }";

                Console.Write("##### Sending message: " + message);

                //String an Server senden
                clientSocket.Send(Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
