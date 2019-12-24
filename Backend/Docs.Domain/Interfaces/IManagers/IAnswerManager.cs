using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface IAnswerManager
    {
        public Task<Answer> CreateAsync(Answer Answer);

        public Task<Answer> AlterAsync(Answer Answer);

        public Task<Answer> GetAsync(Expression<Func<Answer, bool>> expression);

        public Task<List<Answer>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
