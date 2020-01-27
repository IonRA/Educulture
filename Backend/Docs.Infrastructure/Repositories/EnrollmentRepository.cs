using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Docs.MetadataDbContext;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure.Repositories
{
	public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
	{
		public EnrollmentRepository(UserDbContext db) : base(db)
		{
		}
	}
}
