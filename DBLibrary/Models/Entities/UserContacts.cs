using DBLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Entities
{
    public class UserContacts: BaseEntity<int>
    {
        public int UserId { get; set; }

        public virtual ICollection<User> Contacts { get; set; }
    }
}
