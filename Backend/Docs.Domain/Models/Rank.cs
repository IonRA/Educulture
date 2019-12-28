using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Domain.Models
{
	public class Rank : BaseEntity
	{
		public string Name { get; set; }
		public int MinPoints { get; set; }
	}
}
