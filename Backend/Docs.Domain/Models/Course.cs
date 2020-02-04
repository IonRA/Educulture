using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace Docs.Domain.Models
{
	public class Course : BaseEntity
	{
		public string Name { get; set; }
		public string Details { get; set; }
		public string Tags { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		//public virtual IEnumerable<Enrollment> Enrollments { get; set; }
	} 
}
