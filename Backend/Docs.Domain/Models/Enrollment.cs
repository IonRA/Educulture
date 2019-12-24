using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Domain.Models
{
	public class Enrollment
	{
		public int Id { get; set; }
		public int UserID { get; set; }
		public int CourseID { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
