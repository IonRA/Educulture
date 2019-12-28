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
        Task<Course> CreateAsync(Course Course);

        Task<Course> UpdateAsync(Course Course);

        Task<Course> GetAsync(Expression<Func<Course, bool>> expression);

        Task<List<Course>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
