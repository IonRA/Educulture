using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IRepositories
{
	public interface ICourseRepository : IBaseRepository<Course>
	{
		Task<List<Course>> GetCoursesWhereUserEnrolled(int userId);
		Task<List<Course>> GetCoursesCreatedByUser(int userId);
		Task<List<Course>> GetCoursesWhereUserNotEnrolled(int userId);
	}
}
