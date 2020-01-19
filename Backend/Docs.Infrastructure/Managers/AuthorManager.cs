using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Infrastructure.Managers
{
    public class AuthorManager : BaseManager<Author, IAuthorRepository>, IAuthorManager
    {

        public AuthorManager(IAuthorRepository repo) : base(repo)
        {
        }

    }
}
