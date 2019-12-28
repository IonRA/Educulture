using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure.Repositories
{
	public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
	{
		public AuthorRepository(DbContext db) : base(db)
		{
		}
	}
}
