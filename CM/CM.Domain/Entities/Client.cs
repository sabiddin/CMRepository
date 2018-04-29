using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.Entities
{
    public class Client
    {       
        public int ClientID { get; set; }
        public string ClientSSN { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientMiddleName { get; set; }
        public string ClientLastName { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? RepresentativeID { get; set; }
        public Representative Representative { get; set; }
    }
}
