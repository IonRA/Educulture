using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure.Repositories
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(DbContext db) : base(db)
		{
		}
	}
}
