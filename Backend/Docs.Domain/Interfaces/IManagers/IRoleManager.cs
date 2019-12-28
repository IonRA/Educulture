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
        Task<Role> CreateAsync(Role Role);

	    Task<Role> UpdateAsync(Role Role);

        Task<Role> GetAsync(Expression<Func<Role, bool>> expression);

        Task<List<Role>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
