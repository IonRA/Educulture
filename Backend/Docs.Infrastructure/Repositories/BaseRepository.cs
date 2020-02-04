using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Docs.MetadataDbContext;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly UserDbContext _db;

		public BaseRepository(UserDbContext db)
		{
			_db = db;
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			var result = (await _db.Set<TEntity>().AddAsync(entity)).Entity;

			await _db.SaveChangesAsync();

			return result;
		}

		public async Task DeleteAsync(int id)
		{
			var entity = _db.Set<TEntity>().FirstOrDefault(c => c.Id == id);

			_db.Remove<TEntity>(entity);

			await _db.SaveChangesAsync();
		}

		public async Task<List<TEntity>> GetAllAsync()
		{
			return await _db.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetOneByConditionAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _db.Set<TEntity>().FirstOrDefaultAsync(expression);
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			var result = _db.Set<TEntity>().Update(entity).Entity;

			await _db.SaveChangesAsync();

			return result;
		}
	}
}
