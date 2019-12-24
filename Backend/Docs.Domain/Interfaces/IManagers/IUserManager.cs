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
        public Task<User> CreateAsync(User user);

        public Task<User> AlterAsync(User User);

        public Task<User> GetAsync(Expression<Func<User, bool>> expression);

        public Task<List<User>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
