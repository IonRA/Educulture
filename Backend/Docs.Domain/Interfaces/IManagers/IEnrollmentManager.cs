using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Domain.Interfaces.IManagers
{
    public interface IEnrollmentManagear
    {
        Task<Enrollment> CreateAsync(Enrollment Enrollment);

        Task<Enrollment> UpdateAsync(Enrollment Enrollment);

        Task<Enrollment> GetAsync(Expression<Func<Enrollment, bool>> expression);

        Task<List<Enrollment>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
