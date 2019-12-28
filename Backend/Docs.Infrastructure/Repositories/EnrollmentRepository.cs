using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure.Repositories
{
	public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
	{
		public EnrollmentRepository(DbContext db) : base(db)
		{
		}
	}
}
