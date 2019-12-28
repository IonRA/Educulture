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
        Task<Question> CreateAsync(Question Question);

        Task<Question> UpdateAsync(Question Question);

        Task<Question> GetAsync(Expression<Func<Question, bool>> expression);

        Task<List<Question>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
