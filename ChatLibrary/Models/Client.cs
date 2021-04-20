using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary.Models
{
    public class Client
    {
        public event Action<Message> ReceiveMessage;

        TcpClient client;
        public string Nickname { get; }
        public string Host { get; }
        public int Port { get; }

        public Client(string nickname, string host, int port)
        {
            Nickname = nickname;
            Host = host;
            Port = port;
        }

        public async Task Start()
        {
            client = new TcpClient(Host, Port);
            await Task.Run(() =>
            {
                byte[] nicknameBytes = Encoding.UTF8.GetBytes(Nickname);
                NetworkStream ns = client.GetStream();
                ns.Write(nicknameBytes, 0, nicknameBytes.Length);

                while (true)
                {
                    byte[] buff = new byte[10000];
                    try
                    {
                        ns.Read(buff, 0, 10000);
                    }
                    catch (SocketException ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }

                    var msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(buff, 0, buff.Length));

                    ReceiveMessage?.Invoke(msg);
                }
            });
        }

        public void SendMessage(string message)
        {
            byte[] buff = Encoding.UTF8.GetBytes(message);
            NetworkStream ns = client.GetStream();
            ns.Write(buff, 0, buff.Length);
        }

        public void Disconnect()
        {
            client.GetStream().Close();
            client.Close();
        }
    }
}
