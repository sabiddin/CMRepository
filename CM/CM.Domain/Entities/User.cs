using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.Entities
{
    public class User
    {        
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Locked { get; set; }
        public int? RoleID { get; set; }
        public DateTime? DateAdded { get; set; }
        public Role Role { get; set; }
    }
}
