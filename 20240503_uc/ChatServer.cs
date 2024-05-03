using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _20240503_uc
{
    public class ChatServer
    {
        private TcpListener _listener;
        private bool _isRunning;

        public ChatServer(int port)
        {
            this._listener = new TcpListener(System.Net.IPAddress.Any, port);
            _isRunning = true;
            this._listener.Start();
            serverLoop();
        }

        private void serverLoop()
        {
            Console.WriteLine("Server byl spusten");
            while (this._isRunning)
            {
                TcpClient client = this._listener.AcceptTcpClient();
                Thread thread = new Thread(new ParameterizedThreadStart(clientHandler));
                thread.Start(client); 
            }
        }

        private Dictionary<string, StreamWriter> clients = new Dictionary<string, StreamWriter>();

        private void clientHandler(object? obj)
        {
            TcpClient client = (TcpClient)obj;

            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8);
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);

            bool connected = true;

            writer.WriteLine("Zadej jmeno: ");
            writer.Flush();

            string name = reader.ReadLine();

            clients.Add(name, writer);

            while (connected)
            {
                string data = reader.ReadLine();

                foreach(var sw in clients)
                {
                    if(writer != sw.Value)
                    {
                        sw.Value.Write(name + ":" + data);
                        sw.Value.Flush();
                    }
                    

                }

            }
            clients.Remove(name);
            writer.Close();
            reader.Close();
            client.Close();


        }
    }
}
