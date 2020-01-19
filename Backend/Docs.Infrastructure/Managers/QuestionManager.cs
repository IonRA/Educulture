using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Infrastructure.Managers
{
    public class QuestionManager : BaseManager<Question, IQuestionRepository>, IQuestionManager
    {

        public QuestionManager(IQuestionRepository repo) : base(repo)
        {
        }

    }
}
