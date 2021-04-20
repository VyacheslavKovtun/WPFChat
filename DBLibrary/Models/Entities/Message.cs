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
        public User From { get; set; }
        public int FromId { get; set; }

        public User To { get; set; }
        public int ToId { get; set; }

        public string Text { get; set; }
    }
}
