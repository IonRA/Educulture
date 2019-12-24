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
        public Task<Author> CreateAsync(Author Author);

        public Task<Author> AlterAsync(Author Author);

        public Task<Author> GetAsync(Expression<Func<Author, bool>> expression);

        public Task<List<Author>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
