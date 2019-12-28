using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Interfaces;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure
{
	public class UserManager: IUserManager
	{
		private IUserRepository _repo;

		public UserManager(IUserRepository repo)
		{
			_repo = repo;
		}

		public async Task<User> UpdateAsync(User user)
        {
	        var result = await _repo.UpdateAsync(user);

	        return result;
        }

		public Task<User> GetAsync(Expression<Func<User, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public async Task<User> CreateAsync(User user)
        {
	        var result = await _repo.CreateAsync(user);

	        return result;
        }

        public async Task DeleteAsync(int id)
        {
			await _repo.DeleteAsync(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
	        var users = await _repo.GetAllAsync();

	        return users;
        }

    }
}
