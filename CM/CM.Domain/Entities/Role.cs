using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.Entities
{
    public class Role
    {        
        public int RoleID { get; set; }
        public string RoleDesc { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
