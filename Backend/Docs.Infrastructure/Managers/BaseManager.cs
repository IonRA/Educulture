using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Docs.Infrastructure.Managers
{
    public class BaseManager<TEntity, TRepository>: IBaseManager<TEntity> 
        where TEntity : BaseEntity
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TRepository _repo;

        public BaseManager(TRepository repo)
        {
            _repo = repo;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await _repo.UpdateAsync(entity);

            return result;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _repo.GetOneByConditionAsync(expression);

            return entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await _repo.CreateAsync(entity);

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();

            return entities;
        }

    }
}
