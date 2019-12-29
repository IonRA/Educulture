using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface IBaseManager<TEntity>
    {
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> CreateAsync(TEntity entity);

        Task DeleteAsync(int id);

        Task<List<TEntity>> GetAllAsync();
    }
}
