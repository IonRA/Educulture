using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Docs.Infrastructure.Managers
{
    public class EnrollmentManager : BaseManager<Enrollment, IEnrollmentRepository>, IEnrollmentManager
    {

        public EnrollmentManager(IEnrollmentRepository repo) : base(repo)
        {
        }

    }
}
