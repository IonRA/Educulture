using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Infrastructure.Managers
{
    public class AnswerManager : BaseManager<Answer, IAnswerRepository>, IAnswerManager
    {

        public AnswerManager(IAnswerRepository repo): base(repo)
        {
        }

    }
}
