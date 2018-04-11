using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.Entities
{
	public class Facility
	{
		public int FacilityID { get; set; }
		public string FacilityName { get; set; }
		public int? UserID { get; set; }
		public DateTime? LastUpdated { get; set; }
		public User FacilityUser { get; set; }
	}
}
