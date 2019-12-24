using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetOneByConditionAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
