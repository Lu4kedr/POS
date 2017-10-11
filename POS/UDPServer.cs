using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class UDPServer
    {

        private const int listenPort = 8001;
        public void UDPListener()
        {

            IPAddress server = IPAddress.Parse("10.0.0.12");

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint endPoint = new IPEndPoint(server, listenPort);
            byte[] message;
            string encodedMessage;

            while (true)
            {
                encodedMessage = "";
              
                message = listener.Receive(ref endPoint);
                encodedMessage += "IPAdress: "+ message[0].ToString()+"." + message[1].ToString() + "." + message[2].ToString() + "." + message[3].ToString()+" Nick: ";
                encodedMessage += Encoding.ASCII.GetString(message, 4, 10) ;
                encodedMessage += " Delka: " + message[14].ToString();
                encodedMessage += " Kontrolni Soucet: "+ message[15].ToString();
                encodedMessage += " Zprava: " + Encoding.ASCII.GetString(message, 16, message.Length - 16);
                Console.WriteLine("Recive:  "+encodedMessage.Trim('\0'));
            }
        }
    }
}
