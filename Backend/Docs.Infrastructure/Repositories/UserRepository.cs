using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Docs.MetadataDbContext;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly UserDbContext _db;

		public UserRepository(UserDbContext db) : base(db)
		{
		}

		//public Task<Course> GetUserCourses()
		//{
		//	var coursesIds = this._db

		//	return courses;
		//}
	}
}
