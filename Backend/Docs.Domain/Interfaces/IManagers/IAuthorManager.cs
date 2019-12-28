using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface IAuthorManager
    {
        Task<Author> CreateAsync(Author Author);

        Task<Author> UpdateAsync(Author Author);

        Task<Author> GetAsync(Expression<Func<Author, bool>> expression);

        Task<List<Author>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
