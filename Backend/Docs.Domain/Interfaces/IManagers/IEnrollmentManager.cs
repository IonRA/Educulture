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
        public Task<Enrollment> CreateAsync(Enrollment Enrollment);

        public Task<Enrollment> AlterAsync(Enrollment Enrollment);

        public Task<Enrollment> GetAsync(Expression<Func<Enrollment, bool>> expression);

        public Task<List<Enrollment>> GetAllAsync();

        public Task DeleteAsync(int id);
    }
}
