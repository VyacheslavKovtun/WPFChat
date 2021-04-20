using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary.Models
{
    public class User
    {
        public string Nickname { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return Nickname;
        }
    }
}
