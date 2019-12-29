using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Docs.Domain.Interfaces;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using Docs.Infrastructure.Managers;
using Microsoft.EntityFrameworkCore;

namespace Docs.Infrastructure
{
	public class UserManager : BaseManager<User, IUserRepository>, IUserManager
    {

        public UserManager(IUserRepository repo) : base(repo)
        {
        }

    }
}
