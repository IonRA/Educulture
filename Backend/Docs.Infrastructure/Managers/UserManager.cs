using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Interfaces;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Models;

namespace Docs.Infrastructure
{
	public class UserManager: IUserManager
	{
		public Task<List<User>> GetAll()
		{
			throw new NotImplementedException();
		}

        Task<User> IUserManager.AlterAsync(User User)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserManager.CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserManager.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IUserManager.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserManager.GetAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
