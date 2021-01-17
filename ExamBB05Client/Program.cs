using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ExamBB05Client
{
    class Program
    {
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.Write("##### START #####");

            int redo = 6;

            // CLientkommunikation anlegen
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Loopback, 8888));
            Socket clientSocket = client.Client;

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) => OnTimedEvent(s, e);
            timer.Start();
            Console.ReadLine();
            timer.Stop();

            void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
            {
                int warenKorbNr = GetId();
                int produktNr1 = GetId();
                int produktNr2 = GetId();

                // { Warenkorb - @WarenkorbNr{ Produkt - @ProduktNr,2,1.75} { Produkt - @ProduktNr,1,8.5} }
                string message = "{ Warenkorb - @" + warenKorbNr.ToString() + "{ Produkt - @" + produktNr1.ToString() + ", @5, @1.75 } { Produkt - @" + produktNr2.ToString() + ", @1, @8.5 } }";

                Console.Write("##### Sending message: " + message + "\r\n");

                //String an Server senden
                clientSocket.Send(Encoding.UTF8.GetBytes(message));

                if (redo == 0)
                {
                    timer.Enabled = false;
                }

                redo = redo - 1;
            }

            int GetId()
            {
                return rand.Next(1000, 9999);
            }
        }
    }
}
