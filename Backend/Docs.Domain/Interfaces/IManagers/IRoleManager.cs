using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface IRoleManager
    {
        public Task<Role> CreateAsync(Role Role);

        public Task<Role> AlterAsync(Role Role);

        public Task<Role> GetAsync(Expression<Func<Role, bool>> expression);

        public Task<List<Role>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
