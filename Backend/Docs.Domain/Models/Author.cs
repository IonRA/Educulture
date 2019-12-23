using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Domain.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public virtual IEnumerable<Course> Courses { get; set; }
		public int UserId { get; set; }
	}
}
