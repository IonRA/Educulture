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
                public Task<Rank> CreateAsync(Rank Rank);

        public Task<Rank> AlterAsync(Rank Rank);

        public Task<Rank> GetAsync(Expression<Func<Rank, bool>> expression);

        public Task<List<Rank>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
