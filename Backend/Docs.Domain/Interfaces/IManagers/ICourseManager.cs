using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface ICourseManager
    {
        public Task<Course> CreateAsync(Course Course);

        public Task<Course> AlterAsync(Course Course);

        public Task<Course> GetAsync(Expression<Func<Course, bool>> expression);

        public Task<List<Course>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
