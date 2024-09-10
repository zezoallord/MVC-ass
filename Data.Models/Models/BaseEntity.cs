using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class BaseEntity
    {
        public int id { get; set; }
       public string Name { get; set; }
        public DateTime CreateAT { get; set; } = DateTime.Now;
        public bool isDeleted { get; set; }
    }
}
