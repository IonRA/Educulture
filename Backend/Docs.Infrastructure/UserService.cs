using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Interfaces;
using Docs.Domain.Models;

namespace Docs.Infrastructure
{
	public class UserService: IUserManager
	{
		public Task<List<User>> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
