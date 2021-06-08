using DBLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Entities
{
    public class Message : BaseEntity<int>
    {
        public int UserFromId { get; set; }

        public int UserToId { get; set; }

        public string Text { get; set; }
    }
}
