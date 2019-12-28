using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface IRankManager
    {
      Task<Rank> CreateAsync(Rank Rank);

        Task<Rank> UpdateAsync(Rank Rank);

        Task<Rank> GetAsync(Expression<Func<Rank, bool>> expression);

        Task<List<Rank>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
