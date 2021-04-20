using ChatLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static Server server = new Server("192.168.1.2", 55_000);
        static void Main(string[] args)
        {
            server.ServerStarted += Server_ServerStarted;
            server.NewClientConnected += Server_NewClientConnected;
            Run();

            Console.Read();
        }

        private static void Server_NewClientConnected(User user)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"New client connected: ");
            Console.WriteLine($"IP: {user.Ip}");
            Console.WriteLine($"Port: {user.Port}");
            Console.WriteLine($"Nickname: {user.Nickname}");
            Console.WriteLine("-----------------------------");
        }

        private static void Server_ServerStarted()
        {
            Console.WriteLine("Server has been started!");
        }

        static async void Run()
        {
            await server.Start();
        }
    }
}
