using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Docs.MetadataDbContext;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure.Repositories
{
	public class CourseRepository : BaseRepository<Course>, ICourseRepository
	{
		public CourseRepository(UserDbContext db) : base(db)
		{
		}

		public async Task<List<Course>> GetCoursesWhereUserEnrolled(int userId)
		{
			var courseIds = await _db.Set<Enrollment>().Where(enrollment => enrollment.UserID == userId)
				.Select(course => course.CourseID).ToListAsync();

			var courses = await _db.Set<Course>().Include("User").Where(course => courseIds.Contains(course.Id)).ToListAsync();

			return courses;
		}

		public async Task<List<Course>> GetCoursesCreatedByUser(int userId)
		{
			var courses = await _db.Set<Course>().Include("User").Where(c => c.UserId == userId).ToListAsync();
			
			return courses;
		}

		public async Task<List<Course>> GetCoursesWhereUserNotEnrolled(int userId)
		{
			var courseIds = await _db.Set<Enrollment>().Where(enrollment => enrollment.UserID == userId)
				.Select(course => course.CourseID).ToListAsync();

			var allCourses = await _db.Set<Course>().Include("User").Where(course => !courseIds.Contains(course.Id)).ToListAsync();

			return allCourses;
		}
	}
}
