using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary.Models
{
    public class ConnectedClient
    {
        public TcpClient Client { get; set; }
        public User User { get; set; }
    }
}
