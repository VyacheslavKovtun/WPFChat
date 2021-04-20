using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatLibrary.Models
{
    public class Server
    {
        public event Action ServerStarted;
        public event Action<User> NewClientConnected;

        public static ConnectedClient DirectedClient { get; set; }

        public static List<ConnectedClient> clients = new List<ConnectedClient>();
        TcpListener listener;
        public string Host { get; }
        public int Port { get; }

        public Server(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public async Task Start()
        {
            IPAddress ip = IPAddress.Parse(Host);
            listener = new TcpListener(ip, Port);
            ServerStarted?.Invoke();

            await Task.Run(() =>
            {
                listener.Start();

                ListenDisconnectedClients();

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    byte[] buff = new byte[100];
                    int count = client.GetStream().Read(buff, 0, 100);
                    string nickname = Encoding.UTF8.GetString(buff, 0, count);

                    string[] info = client.Client.RemoteEndPoint.ToString().Split(':');
                    ConnectedClient connectedClient = new ConnectedClient
                    {
                        User = new User
                        {
                            Nickname = nickname,
                            Ip = info[0],
                            Port = int.Parse(info[1])
                        },
                        Client = client
                    };

                    NewClientConnected?.Invoke(connectedClient.User);
                    clients.Add(connectedClient);
                    ListenClient(connectedClient);
                }
            });
        }

        public void ListenClient(ConnectedClient client)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    NetworkStream ns = client.Client.GetStream();
                    byte[] buff = new byte[100];
                    int count = ns.Read(buff, 0, 100);

                    await SendMessageToClients(client, Encoding.UTF8.GetString(buff, 0, count));
                }
            });
        }

        private async Task SendMessageToClients(ConnectedClient from, string data)
        {
            await Task.Run(() =>
            {
                Message msg = new Message
                {
                    Text = data,
                    User = from.User
                };

                string serialize = JsonConvert.SerializeObject(msg);

                var ns = DirectedClient.Client.GetStream();
                byte[] buff = Encoding.UTF8.GetBytes(serialize);
                ns.Write(buff, 0, buff.Length);
            });
        }

        private void ListenDisconnectedClients()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var disconnectedClients = clients.Where(client => !client.Client.Connected);
                    foreach (var client in disconnectedClients)
                    {
                        Console.WriteLine($"Disconnected: {client.User.Nickname}");
                    }
                    clients.RemoveAll(client => !client.Client.Connected);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
