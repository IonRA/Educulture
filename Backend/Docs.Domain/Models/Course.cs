using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Docs.Domain.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public string Tags { get; set; }
		public Author Author { get; set; }
		public virtual IEnumerable<Enrolment> Enrolments { get; set; }
		
	} 
}
