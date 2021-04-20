using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Base
{
    public class BaseEntity<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}
