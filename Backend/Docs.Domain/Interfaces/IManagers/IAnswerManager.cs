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
	    Task<Answer> CreateAsync(Answer Answer);

        Task<Answer> UpdateAsync(Answer Answer);

        Task<Answer> GetAsync(Expression<Func<Answer, bool>> expression);

        Task<List<Answer>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
