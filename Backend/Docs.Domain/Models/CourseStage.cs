using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Domain.Models
{
	public class CourseStage : BaseEntity
	{
		public string Text { get; set; }
		public string Name { get; set; }
		public int CourseId { get; set; }
		public virtual Course Course { get; set; }
	}
}
