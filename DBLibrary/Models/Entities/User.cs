using DBLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Entities
{
    public class User : BaseEntity<int>
    {
        public string Nickname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<int> ContactsId { get; set; }
        public virtual ICollection<User> Contacts { get; set; }
    }
}
