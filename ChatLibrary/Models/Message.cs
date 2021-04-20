using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary.Models
{
    public class Message
    {
        public User User { get; set; }
        public string Text { get; set; }
    }
}
