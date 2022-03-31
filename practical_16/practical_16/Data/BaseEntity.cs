using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_16.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
