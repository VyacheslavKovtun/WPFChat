using DBLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Entities
{
    public class GroupMessage : BaseEntity<int>
    {
        public int UserFromId { get; set; }

        public int GroupToId { get; set; }

        public string Text { get; set; }
    }
}
