using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Domain.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Adress { get; set; }
		public string Phone { get; set; }
		public virtual IEnumerable<Enrolment> Enrolments { get; set; }
		public int Points { get; set; }
		//public int RankId { get; set; }
		public int RoleId { get; set; }

	}
}
