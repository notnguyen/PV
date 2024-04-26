using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace _20240426
{
    public class Server
    {
        private TcpListener listener;

        public Server(string ipAddress, int port)
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            listener = new TcpListener(address, port);
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine("Server spuštěn. Čekám na připojení...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Nový klient připojen.");

                Thread clientThread = new Thread(HandleClient);
                clientThread.Start(client);

            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            NetworkStream stream = client.GetStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8);

            try
            {
                // Přijmutí uživatelského jména
                streamWriter.WriteLine("Zadejte uživatelské jméno:");
                streamWriter.Flush();
                string username = streamReader.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new Exception("Uživatelské jméno nesmí být prázdné");
                }

                // Přijmutí hesla
                streamWriter.WriteLine("Zadejte heslo:");
                streamWriter.Flush();
                string password = streamReader.ReadLine();

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Heslo nesmí být prázdné");
                }

                // Ověření uživatelského jména a hesla
                if (IsValidCredentials(username, password))
                {
                    // Přihlášení úspěšné
                    streamWriter.WriteLine("Přihlášení úspěšné");
                    streamWriter.Flush();
                    // Zpracování dalších požadavků...
                }
                else
                {
                    // Přihlášení neúspěšné
                    streamWriter.WriteLine("Neplatné přihlašovací údaje");
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                streamWriter.WriteLine($"Chyba: {ex.Message}");
                streamWriter.Flush();
            }
            finally
            {
                streamReader.Close();
                streamWriter.Close();
                client.Close();
                Console.WriteLine("Klient odpojen.");
            }
        }

        private bool IsValidCredentials(string username, string password)
        {
            // Zde by bylo ověření jména a hesla v databázi nebo souboru
            // Pro účely demonstrace předpokládáme pevné údaje
            return username == "user" && password == "password";
        }

        public void Stop()
        {
            listener.Stop();
        }
    }
}