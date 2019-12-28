using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Models;

namespace Docs.Domain.Interfaces.IManagers
{
	public interface IUserManager
	{
        Task<User> CreateAsync(User user);

		Task<User> UpdateAsync(User User);

        Task<User> GetAsync(Expression<Func<User, bool>> expression);

        Task<List<User>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
