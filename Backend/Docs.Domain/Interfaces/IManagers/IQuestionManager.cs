using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface IQuestionManager
    {
        public Task<Question> CreateAsync(Question Question);

        public Task<Question> AlterAsync(Question Question);

        public Task<Question> GetAsync(Expression<Func<Question, bool>> expression);

        public Task<List<Question>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
