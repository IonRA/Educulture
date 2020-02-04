using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Docs.MetadataDbContext;

namespace Docs.Infrastructure.Repositories
{
	public class CourseStageRepository : BaseRepository<CourseStage>, ICourseStageRepository
	{
		public CourseStageRepository(UserDbContext db) : base(db)
		{
		}
	}
}
