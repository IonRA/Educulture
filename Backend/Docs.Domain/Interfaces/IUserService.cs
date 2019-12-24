using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Models;

namespace Docs.Domain.Interfaces
{
	public interface IUserService
	{
		Task<List<User>> GetAll();
	}
}
