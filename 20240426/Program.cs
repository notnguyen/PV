using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace _20240426


{
    internal class Program
    {
        /*private static Server server = new Server();*/

        static void Main(string[] args)
        {

            string ipAddress = "192.168.56.1"; // Adresa, na které má server naslouchat
            int port = 8888; // Port, na kterém má server naslouchat

            Server server = new Server(ipAddress, port);
            server.Start();
            /*ThreadPool.SetMinThreads(256, 256);

            TcpListener listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();

            while (true)
            {
                Socket clientSocket = listener.AcceptSocket();
                ThreadPool.QueueUserWorkItem(HandleClient, clientSocket);
            }
        }

        private static void HandleClient(object state)
        {
            Socket clientSocket = (Socket)state;
            server.HandleConnection(clientSocket);*/


        }
    }
}

