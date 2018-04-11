using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.Entities
{
	public class ExceptionLog
	{
		public virtual int ExceptionID { get; set; }
		public int? UserID { get; set; }
        public int? LoginID { get; set; }
        public int? FacilityID { get; set; }
		public DateTime? Time { get; set; }
		public string ServerName { get; set; }
		public string PageName { get; set; }
		public string Method { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public User ExceptionUser { get; set; }
		public Facility ExceptionFacility { get; set; }
	}
}
