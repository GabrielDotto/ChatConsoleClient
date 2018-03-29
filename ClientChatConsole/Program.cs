using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientChatConsole
{
    class Program
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Console.Title = "Chat Client";
            TryConect();
            EnviarLoop();
            Console.ReadLine();
        }

        private static void EnviarLoop()
        {
            while (true)
            {
                string req = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(req);
                _clientSocket.Send(buffer);
                //criar thread para enviar
                //criar thread para receber
                //no servidor, ajustar recebimento e envio de mensagem e saber quem é o client enviando.

            }
        }

        private static void TryConect()
        {
            int tentativas = 0;

            while(!_clientSocket.Connected)
            try
            {
                tentativas++;
                _clientSocket.Connect(IPAddress.Loopback, 11000);
            }
            catch (SocketException)
            {
                Console.Clear();
                Console.WriteLine("Tentativas de conexão: " + tentativas.ToString());
            }

            Console.Clear();
            Console.WriteLine("Connected");
            
        }
    }
}
