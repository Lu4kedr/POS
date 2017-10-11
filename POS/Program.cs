using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPServer server = new UDPServer();
            TCPClient client = new TCPClient();

            new Thread(server.UDPListener).Start();

            while (true)
            {
                string message = Console.ReadLine();
                client.Send("Lu4ke", message);
            }
        }
    }
}
