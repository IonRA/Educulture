using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Docs.Domain.Models
{
	public class Question : BaseEntity
	{
		public string Content { get; set; }
		public int CourseId { get; set; }
	}
}
