using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.Entities
{
    public class Representative
    {        
        public int RepresentativeID { get; set; }
        public string FirstName { get; set; }
        public string  MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }

    }
}
