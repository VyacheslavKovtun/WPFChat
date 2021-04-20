using DBLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Entities
{
    public class Group : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
