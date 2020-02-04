using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;

namespace Docs.Infrastructure.Managers
{
	public class CourseStageManager: BaseManager<CourseStage, ICourseStageRepository>, ICourseStageManager
	{
		public CourseStageManager(ICourseStageRepository repo) : base(repo)
		{
		}

	}
}
