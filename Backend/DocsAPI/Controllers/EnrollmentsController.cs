using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
	    private IEnrollmentManager _enrollmentManager;

	    public EnrollmentsController(IEnrollmentManager enrollmentManager)
	    {
		    _enrollmentManager = enrollmentManager;
	    }

	    [HttpGet("GetAllEnrollments")]
	    public async Task GetAllEnrollments()
	    {
		    await _enrollmentManager.GetAllAsync();
	    }

	    [HttpPost("CreateEnrollment")]
	    public async Task CreateEnrollment(Enrollment enrollment)
	    {
		    await _enrollmentManager.CreateAsync(enrollment);
	    }

	    [HttpPut("UpdateEnrollment")]
	    public async Task UpdateEnrollment(Enrollment enrollment)
	    {
		    await _enrollmentManager.UpdateAsync(enrollment);
	    }

	    [HttpDelete("DeleteEnrollment")]
	    public async Task DeleteEnrollment(int id)
	    {
		    await _enrollmentManager.DeleteAsync(id);
	    }
	}
}