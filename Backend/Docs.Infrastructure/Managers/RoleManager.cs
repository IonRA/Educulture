using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Infrastructure.Managers
{
    class RoleManager : BaseManager<Role, IRoleRepository>, IRoleManager
    {

        public RoleManager(IRoleRepository repo) : base(repo)
        {
        }

    }
}
