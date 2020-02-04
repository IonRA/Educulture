using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Domain.Models
{
	public class Enrollment : BaseEntity
	{
		public int UserID { get; set; }
		public int CourseID { get; set; }

		public DateTime CreatedOn
		{
			get => CreatedOn;
			set => CreatedOn = DateTime.Now;
		}
	}
}
