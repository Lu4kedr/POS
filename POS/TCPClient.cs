using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class TCPClient
    {
        private const int sendPort = 8000;
        private byte[] MyIp = { 10, 0, 0, 26 };

        public void Send(string Nick, string Message)
        {
            int length = 16 + Message.Length;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress server = IPAddress.Parse("10.0.0.12");
            IPEndPoint endPoint = new IPEndPoint(server, sendPort);
            byte[] message = new byte[length];
            Array.Copy(MyIp,0, message, 0,MyIp.Length);
            Array.Copy(Encoding.ASCII.GetBytes(Nick), 0, message, 4, Nick.Length);
            message[14] = (byte)Message.Length;
            message[15] = (byte)KS(Message);
            Array.Copy(Encoding.ASCII.GetBytes(Message), 0, message, 16, Message.Length);


            try
            {

                socket.Connect(endPoint);
                socket.Send(message);
                Console.WriteLine("Send: " + Nick + ": " + Message);
            }
            catch(Exception ex)
            {

            }
        }


        private int KS(string message)
        {
           return message.Count(x => x == 'a' || x == 'A' || x == 'e' || x == 'E' || x == 'i' || x == 'I' || x == 'o' || x == 'O' || x == 'u' || x == 'U');
        }
    }
}
