using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
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
	}
}