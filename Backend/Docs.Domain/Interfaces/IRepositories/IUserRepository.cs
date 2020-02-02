using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IRepositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		//Task<Course> GetUserCourses();
	}
}
